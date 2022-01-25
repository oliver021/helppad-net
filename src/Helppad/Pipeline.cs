using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helppad
{
    /// <summary>
    /// Pipe type is to define a pipeline
    /// </summary>
    internal enum PipeType
    {
        AsyncVoid,
        AsyncResult,
        Void,
        Result
    }

    /// <summary>
    /// A pice of pipeline
    /// </summary>
    internal struct Pipe
    {
        /// <summary>
        /// Create a pipe for complete pipeline
        /// </summary>
        /// <param name="type"></param>
        /// <param name="delegate"></param>
        internal Pipe(PipeType type, Delegate @delegate)
        {
            Review.NotNull(@delegate, "The delegate should be not null.");

            Type = type;
            Delegate = @delegate ?? throw new ArgumentNullException(nameof(@delegate));
        }

        internal PipeType Type { get; }

        internal Delegate Delegate { get; }
    }

    /// <summary>
    /// The single parameter type Pipeline.
    /// </summary>
    /// <typeparam name="T">The entry type in pipeline.</typeparam>
    public class Pipeline<T>
    {
        /// <summary>
        /// Use a list to store pipes.
        /// </summary>
        internal List<Pipe> _pipes { get; set; }

        /// <summary>
        /// Register a new pipe.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Pipeline<T> Pipe(Action<T> action)
        {
            _pipes.Add(new Pipe(PipeType.Void, action));
            return this;
        }

        /// <summary>
        /// Register a new async pipe.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public Pipeline<T> Pipe(Func<T, Task> action)
        {
            _pipes.Add(new Pipe(PipeType.AsyncVoid, action));
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="argument"></param>
        public void Run(T argument)
        {
            foreach (var item in _pipes)
            {
                if (item.Type is PipeType.Void)
                {
                    item.Delegate.DynamicInvoke(new []{ argument });
                }
                else if (item.Type is PipeType.AsyncVoid)
                {
                    ((Task)item.Delegate.DynamicInvoke(new[] { argument })).Wait();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

    /// <summary>
    /// A pipeline for usage.
    /// </summary>
    /// <typeparam name="T">The entry type in pipeline.</typeparam>
    /// <typeparam name="K">The output type in pipeline.</typeparam>
    public class Pipeline<T, K>
    {
        /// <summary>
        /// Build instance from <see cref="PipelineBuilder{TInitial, K}"/> and <see cref="PipelineBuilder"/>
        /// </summary>
        /// <param name="pipes"></param>
        internal Pipeline(Pipe[] pipes)
        {
            Review.NotNull(pipes, null);
            Pipes = pipes;
        }

        Pipe[] Pipes { get; }

        /// <summary>
        /// Run pipeline
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        public K Run(T arg)
        {
            object result = arg;

            foreach (var item in Pipes)
            {
                // behavior
                switch (item.Type)
                {
                    case PipeType.AsyncVoid:
                        ((Task)item.Delegate.DynamicInvoke(result)).Wait();
                        break;

                    case PipeType.AsyncResult:
                        var cursor = item.Delegate.DynamicInvoke(result);
                        if (cursor.GetType().IsSubclassOf(typeof(Task)))
                        {
                            result = cursor.GetType().GetProperty(nameof(Task<object>.Result)).GetValue(cursor);
                        }
                        else
                        {
                            throw new InvalidOperationException("The pipes is corrupted");
                        }
                        break;

                    case PipeType.Void:
                        item.Delegate.DynamicInvoke(result);
                        break;

                    case PipeType.Result:
                        result = item.Delegate.DynamicInvoke(result);
                        break;
                }
            }

            return (K)result;
        }

        /// <summary>
        /// Run async pipeline
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="System.Reflection.TargetInvocationException"></exception>
        public async Task<K> RunAsync(T arg, CancellationToken cancellation = default)
        {
            object result = arg;

            foreach (var item in Pipes)
            {
                //  check token
                if (cancellation.IsCancellationRequested)
                {
                    cancellation.ThrowIfCancellationRequested();
                }
                
                // behavior
                switch (item.Type)
                {
                    case PipeType.AsyncVoid:
                        await (Task)item.Delegate.DynamicInvoke(result);
                        break;

                    case PipeType.AsyncResult:
                        // for async way is not way to get the result
                        // correctly
                        // should avoid use task<result> if that except use async method
                        throw new InvalidOperationException();

                    case PipeType.Void:
                        item.Delegate.DynamicInvoke(result);
                        break;

                    case PipeType.Result:
                        result = item.Delegate.DynamicInvoke(result);
                        break;
                }
            }

            return (K)result;
        }
    }
}
