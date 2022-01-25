using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Linq;

namespace Helppad
{
    /// <summary>
    /// A pool of worker to process many incomes from outside
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListenerProcess<T>
    {
        /// <summary>
        /// Init the process listener
        /// </summary>
        /// <param name="parellism"></param>
        protected ListenerProcess(int parellism)
        {
            Parallism = parellism;
            _collections = new BlockingCollection<T>[parellism];

            for (int i = 0; i < parellism; i++)
            {
                _collections[i] = new BlockingCollection<T>();
            }

            _cancellation = new CancellationTokenSource();
        }

        /// <summary>
        /// Usage for process without async flow
        /// </summary>
        /// <param name="parellism"></param>
        /// <param name="action"></param>
        public ListenerProcess(int parellism, Action<T, CancellationToken> action) : this(parellism)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            SyncAction = action;

            // deplay process
            Execute();
        }

        /// <summary>
        /// Usage for process with async flow
        /// </summary>
        /// <param name="parellism"></param>
        /// <param name="funcAsync"></param>
        public ListenerProcess(int parellism, Func<T, CancellationToken, Task> funcAsync) : this(parellism)
        {
            if (funcAsync is null)
            {
                throw new ArgumentNullException(nameof(funcAsync));
            }
            FuncAsync = funcAsync;

            // deplay process
            Execute();
        }

        /// <summary>
        /// This parameter determinate how to many threads should be usage
        /// </summary>
        public int Parallism { get; }

        /// <summary>
        /// Basic reference
        /// </summary>
        private BlockingCollection<T>[] _collections;

        /// <summary>
        /// Cancellation token
        /// </summary>
        private CancellationTokenSource _cancellation;

        /// <summary>
        /// For sync listener
        /// </summary>
        private Action<T, CancellationToken> SyncAction { get; }

        /// <summary>
        /// For async actions
        /// </summary>
        private Func<T, CancellationToken, Task> FuncAsync { get; }

        /// <summary>
        /// Put in background listeners execution
        /// </summary>
        protected void Execute()
        {
            // for async mode
            if (FuncAsync is not null)
            {
                for (int i = 0; i < Parallism; i++)
                {
                    ThreadPool.QueueUserWorkItem(delegate {
                        while (_cancellation.IsCancellationRequested is false)
                        {
                            // from blocking collections
                            _ = BlockingCollection<T>.TakeFromAny(_collections, out T current, _cancellation.Token);

                            // execute on income
                            var err = Paralleling.WaitAndReturnException(task: FuncAsync.Invoke(current, _cancellation.Token),
                                cancellation: _cancellation.Token);

                            // check if has any exception
                            if (err is not null)
                            {
                                // do something
                            }
                        }
                    });
                }
            }
            else
            {
                // for sync action
                for (int i = 0; i < Parallism; i++)
                {
                    ThreadPool.QueueUserWorkItem(delegate {
                        while (_cancellation.IsCancellationRequested is false)
                        {
                            // from blocking collections
                            _ = BlockingCollection<T>.TakeFromAny(_collections, out T current, _cancellation.Token);

                            try
                            {
                                // execute on income
                                SyncAction.Invoke(current, _cancellation.Token);
                            }
                            catch (Exception err)
                            {
                                // do something
                            }
                        }
                    });
                }
            }
        }

        /// <summary>
        /// Post a new element to process
        /// </summary>
        /// <param name="element"></param>
        public void Post(T element)
        {
            // throw if is cancelled
            _cancellation.Token.ThrowIfCancellationRequested();

            // push by static method ofer by blocking collection
            BlockingCollection<T>.AddToAny(_collections, element);
        }

        /// <summary>
        /// Try post a new element to process
        /// </summary>
        /// <param name="element"></param>
        public bool TryPost(T element)
        {
            // verify if the listener is cancellation requested
            if (_cancellation.IsCancellationRequested)
            {
                return false;
            }

            // push by static method ofer by blocking collection
            BlockingCollection<T>.AddToAny(_collections, element);
            
            // success
            return true;
        }

        /// <summary>
        /// Return a task that complete when the listener is free
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public Task<bool> WhenFreeAsync(CancellationToken cancellation = default)
        {
            var src = new TaskCompletionSource<bool>();

            // put in background observer tasks
            ThreadPool.QueueUserWorkItem(delegate {
                try
                {
                    while (true)
                    {
                        // for argument tokens
                        cancellation.ThrowIfCancellationRequested();
                        
                        // for internal tokens
                        _cancellation.Token.ThrowIfCancellationRequested();

                        // check
                        if (_collections.Select(x => x.Count).Sum() < 1)
                        {
                            src.SetResult(true);
                            break;
                        }
                    }
                }
                // for cancellation requested comple with false value
                catch (OperationCanceledException)
                {
                    src.SetResult(false);
                }
            });

            return src.Task;
        }

        /// <summary>
        /// Terminate the all listeners
        /// </summary>
        public void Complete()
        {
            _cancellation.Cancel();
        }
    }
}