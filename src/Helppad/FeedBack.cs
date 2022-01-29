using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Helppad
{
    /// <summary>
    /// A set the option to create and work with feedbacks
    /// </summary>
    public static class FeedBack
    {
        /// <summary>
        /// This contract represent a supplier object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface ISupplier<T>
        {
            /// <summary>
            /// The supplier method that push feedback.
            /// </summary>
            /// <param name="push">The pusher action.</param>
            /// <returns>A task that represent the feedback process.</returns>
            public Task SupplyFeed(Func<T, Task> push);
        }

        /// <summary>
        /// This contract represent a supplier reciver.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IFeedBackReciver<T>
        {
            /// <summary>
            /// This method should be called in implemention for each feddback recived.
            /// </summary>
            /// <param name="feed"></param>
            public void OnFeedBack(T feed);
        }

        /// <summary>
        /// A contract to implement a feedback process
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public interface IFeebackProcess<T> : ISupplier<T>, IFeedBackReciver<T>
        {
        }

        /// <summary>
        /// Create simple feedback from an single async push operation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static FeedBack<T> CreateFeedback<T>(Func<Func<T, Task>, Task> func)
        {
            Review.NotNull(func, "The function argument is mandatory");

            // initial open push
            TaskCompletionSource<T> front = new();
            var back = new SemaphoreSlim(1,1);
            CancellationTokenSource cancellation = new();

            // create simple feed back with single flow
            return new FeedBack<T>( 
            free: delegate {
                // check cancellation
                if (cancellation.IsCancellationRequested)
                {
                    // nothing do
                    return;
                }

                // cycle for free and recall
                front = new TaskCompletionSource<T>();
                back.Release(1);
            },
            // for simple call
            call: () => front.Task,
            // for complete task
            complete: func.Invoke(async x => 
            {
                await back.WaitAsync(cancellation.Token);

                // check cancellation
                if (!cancellation.IsCancellationRequested)
                {
                    front.SetResult(x);
                }
            }),
            // to abort the feed back process
            abort: delegate {
                cancellation.Cancel();
            },
            // to free all elements resource
            disposables: new IDisposable[] { cancellation, back});
        }

        /// <summary>
        /// Create a feedback implementation supplier
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="supplier"></param>
        /// <returns></returns>
        public static FeedBack<T> CreateFeedback<T>(ISupplier<T> supplier)
        {
            // from interface method
            return CreateFeedback<T>(supplier.SupplyFeed);
        }

        /// <summary>
        /// Create a feedback implementation supplier
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="process"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public static async Task CreateFeedback<T>(IFeebackProcess<T> process, CancellationToken cancellation = default)
        {
            // from interface method
            var feedback = CreateFeedback<T>(process.SupplyFeed);

            // behind process
            while (!feedback.Complete.IsCompleted)
            {
                process.OnFeedBack(await feedback.NextAsync());
            }
        }
    }

    /// <summary>
    /// Feed with single push way
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FeedBack<T> : IObservable<T>, IDisposable
    {
        /// <summary>
        /// The task that represent the execution running.
        /// </summary>
        public Task Complete { get; }

        /// <summary>
        /// Return true if is the feedback is finshed.
        /// </summary>
        public bool Finished { get => Complete.IsCompleted; }

        /// <summary>
        ///  Return true if is the feedback has pedding work.
        /// </summary>
        public bool Pending { get => Complete.IsCompleted is false; }


        readonly Func<Task<T>> _call;
        readonly Action _free;
        readonly Action _abort;
        private readonly IEnumerable<IDisposable> disposables;

        /// <summary>
        /// Internal construction for feedback
        /// </summary>
        /// <param name="call"></param>
        /// <param name="free"></param>
        /// <param name="complete"></param>
        /// <param name="abort"></param>
        /// <param name="disposables"></param>
        internal FeedBack(Func<Task<T>> call, Action free, Task complete, Action abort, IEnumerable<IDisposable> disposables)
        {
            if (disposables is null)
            {
                throw new ArgumentNullException(nameof(disposables));
            }

            _call = call;
            _free = free;
            Complete = complete;
            _abort = abort;
            this.disposables = disposables;
        }

        /// <summary>
        /// Usage for next value.
        /// </summary>
        /// <returns></returns>
        public Task<T> NextAsync()
        {
            // verify if is complete
            if (Complete.IsCompleted == true)
            {
                // then return null
                return Task.FromResult<T>(default);
            }

            // using the call action.
            return _call.Invoke()
           .ContinueWith(x =>
           {
               _free.Invoke();
               return x.Result;
           });
        }
           

        /// <summary>
        /// Call to the abort delegate 
        /// </summary>
        public void Abort() => _abort.Invoke();

        /// <summary>
        /// Create an thread where the passed observer is feed with
        /// income item
        /// </summary>
        /// <param name="observer">The target subscriber</param>
        /// <returns>Not has return disposable</returns>
        public IDisposable Subscribe(IObserver<T> observer)
        {
            // put in background
            _ = ThreadPool.QueueUserWorkItem(async delegate
            {
                while (Complete.IsCompleted is false)
                {
                    observer.OnNext(await NextAsync());
                }

                observer.OnCompleted();
            });
            return null;
        }

        /// <summary>
        /// Dispose all element associate with this feed back
        /// </summary>
        public void Dispose()
        {
            foreach (var item in disposables)
            {
                item.Dispose();
            }
        }
    }
}