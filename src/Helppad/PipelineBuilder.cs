using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helppad
{
    public static class PipelineBuilder
    {
        /// <summary>
        /// Create pipeline builder from first action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public static PipelineBuilder<T, T> Create<T>(Action<T> action)
        {
            Review.NotNull(action, "the pipe action can be null");

            var builder = new PipelineBuilder<T, T>();
            builder._pipes.Add(CreatePipe(action));
            return builder;
        }

        internal static Pipe CreatePipe<T>(Action<T> action)
        {
            return new Pipe(PipeType.Void, action);
        }

        internal static Pipe CreatePipe<T, K>(Func<T, K> action)
        {
            return new Pipe(PipeType.Result, action);
        }

        internal static Pipe CreatePipeAsync<T>(Func<T, Task> action)
        {
            return new Pipe(PipeType.AsyncVoid, action);
        }

        internal static Pipe CreatePipeAsync<T, K>(Func<T, Task<K>> action)
        {
            return new Pipe(PipeType.AsyncResult, action);
        }
    }

    /// <summary>
    /// Typed pipeline builder
    /// </summary>
    /// <typeparam name="TInitial"></typeparam>
    /// <typeparam name="K"></typeparam>
    public class PipelineBuilder<TInitial, K>
    {
        internal List<Pipe> _pipes = new();

        public PipelineBuilder<TInitial, K> Pipe(Action<K> pipe)
        {
            Review.NotNull(pipe, "the pipe action can be null");
            _pipes.Add(PipelineBuilder.CreatePipe(pipe));
            return this;
        }

        public PipelineBuilder<TInitial, TNew> Transform<TNew>(Func<K, TNew> pipe)
        {
            Review.NotNull(pipe, "the pipe action can be null");
            
            _pipes.Add(PipelineBuilder.CreatePipe(pipe));
            var newPipeline = new PipelineBuilder<TInitial, TNew>() { 
                _pipes = new(this._pipes)
            };
            return newPipeline;
        }

        public PipelineBuilder<TInitial, TNew> Pipe<TNew>(Func<K, Task<TNew>> pipe)
        {
            Review.NotNull(pipe, "the pipe action can be null");

            _pipes.Add(PipelineBuilder.CreatePipeAsync(pipe));
            var newPipeline = new PipelineBuilder<TInitial, TNew>()
            {
                _pipes = new(this._pipes)
            };
            return newPipeline;
        }

        public PipelineBuilder<TInitial, K> Pipe(Func<K, Task> pipe)
        {
            Review.NotNull(pipe, "the pipe action can be null");
            _pipes.Add(PipelineBuilder.CreatePipeAsync(pipe));
            return this;
        }

        /// <summary>
        /// Build the pipeline from current added pipes
        /// </summary>
        /// <returns></returns>
        public Pipeline<TInitial, K> Build()
        {
            return new Pipeline<TInitial, K>(_pipes.ToArray());
        }
    }
}
