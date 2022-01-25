using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Helppad
{
    /// <summary>
    /// Reference an interval
    /// </summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class CompletationHandler
    {
        /// <summary>
        /// The task completation
        /// </summary>
        public Task Complete { get; }

        /// <summary>
        /// Is true when <see cref="Complete"/> is complete
        /// </summary>
        public bool IsFinished => Complete.IsCompleted;

        /// <summary>
        /// The internal token source
        /// </summary>
        readonly CancellationTokenSource tokenSource;

        /// <summary>
        /// This is internal to create an instance from <see cref="Paralleling"/>
        /// </summary>
        /// <param name="complete"></param>
        /// <param name="tokenSource"></param>
        internal CompletationHandler(Task complete, CancellationTokenSource tokenSource)
        {
            Complete = complete;
            this.tokenSource = tokenSource;
        }

        /// <summary>
        /// Link the passed cancellation token with this work.
        /// </summary>
        /// <param name="cancellation">The target cancellation token.</param>
        public void LinkWith(CancellationToken cancellation)
        {
            cancellation.Register(delegate 
            {
                tokenSource.Cancel();
            });
        }

        /// <summary>
        /// Stop working when the passed task is complete.
        /// </summary>
        /// <param name="task">The target task.</param>
        public void After(Task task)
        {
            task.ContinueWith(t =>
            {
                tokenSource.Cancel();
            });
        }

        /// <summary>
        /// Stop working when the passed task is complete.
        /// </summary>
        /// <param name="tasks">A group of tasks.</param>
        public void AfterAny(IEnumerable<Task> tasks)
        {
            Task.WhenAny(tasks).ContinueWith(t =>
            {
                tokenSource.Cancel();
            });
        }

        /// <summary>
        /// Set the expiration time limit.
        /// </summary>
        /// <param name="time">The time to expire.</param>
        public void ExpireIn(TimeSpan time)
        {
            tokenSource.CancelAfter(time);
        }

        /// <summary>
        /// Execute the passed callback action to execute when the process is cancelled.
        /// </summary>
        /// <param name="callback"></param>
        public void WhenCancelled(Action callback)
        {
            tokenSource.Token.Register(callback);
        }

        /// <summary>
        /// Execute the passed callback action to execute when the process is finished.
        /// </summary>
        /// <param name="callback"></param>
        public void WhenFinish(Action callback)
        {
            Complete.ContinueWith(x => callback.Invoke());
        }

        /// <summary>
        /// Stop the interval
        /// </summary>
        public void Stop()
        {
            tokenSource.Cancel();
        }

        /// <summary>
        /// Resolve the message to display in debbuger
        /// </summary>
        /// <returns></returns>
        [ExcludeFromCodeCoverage]
        private string GetDebuggerDisplay()
        {
            return IsFinished ? "Completed" : "Working";
        }
    }
}
