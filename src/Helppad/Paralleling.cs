using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helppad
{
    #region Delegates
    /// <summary>
    /// This delegate is to create a task that complete
    /// when the action is invoked
    /// </summary>
    /// <param name="action"> The action to execute.</param>
    public delegate void TaskDelegate(Action action);
    
    /// <summary>
    /// This delegate is to create a task with result
    /// when the result is passed to delegate
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="action"> The action to execute.</param>
    public delegate void TaskDelegate<T>(Action<T> action);
    #endregion

    /// <summary>
    /// For parallel work
    /// </summary>
    public static partial class Paralleling
    {
        #region FORLOOP

        /// <summary>
        /// For loop async to do parallel work.
        /// </summary>
        /// <param name="start">The initial number to start.</param>
        /// <param name="end">The final number to end.</param>
        /// <param name="task">The action to execute in every iteration.</param>
        /// <returns>Return a task that complete when the loop is finished.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task ForAsync(int start, int end, Action<int> task)
        {
            // the validation
            Review.ThrowIf(start == end, "The start and end should not be equal");
            Review.ThrowIf(start > end, "The range is incorrect");

            var execution = 0;

            var src = new TaskCompletionSource<int>();

            // for parallel
            for (int i = start; i < end; i++)
            {
                ThreadPool.QueueUserWorkItem(delegate 
                {
                    task.Invoke(i);

                    var result = Interlocked.Increment(ref execution);

                    if (result == end)
                    {
                        _ = src.TrySetResult(0);
                    }
                });
            }

            // for all
            return src.Task;
        }

        /// <summary>
        /// For loop async to do parallel work.
        /// </summary>
        /// <param name="start">The initial number to start.</param>
        /// <param name="end">The final number to end.</param>
        /// <param name="step">The step number to increment.</param>
        /// <param name="task">The action to execute in every iteration.</param>
        /// <returns>Return a task that complete when the loop is finished.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task ForAsync(int start, int end, int step, Action<int> task)
        {
            // the validation
            Review.ThrowIf(start == end, "The start and end should not be equal");
            Review.ThrowIf(start > end, "The range is incorrect");
            Review.ShouldBePositive(step, "The argument step should not be less or equal zero");

            var execution = 0;

            var src = new TaskCompletionSource<int>();

            // for parallel
            for (int i = start; i < end; i += 1)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    task.Invoke(i);

                    var result = Interlocked.Increment(ref execution);

                    if (result == end)
                    {
                        _ = src.TrySetResult(0);
                    }
                });
            }

            // for all
            return src.Task;
        }

        /// <summary>
        /// For loop async to do parallel work.
        /// </summary>
        /// <param name="start">The initial number to start.</param>
        /// <param name="end">The final number to end.</param>
        /// <param name="task">The action to execute in every iteration.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task ForAsync(int start, int end, Func<int, Task> task)
        {
            // the validation
            Review.ThrowIf(start == end, "The start and end should not be equal");
            Review.ThrowIf(start > end, "The range is incorrect");

            var execution = new List<Task>(capacity: end - start);

            // for parallel
            for (int i = start; i < end; i++)
            {
                execution.Add(task.Invoke(i));
            }
            
            // for all
            return Task.WhenAll(execution);
        }

        /// <summary>
        /// For loop async to do parallel work.
        /// </summary>
        /// <param name="start">The initial number to start.</param>
        /// <param name="end">The final number to end.</param>
        /// <param name="step">The step number to increment.</param>
        /// <param name="task">The action to execute in every iteration.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task ForAsync(int start, int end, int step, Func<int, Task> task)
        {
            // the validation
            Review.ThrowIf(start == end, "The start and end should not be equal");
            Review.ThrowIf(start > end, "The range is incorrect");
            Review.ShouldBePositive(step, "The argument step should not be less or equal zero");

            var execution = new List<Task>(capacity: end - start);

            // for parallel
            for (int i = start; i < end; i += step)
            {
                execution.Add(task.Invoke(i));
            }

            // for all
            return Task.WhenAll(execution);
        }

        /// <summary>
        /// For loop async to do parallel work
        /// Use cancellation token for binding the invoke method with cancellation request
        /// </summary>
        /// <param name="start">The initial number to start.</param>
        /// <param name="end">The final number to end.</param>
        /// <param name="task">The action to execute in every iteration.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task ForAsync(int start, int end, Action<int, CancellationToken> task, CancellationToken cancellation)
        {
            // the validation
            Review.ThrowIf(start == end, "The start and end should not be equal");
            Review.ThrowIf(start > end, "The range is incorrect");

            var execution = 0;
            var src = new TaskCompletionSource<int>();

            // for parallel
            for (int i = start; i < end; i++)
            {
                ThreadPool.QueueUserWorkItem(delegate 
                {
                    task.Invoke(i, cancellation);
                    var result = Interlocked.Increment(ref execution);

                    if (result == end)
                    {
                        _ = src.TrySetResult(0);
                    }
                });
            }

            // for all
            return src.Task;
        }

        /// <summary>
        /// For loop async to do parallel work.
        /// Use cancellation token for binding the invoke method with cancellation request.
        /// </summary>
        /// <param name="start">The initial number to start.</param>
        /// <param name="end">The final number to end.</param>
        /// <param name="step">The step number to increment.</param>
        /// <param name="task">The action to execute in every iteration.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task ForAsync(int start, int end, int step, Action<int, CancellationToken> task, CancellationToken cancellation)
        {
            // the validation
            Review.ThrowIf(start == end, "The start and end should not be equal");
            Review.ThrowIf(start > end, "The range is incorrect");
            Review.ShouldBePositive(step, "The argument step should not be less or equal zero");

            var execution = 0;
            var src = new TaskCompletionSource<int>();

            // for parallel
            for (int i = start; i < end; i++)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    task.Invoke(i, cancellation);

                    var result = Interlocked.Increment(ref execution);

                    if (result == end)
                    {
                        _ = src.TrySetResult(0);
                    }
                });
            }

            // for all
            return src.Task;
        }

        /// <summary>
        /// For loop async to do parallel work
        /// Use cancellation token for binding the invoke method with cancellation request
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="task"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task ForAsync(int start, int end, Func<int, CancellationToken, Task> task, CancellationToken cancellation)
        {
            // the validation
            Review.ThrowIf(start == end, "The start and end should not be equal");
            Review.ThrowIf(start > end, "The range is incorrect");

            var execution = new List<Task>(capacity: end - start);

            // for parallel
            for (int i = start; i < end; i++)
            {
                execution.Add(task.Invoke(i, cancellation));
            }

            // for all
            return Task.WhenAll(execution);
        }

        #endregion

        #region ANOTHERLOOPS

        /// <summary>
        /// For loop async for each item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="action"> The action to execute.</param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public static Task ForeachAsync<T>(IEnumerable<T> target,
                                           Action<T, CancellationToken> action,
                                           CancellationToken cancellation = default)
        {
            // check not null arguments
            Review.NotNull(target, "The arguemnt \"target\" is null");
            Review.NotNull(action, "The arguemnt \"action\" is null");
            
            // abort if the cancellation si requested
            if (cancellation.IsCancellationRequested)
            {
                return Task.CompletedTask;
            }

            var src = new TaskCompletionSource<int>();
            int len = target.Count();
            int i = 0;

            // use parallel linq
            target.AsParallel()
                .WithCancellation(cancellation)
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                // using parallel execution
                .ForAll(x => 
                {
                    action.Invoke(x, cancellation);
                    Interlocked.Increment(ref i);

                    // verify if complete taskis true
                    if (i >= len)
                    {
                        // then complete task
                        src.SetResult(0);
                    }
                });

            // return the task
            return src.Task;
        }

        /// <summary>
        /// Create infinite loop until is stoping is requested by user.
        /// Use return boolean value to continue execute the loop
        /// or use <see cref="CompletationHandler"/> to stop the loop.
        /// </summary>
        /// <param name="action"> The action to execute.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CompletationHandler LoopAsync(Func<bool> action)
        {
            var cancellation = new CancellationTokenSource();
            return new CompletationHandler(Task.Run(delegate {
                bool exit;
                do
                {
                   exit = action.Invoke();
                } while (cancellation.IsCancellationRequested is false && exit is false);
            }), cancellation);
        }

        /// <summary>
        /// Create infinite loop until is stoping is requested by user.
        /// Use return boolean value to continue execute the loop
        /// or use <see cref="CompletationHandler"/> to stop the loop
        /// </summary>
        /// <param name="action"> The action to execute.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CompletationHandler LoopAsync(Func<CancellationToken,bool> action)
        {
            var cancellation = new CancellationTokenSource();
            return new CompletationHandler(Task.Run(delegate {
                bool exit;
                do
                {
                    exit = action.Invoke(cancellation.Token);
                } while (cancellation.IsCancellationRequested is false && exit is false);
            }), cancellation);
        }

        /// <summary>
        /// Create infinite loop until is stoping is requested by user.
        /// Use return boolean value to continue execute the loop
        /// or use <see cref="CompletationHandler"/> to stop the loop
        /// </summary>
        /// <param name="action"> The action to execute.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CompletationHandler LoopAsync(Func<CancellationToken, Task<bool>> action)
        {
            var cancellation = new CancellationTokenSource();
            return new CompletationHandler(Task.Run(async delegate {
                bool exit;
                do
                {
                    exit = await action.Invoke(cancellation.Token);
                } while (cancellation.IsCancellationRequested is false && exit is false);
            }), cancellation);
        }

        #endregion

        #region Helpers
        /// <summary>
        /// Create a cancellation token auto request in passed ms time.
        /// </summary>
        /// <param name="ms">The milliseconds unit to set the time.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CancellationToken WithGraceful(int ms)
        {
            var src = new CancellationTokenSource(ms);
            src.Token.Register(delegate
            {
                src.Dispose();
            });
            return src.Token;
        }

        /// <summary>
        /// Create a cancellation with rule by function.
        /// </summary>
        /// <param name="ms">The milliseconds unit to set the time.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CancellationToken WithCancellationRequest(Func<bool> func)
        {
            Review.NotNull(func, "The \"func\" should be defined");

            // use token source
            var src = new CancellationTokenSource(0);

            // put in background
            ThreadPool.QueueUserWorkItem(delegate {
                // with loop the evaluation is invoked
                while (func.Invoke())
                {}
                // request
                src.Cancel();
            });

            return src.Token;
        }

        /// <summary>
        /// Execute an action that return a task with cancellation token by ms time.
        /// </summary>
        /// <param name="ms">The milliseconds unit to set the time.</param>
        /// <param name="func"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task ExecuteInGraceful(int ms, Func<CancellationToken, Task> func)
        {
            Review.NotNull(func, "The func should be defined");

            // execute with generate cancellation token
            return func.Invoke(WithGraceful(ms));
        }

        /// <summary>
        /// Generate a task completion by a delegate.
        /// </summary>
        /// <param name="delegate"></param>
        /// <param name="strategy"></param>
        /// <returns></returns>
        public static Task SwitchToTask(TaskDelegate @delegate, StrategyTask strategy = StrategyTask.Lineal)
        {
            Review.NotNull(@delegate, "The delegate is required and not null");

            var src = new TaskCompletionSource<int>();
            
            // by strategy to put task completion action
            switch (strategy)
            {
                case StrategyTask.Lineal:
                    @delegate.Invoke(delegate { src.SetResult(0); });
                    break;
                case StrategyTask.ThreadPool:
                    _ = ThreadPool.QueueUserWorkItem(delegate 
                    {
                        @delegate.Invoke(delegate { src.SetResult(0); });
                    });
                    break;
                case StrategyTask.Standalone:
                    new Thread(() => {
                        @delegate.Invoke(delegate { src.SetResult(0); });
                    }).Start();
                    break;
            }
            return src.Task;
        }

        /// <summary>
        /// Create a task completion by action with an argument to complete task.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="delegate"></param>
        /// <param name="strategy"></param>
        /// <returns></returns>
        public static Task<T> SwitchToTask<T>(TaskDelegate<T> @delegate, StrategyTask strategy = StrategyTask.Lineal)
        {
            Review.NotNullArgument(@delegate, "The delegate is required and not null");

            var src = new TaskCompletionSource<T>();

            // by strategy to put task completion action
            switch (strategy)
            {
                case StrategyTask.Lineal:
                    @delegate.Invoke(x => { src.SetResult(x); });
                    break;
                case StrategyTask.ThreadPool:
                    _ = ThreadPool.QueueUserWorkItem(delegate
                    {
                        @delegate.Invoke(x => { src.SetResult(x); });
                    });
                    break;
                case StrategyTask.Standalone:
                    new Thread(() => {
                        @delegate.Invoke(x => { src.SetResult(x); });
                    }).Start();
                    break;
            }

            return src.Task;
        }

        /// <summary>
        /// Execute an action by passed time.
        /// </summary>
        /// <param name="action"> The action to execute.</param>
        /// <param name="ms">The milliseconds unit to set the time.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static CompletationHandler DelayedAction(Action action, int ms)
        {
            Review.NotNullArgument(action, "The action is required and not null");
            var cts = new CancellationTokenSource();
            var process = Task.Delay(ms, cts.Token).ContinueWith(t=> action.Invoke());
            return new CompletationHandler(process, cts);
        }

        /// <summary>
        /// Waits for the task to complete and silent any exceptions.
        /// </summary>
        /// <param name="task"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WaitAndSilentException(Task task, CancellationToken cancellation)
        {
            Review.NotNull(task, "The task is null");

            // try execute
            try
            {
                task.Wait(cancellation);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Waits for the task to complete and silent any exceptions but return it.
        /// </summary>
        /// <param name="task"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#nullable enable
        public static AggregateException? WaitAndReturnException(Task task, CancellationToken cancellation)
#nullable disable
        {
            Review.NotNull(task, "The task is null");

            // try execute
            try
            {
                task.Wait(cancellation);
                return null;
            }
            catch (AggregateException err)
            {
                return err;
            }
        }

        /// <summary>
        /// Create task and complete by call return action.
        /// </summary>
        /// <returns>An handler</returns>
        public static (Task, Action) TaskFromTarget()
        {
            var src = new TaskCompletionSource<int>();

            /// export the task and handler to complete
            return (src.Task, delegate
            {
                    src.SetResult(0);
            });
        }

        /// <summary>
        /// Create task and complete by call return action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static (Task<T>, Action<T>) TaskFromTarget<T>()
        {
            var src = new TaskCompletionSource<T>();

            /// export the task and handler to complete
            return (src.Task, x =>
            {
                if (x is Exception err)
                {
                    src.SetException(err);
                }
                else
                {
                    src.SetResult(x);
                }
            }
            );
        }

        /// <summary>
        /// Returns a boolean value to give a singal that cancellation was requested 
        /// to avoid the high CPU issues for other types.
        /// Can use as extension or simple invoke pass the cancellation.
        /// </summary>
        /// <param name="cancellationToken">The target tokens.</param>
        /// <param name="ms">The milliseconds unit time to wait.</param>
        /// <returns>A true ig the token was cancelled or false if the timeout.</returns>
        public static bool Wait(this CancellationToken cancellationToken, int ms)
        {
            var timeTask = Task.Delay(ms);
            while (!cancellationToken.IsCancellationRequested && !timeTask.IsCompleted)
            {}

            // indicate if the token was cancelled
            return cancellationToken.IsCancellationRequested;
        }

        /// <summary>
        /// Returns a boolean value to give a singal async through task that cancellation was requested 
        /// to avoid the high CPU issues for other types.
        /// Can use as extension or simple invoke pass the cancellation.
        /// </summary>
        /// <param name="cancellationToken">The target tokens.</param>
        /// <param name="ms">The milliseconds unit time to wait. Pas zero if not has timeout.</param>
        /// <returns>
        /// A task with boolean result that complete 
        /// when the token is cancelled or the timeout is over. 
        /// </returns>
        public static Task<bool> WaitAsync(this CancellationToken cancellationToken, int ms = 0)
        {
            var src = new TaskCompletionSource<bool>();

            // for cancellation token
            cancellationToken.Register(delegate 
            {
                if (src.Task.IsCompleted is false)
                {
                    src.SetResult(true);
                }
            });

            // check timeout
            if (ms != 0)
            {
                // set timeout
                _ = DelayedAction(delegate 
                {
                    if (src.Task.IsCompleted is false)
                    {
                        // set false to indicate the timeout
                        src.SetResult(false);
                    }
                }, ms);
            }

            return src.Task;
        }

        /// <summary>
        /// Return true if the task was terminate.
        /// Can use this helper as extension too.
        /// </summary>
        /// <param name="task">The target task.</param>
        /// <returns>A boolean result if the task is finished by success or, cancelled or fault status.</returns>
        public static bool HasFinished(this Task task)
        {
            Review.NotNullArgument(task, "The task argument is null, must be instance");

            return new[] { 
                TaskStatus.Faulted, TaskStatus.Canceled, TaskStatus.RanToCompletion
                // call contains linq extension method to determine if the task has any this statuses
            }.Contains(task.Status);
        }

        /// <summary>
        /// Async wait for <see cref="WaitHandle"/> implementation for blocking and locks
        /// base on time limit and extra token cancellation.
        /// Can be use as extension of <see cref="WaitHandle"/> or helper.
        /// </summary>
        /// <param name="waitHandle">The primitive value to wait.</param>
        /// <param name="ms">The milliseconds unit time to wait.</param>
        /// <param name="cancellation">The cancellation toekn for wait.</param>
        /// <returns></returns>
        public static Task<bool> WaitOneAsync(this WaitHandle waitHandle,
                                                    int ms,
                                                    CancellationToken cancellation = default)
        {
            // Use the override using the timespan create from `ms` argument
            return WaitOneAsync(waitHandle, TimeSpan.FromMilliseconds(ms), cancellation);
        }

        /// <summary>
        /// Async wait for <see cref="WaitHandle"/> implementation for blocking and locks
        /// base on time limit and extra token cancellation.
        /// Can be use as extension of <see cref="WaitHandle"/> or helper.
        /// </summary>
        /// <param name="waitHandle">The primitive value to wait.</param>
        /// <param name="timeout">The timespan value for wait.</param>
        /// <param name="cancellation">The cancellation toekn for wait.</param>
        /// <returns></returns>
        public static async Task<bool> WaitOneAsync(this WaitHandle waitHandle,
                                                    TimeSpan timeout,
                                                    CancellationToken cancellation = default)
        {
            // check arguments
            Review.NotNullArgument(waitHandle, "The wait handler is null, must be instance");
            Review.CheckArgument(timeout < Timeout.InfiniteTimeSpan);

            // check token
            cancellation.ThrowIfCancellationRequested();

            // check if the handle is free
            if (waitHandle.WaitOne(TimeSpan.Zero))
            {
                return true;
            }

            var src = new TaskCompletionSource<bool>();
            // We don't rely on RegisterWait's own timeout handling logic and passing
            var registration = ThreadPool.RegisterWaitForSingleObject(waitHandle, 
            
            // handle register
            (state, timedOut) =>
            {
                // for register
                ((TaskCompletionSource<bool>) state).SetResult(!timedOut);
            },
            src,
            Timeout.Infinite,
            // just one execution
            executeOnlyOnce: true);

            // check cancellation
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellation);
            var result = await Task.WhenAny(src.Task, Task.Delay(timeout, cts.Token)).ConfigureAwait(false);

            // free registration
            registration.Unregister(null);

            if (result == src.Task)
            {
                // cancel internal token
                cts.Cancel();

                // wait the source task
                return await src.Task.ConfigureAwait(false);
            }

            cancellation.ThrowIfCancellationRequested();
            return false;
        }

        /// <summary>
        /// Async wait for <see cref="WaitHandle"/> implementation for blocking and locks
        /// base on time limit and extra token cancellation.
        /// Can be use as extension of <see cref="WaitHandle"/> or helper.
        /// </summary>
        /// <remarks>
        /// This override of wait one async not throw any exception of <see cref="OperationCanceledException"/>
        /// just return false if the passed cancellation is requested.
        /// </remarks>
        /// <param name="waitHandle">The primitive value to wait.</param>
        /// <param name="cancellation">The cancellation toekn for wait.</param>
        /// <returns></returns>
        public static async Task<bool> WaitOneAsync(this WaitHandle waitHandle,
                                                    CancellationToken cancellation = default)
        {
            // check arguments
            Review.NotNullArgument(waitHandle, "The wait handler is null, must be instance");

            // check token
            if (cancellation.IsCancellationRequested)
            {
                return false;
            }

            // check if the handle is free
            if (waitHandle.WaitOne(TimeSpan.Zero))
            {
                return true;
            }

            var src = new TaskCompletionSource<bool>();

            // We don't rely on RegisterWait's own timeout handling logic and passing
            var registration = ThreadPool.RegisterWaitForSingleObject(waitHandle,

            // handle register
            (state, timedOut) =>
            {
                // for register
                ((TaskCompletionSource<bool>)state).SetResult(!timedOut);
            },
            src,
            Timeout.Infinite,
            // just one execution
            executeOnlyOnce: true);

            // check cancellation
            var result = await Task.WhenAny(src.Task, cancellation.WaitAsync()).ConfigureAwait(false);

            // free registration
            registration.Unregister(null);

            if (result == src.Task)
            {
                // wait the source task
                return await src.Task.ConfigureAwait(false);
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Complete when all wait handlers is finished.
        /// It's like <see cref="Task.WhenAll(IEnumerable{Task})"/> but
        /// with <see cref="WaitHandle"/>.
        /// </summary>
        /// <param name="waitHandles">The wait handlers enuemrable.</param>
        /// <param name="ms">The milliseconds unit time to wait.</param>
        /// <param name="cancellation">The cancellation token request.</param>
        /// <returns>A task with all results.</returns>
        public static Task<bool[]> WhenAllAsync(IEnumerable<WaitHandle> waitHandles, int ms, CancellationToken cancellation = default)
        {
            return Task.WhenAll(waitHandles.Select(x => x.WaitOneAsync(ms, cancellation)).ToArray());
        }

        /// <summary>
        /// Complete when all wait handlers is finished.
        /// It's like <see cref="Task.WhenAll(IEnumerable{Task})"/> but
        /// with <see cref="WaitHandle"/>.
        /// </summary>
        /// <param name="waitHandles">The wait handlers enuemrable.</param>
        /// <param name="time">The time to wait.</param>
        /// <param name="cancellation">The cancellation token request.</param>
        /// <returns>A task with all results.</returns>
        public static Task<bool[]> WhenAllAsync(IEnumerable<WaitHandle> waitHandles, TimeSpan time, CancellationToken cancellation = default)
        {
            return Task.WhenAll(waitHandles.Select(x => x.WaitOneAsync(time, cancellation)).ToArray());
        }

        /// <summary>
        /// Wait for first <see cref="WaitHandle"/> in finished.
        /// Is like <see cref="Task.WhenAny(Task[])"/> but with wait
        /// handlers to get the first that finished.
        /// </summary>
        /// <param name="waitHandle">The wait handlers enuemrable.</param>
        /// <param name="ms">The milliseconds unit time to wait.</param>
        /// <param name="cancellation">The cancellation token request.</param>
        /// <returns>A task that complete when the first wait handler is complete.</returns>
        public static Task<WaitHandle> WaitAnyAsync(IEnumerable<WaitHandle> waitHandle, int ms, CancellationToken cancellation = default)
        {
            // link to the passed by argument
            var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellation);

            // set period time by milliseconds
            cts.CancelAfter(TimeSpan.FromMilliseconds(ms));

            // use the main override
            return WaitAnyAsync(waitHandle, cts.Token);
        }

        /// <summary>
        /// Wait for first <see cref="WaitHandle"/> in finished.
        /// Is like <see cref="Task.WhenAny(Task[])"/> but with wait
        /// handlers to get the first that finished.
        /// </summary>
        /// <param name="waitHandle">The wait handlers enuemrable.</param>
        /// <param name="time">The timespan to define timeout.</param>
        /// <param name="cancellation">The cancellation token request.</param>
        /// <returns>A task that complete when the first wait handler is complete.</returns>
        public static Task<WaitHandle> WaitAnyAsync(IEnumerable<WaitHandle> waitHandle, TimeSpan time, CancellationToken cancellation = default)
        {
            // link to the passed by argument
            var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellation);

            // set period time
            cts.CancelAfter(time);

            // use the main override
            return WaitAnyAsync(waitHandle, cts.Token);
        }

        /// <summary>
        /// Wait for first <see cref="WaitHandle"/> in finished.
        /// Is like <see cref="Task.WhenAny(Task[])"/> but with wait
        /// handlers to get the first that finished.
        /// </summary>
        /// <param name="waitHandle">The wait handlers enuemrable.</param>
        /// <param name="cancellation">The cancellation token request.</param>
        /// <returns>A task that complete when the first wait handler is complete.</returns>
        public static Task<WaitHandle> WaitAnyAsync(IEnumerable<WaitHandle> waitHandle, CancellationToken cancellation = default)
        {
            // make a query to verify if exits one wait handle completed
            var query = waitHandle.Where(x => x.WaitOne(TimeSpan.Zero)).ToArray();
            
            // check
            if (query.Length > 1)
            {
                // return the first from task
                return Task.FromResult(query[0]);
            }
            
            // use completation
            var src = new TaskCompletionSource<WaitHandle>();

            // registers
            var registrations = waitHandle.Select(w =>
            {
                // make a registration
                return ThreadPool.RegisterWaitForSingleObject(w,
                    callBack: WaitCallback(w),
                    // the completation
                    state: src,
                    // infinite interval
                    millisecondsTimeOutInterval: Timeout.Infinite,
                    // one time execution
                    executeOnlyOnce: true);
            })
            // call to array to activate select method
            .ToArray();

            // register a cancellation callback
            cancellation.Register(delegate 
            {
                // check if the task is incomplete
                if (!src.Task.IsCompleted)
                {
                    // for all signal object call unregister method
                    foreach (var register in registrations)
                    {
                        // unregister
                        register.Unregister(null);
                    }

                    // then cancel task
                    src.SetCanceled();
                }
            });

            // from task source
            return src.Task;

            // make the timer callback to register
            static WaitOrTimerCallback WaitCallback(WaitHandle current)
            {
                return (object state, bool timedOut) =>
                {
                    var completationState = (TaskCompletionSource<WaitHandle>)state;
                    if (completationState.Task.Status == TaskStatus.WaitingForActivation)
                        completationState.SetResult(current);
                };
            }
        }

        #endregion

        #region FeedbackHelper

        /// <summary>
        /// This method help to create a feedback object from two actors:
        ///     - The an IEnumerable from to work.
        ///     - The transform function.
        /// </summary>
        /// <remarks>
        ///     Use if the transform function is very complex or CPU work
        ///     otherwise this method using is not recommended.
        /// </remarks>
        /// <typeparam name="T">The from argument type.</typeparam>
        /// <typeparam name="K">The final type to post. </typeparam>
        /// <param name="elements">The enuemrable elements.</param>
        /// <param name="transform">The transformation function.</param>
        /// <param name="cancellation">Token that registered as cancellation request.</param>
        /// <returns>A feedback process to recive multiple element from enuemration.</returns>
        public static FeedBack<K> PostAll<T, K>(IEnumerable<T> elements,
                                                Func<T, K> transform,
                                                CancellationToken cancellation = default)
        {
            // checks arguments
            Review.NotNullArgument(elements);
            Review.NotNullArgument(transform);

            // check token
            cancellation.ThrowIfCancellationRequested();

            // feedback from IEnuemrable parallel
            return FeedBack.CreateFeedback<K>(push => 
            {
                // run in background 
                return Task.Run(delegate {
                    elements.AsParallel()
                        .WithCancellation(cancellation)
                        .Select(x => transform(x))
                        .ForAll(async r => await push(r));
                }, cancellationToken: cancellation);
            });
        }

        #endregion

        #region Intervals
        /// <summary>
        /// Create an interval process from a method definition and interval parameters.
        /// </summary>
        /// <param name="action"> The action to execute.</param>
        /// <param name="ms">The milliseconds unit to set the time.</param>
        /// <param name="bootstrapNow">Start interval right now.</param>
        /// <returns></returns>
        public static CompletationHandler SetInterval(Action action, int ms, bool bootstrapNow = false)
        {
            Review.NotNull(action, "The action should not null");
            Review.NonNegative(ms, "The action should not null");

            var cts = new CancellationTokenSource();
            return new CompletationHandler(Task.Run(async delegate {
                // if is requested start now then execute it
                if (bootstrapNow)
                {
                    action.Invoke();
                }

                // loop to make the interval
                while (cts.IsCancellationRequested is false)
                {
                    // wait interval
                    await Task.Delay(ms, cts.Token);

                    // execute the action interval
                    action.Invoke();
                }
            }), cts); 
        }

        /// <summary>
        /// Create an interval process from a method definition and interval parameters.
        /// </summary>
        /// <param name="action"> The action to execute.</param>
        /// <param name="ms">The milliseconds unit to set the time.</param>
        /// <param name="bootstrapNow">Start interval right now.</param>
        /// <returns></returns>
        public static CompletationHandler SetInterval(Func<Task> action, int ms, bool bootstrapNow = false)
        {
            Review.NotNull(action, "The action should not null");
            Review.NonNegative(ms, "The action should not null");

            var cts = new CancellationTokenSource();
            return new CompletationHandler(Task.Run(async delegate {
                // if is requested start now then execute it
                if (bootstrapNow)
                {
                    await action.Invoke();
                }

                // loop to make the interval
                while (cts.IsCancellationRequested is false)
                {
                    // wait interval
                    await Task.Delay(ms, cts.Token);

                    // execute the action interval
                    await action.Invoke();
                }
            }), cts);
        }

        /// <summary>
        /// Create an interval process from a method definition and interval parameters.
        /// </summary>
        /// <param name="action"> The action to execute.</param>
        /// <param name="time"> The time to set the period.</param>
        /// <param name="bootstrapNow">Start interval right now.</param>
        /// <returns></returns>
        public static CompletationHandler SetInterval(Action action, TimeSpan time, bool bootstrapNow = false)
        {
            Review.NotNull(action, "The action should not null");
            Review.TimespanNonZero(time, "The action should not null");

            var cts = new CancellationTokenSource();
            return new CompletationHandler(Task.Run(async delegate {
                // if is requested start now then execute it
                if (bootstrapNow)
                {
                    action.Invoke();
                }

                // loop to make the interval
                while (cts.IsCancellationRequested is false)
                {
                    // wait interval
                    await Task.Delay(time, cts.Token);

                    // execute the action interval
                    action.Invoke();
                }
            }), cts);
        }

        /// <summary>
        /// Create an interval process from a method definition and interval parameters.
        /// </summary>
        /// <param name="action"> The action to execute.</param>
        /// <param name="time"> The time to set the period.</param>
        /// <param name="bootstrapNow">Start interval right now.</param>
        /// <returns></returns>
        public static CompletationHandler SetInterval(Func<Task> action, TimeSpan time, bool bootstrapNow = false)
        {
            Review.NotNull(action, "The action should not null");
            Review.TimespanNonZero(time, "The action should not null");

            var cts = new CancellationTokenSource();
            return new CompletationHandler(Task.Run(async delegate {
                // if is requested start now then execute it
                if (bootstrapNow)
                {
                    await action.Invoke();
                }

                // loop to make the interval
                while (cts.IsCancellationRequested is false)
                {
                    // wait interval
                    await Task.Delay(time, cts.Token);

                    // execute the action interval
                    await action.Invoke();
                }
            }), cts);
        }

        /// <summary>
        /// Create an interval process from a method definition and interval parameters.
        /// </summary>
        /// <param name="action"> The action to execute.</param>
        /// <param name="ms">The milliseconds unit to set the time.</param>
        /// <param name="count"></param>
        /// <param name="bootstrapNow">Start interval right now.</param>
        /// <returns></returns>
        public static CompletationHandler SetInterval(Action action, int ms, int count, bool bootstrapNow = false)
        {
            Review.NotNull(action, "The action should not null");
            Review.NonNegative(ms, "The action should not null");

            var cts = new CancellationTokenSource();
            return new CompletationHandler(Task.Run(async delegate {
                // if is requested start now then execute it
                if (bootstrapNow)
                {
                    action.Invoke();
                }

                // loop to make the interval
                int i = 0;
                while (cts.IsCancellationRequested is false)
                {
                    if ((i < count) is false)
                    {
                        break;
                    }

                    // wait interval
                    await Task.Delay(ms, cts.Token);

                    // execute the action interval
                    action.Invoke();
                    i++;
                }
            }), cts);
        }

        /// <summary>
        /// Create an interval process from a method definition and interval parameters.
        /// </summary>
        /// <param name="action"> The action to execute.</param>
        /// <param name="ms">The milliseconds unit to set the time.</param>
        /// <param name="count"></param>
        /// <param name="bootstrapNow">Start interval right now.</param>
        /// <returns></returns>
        public static CompletationHandler SetInterval(Func<Task> action, int ms, int count, bool bootstrapNow = false)
        {
            Review.NotNull(action, "The action should not null");
            Review.NonNegative(ms, "The action should not null");

            var cts = new CancellationTokenSource();
            return new CompletationHandler(Task.Run(async delegate {
                // if is requested start now then execute it
                if (bootstrapNow)
                {
                    await action.Invoke();
                }

                // loop to make the interval
                int i = 0;
                while (cts.IsCancellationRequested is false)
                {
                    if ((i < count) is false)
                    {
                        break;
                    }

                    // wait interval 
                    await Task.Delay(ms, cts.Token);

                    // execute the action interval
                    await action.Invoke();
                    i++;
                }
            }), cts);
        }

        /// <summary>
        /// Create an interval process from a method definition and interval parameters.
        /// </summary>
        /// <param name="action"> The action to execute.</param>
        /// <param name="time"> The time to set the period.</param>
        /// <param name="count"></param>
        /// <param name="bootstrapNow">Start interval right now.</param>
        /// <returns></returns>
        public static CompletationHandler SetInterval(Action action, TimeSpan time, int count, bool bootstrapNow = false)
        {
            Review.NotNull(action, "The action should not null");
            Review.TimespanNonZero(time, "The action should not null");

            var cts = new CancellationTokenSource();
            return new CompletationHandler(Task.Run(async delegate {
                // if is requested start now then execute it
                if (bootstrapNow)
                {
                    action.Invoke();
                }

                // loop to make the interval
                int i = 0;
                while (cts.IsCancellationRequested is false)
                {
                    if ((i < count) is false)
                    {
                        break;
                    }

                    // wait interval
                    await Task.Delay(time, cts.Token);
                    
                    // execute the action interval
                    action.Invoke();
                    i++;
                }
            }), cts);
        }

        /// <summary>
        /// Create an interval process from a method definition and interval parameters.
        /// </summary>
        /// <param name="action"> The action to execute.</param>
        /// <param name="time"> The time to set the period.</param>
        /// <param name="count"></param>
        /// <param name="bootstrapNow">Start interval right now.</param>
        /// <returns></returns>
        public static CompletationHandler SetInterval(Func<Task> action, TimeSpan time, int count, bool bootstrapNow = false)
        {
            Review.NotNull(action, "The action should not null");
            Review.TimespanNonZero(time, "The action should not null");

            var cts = new CancellationTokenSource();
            return new CompletationHandler(Task.Run(async delegate {
                // if is requested start now then execute it
                if (bootstrapNow)
                {
                    await action.Invoke();
                }

                // loop to make the interval
                int i = 0;
                while (cts.IsCancellationRequested is false)
                {
                    if ((i < count) is false)
                    {
                        break;
                    }
                    await Task.Delay(time, cts.Token);
                    await action.Invoke();
                    i++;
                }
            }), cts);
        }

        /// <summary>
        /// Create a wait handler that track an time interval in set and reset.
        /// This method is not recommended use in Asp.Net projects.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="initial"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public static WaitHandle IntervalWait(TimeSpan time, bool initial, CancellationToken cancellation = default)
        {
            var reset = new ManualResetEvent(initial);

            // put in background
            ThreadPool.QueueUserWorkItem(async delegate {
                try
                {
                    while (true)
                    {
                        // brake the loop if the token is cancelled
                        cancellation.ThrowIfCancellationRequested();

                        // make the interval
                        await Task.Delay(time, cancellation);

                        // check the state
                        // use initial argument as internal state
                        if (initial)
                        {
                            reset.Reset();
                        }
                        else
                        {
                            reset.Set();
                        }

                        // switch initial
                        initial = !initial;
                    }

                }
                catch (OperationCanceledException)
                {
                    // nothing to do if the cancellation exception is catched
                }
                catch (ObjectDisposedException disposed)
                when(disposed.ObjectName == nameof(ManualResetEvent))
                {
                    // nothing to do if the reset event is disposed
                }
            });

            return reset;
        }

        #endregion

        #region Process

        /// <summary>
        /// This method help to create a listener to execute method when an income.
        /// is arrived
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"> The action to execute.</param>
        /// <returns></returns>
        public static ListenerProcess<T> CreateProcess<T>(Action<T, CancellationToken> action)
        {
            return new ListenerProcess<T>(Environment.ProcessorCount, action);
        }

        /// <summary>
        /// This method help to create  listener to execute method when an income.
        /// is arrived
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcAsync"></param>
        /// <returns></returns>
        public static ListenerProcess<T> CreateProcess<T>(Func<T, CancellationToken, Task> funcAsync)
        {
            return new ListenerProcess<T>(Environment.ProcessorCount, funcAsync);
        }

        /// <summary>
        /// This method help to create a listener to execute method when an income.
        /// is arrived
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paraellism"></param>
        /// <param name="action"> The action to execute.</param>
        /// <returns></returns>
        public static ListenerProcess<T> CreateProcess<T>(int paraellism, Action<T, CancellationToken> action)
        {
            return new ListenerProcess<T>(paraellism, action);
        }

        /// <summary>
        /// This method help to create a listener to execute method when an income.
        /// is arrived
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paraellism"></param>
        /// <param name="funcAsync"></param>
        /// <returns></returns>
        public static ListenerProcess<T> CreateProcess<T>(int paraellism, Func<T, CancellationToken, Task> funcAsync)
        {
            return new ListenerProcess<T>(paraellism, funcAsync);
        }

        #endregion

        #region ExtraEnums

        /// <summary>
        /// The stataegy task to implement a task in background
        /// </summary>
        public enum StrategyTask
        {
            /// <summary>
            /// Put in the current thread.
            /// </summary>
            Lineal,

            /// <summary>
            ///  Put in the thread pool <see cref="System.Threading.ThreadPool"/> by queue.
            /// </summary>
            ThreadPool,

            /// <summary>
            ///  Put in the single background thread.
            /// </summary>
            Standalone
        }

        #endregion
    }
}
