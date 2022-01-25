using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helppad
{
    public class ProcessStateSource : IDisposable
    {
        private readonly ManualResetEventSlim _pauseHandler;

        private readonly ManualResetEventSlim _frontHandler;

        private readonly CancellationTokenSource _cts;

        public ProcessStateSource()
        {
            _pauseHandler = new ManualResetEventSlim(true);
            _frontHandler = new ManualResetEventSlim(false);
            _cts = new CancellationTokenSource();
        }

        public ProcessStateToken State => new()
        {
            _ct = _cts.Token,
            _frontHandler = _frontHandler,
            _pauseHandler = _pauseHandler,
        };

        /// <summary>
        /// Communicates a request for cancellation.
        /// </summary>
        public void Cancel()
        {
            _cts.Cancel();
        }

        /// <summary>
        /// Communicates a request for cancellation, and specifies whether remaining callbacks and cancelable operations should be processed.
        /// </summary>
        /// <param name="throwOnFirstException"></param>
        public void Cancel(bool throwOnFirstException)
        {
            _cts.Cancel(throwOnFirstException);
        }

        /// <summary>
        /// Schedules a cancel operation on this System.Threading.CancellationTokenSource 
        /// after the specified number of milliseconds.
        /// </summary>
        /// <param name="millisecondsDelay"></param>
        public void CancelAfter(int millisecondsDelay)
        {
            _cts.CancelAfter(millisecondsDelay);
        }

        /// <summary>
        /// Schedules a cancel operation on this System.Threading.CancellationTokenSource
        /// after the specified time span.
        /// </summary>
        /// <param name="delay"></param>
        public void CancelAfter(TimeSpan delay)
        {
            _cts.CancelAfter(delay);
        }

        public async Task<bool> PauseAsync(int ms, CancellationToken cancellation = default)
        {
            // request pause handler
            _pauseHandler.Reset();

            // wait for response
            var success = await _frontHandler.WaitHandle.WaitOneAsync(ms, cancellation);

            if (success is false)
            {
                _pauseHandler.Set();
            }

            return success;
        }


        public void Run()
        {
            // open the pause handler to continue run
            _pauseHandler.Set();

            // close the front handler
            _frontHandler.Reset();
        }

        /// <summary>
        /// Releases all resources used by the current instance of the
        /// System.Threading.CancellationTokenSource class.
        /// </summary>
        public void Dispose()
        {
            _cts.Dispose();
            _frontHandler.Dispose();
            _pauseHandler.Dispose();
        }
    }

    public struct ProcessStateToken
    {
        internal ManualResetEventSlim _pauseHandler;

        internal ManualResetEventSlim _frontHandler;

        internal CancellationToken _ct;

        public bool IsCancellationRequested => _ct.IsCancellationRequested;

        public bool IsPausedRequested => IsCancellationRequested is false && _pauseHandler.IsSet is false;
        
        public bool IsRunning => IsCancellationRequested is false && _pauseHandler.IsSet is true;

        public void ThrowIfCancellationRequested()
        {
            _ct.ThrowIfCancellationRequested();
        }

        public void Register(Action action)
        {
            Review.NotNullArgument(action);
            _ct.Register(action);
        }

        public void Register(Action action, bool useSynchronizationContext)
        {
            Review.NotNullArgument(action);
            _ct.Register(action, useSynchronizationContext);
        }

        public void Register(Action<object> action, object state)
        {
            Review.NotNullArgument(action);
            _ct.Register(action, state);
        }

        public void Register(Action<object> action, object state, bool useSynchronizationContext)
        {
            Review.NotNullArgument(action);
            _ct.Register(action, state, useSynchronizationContext);
        }

        public async Task<bool> ReturnPauseAsync(CancellationToken cancellation = default)
        {
            if (_frontHandler.IsSet is false)
            {
                _frontHandler.Set();
            }

            if (cancellation.IsCancellationRequested)
            {
                return false;
            }

            // use the extension for wait handler
            // bind the cancellation tokens
            // first the passed as argument and internal
            return await _pauseHandler.WaitHandle.WaitOneAsync(CancellationTokenSource.CreateLinkedTokenSource(cancellation, _ct).Token);
        }

    }
}
