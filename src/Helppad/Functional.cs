using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Linq;

namespace Helppad{

    /// <summary>
    /// This class contains server functions helper methods.
    /// </summary>
    public static class Functional
    {
        /// <summary>
        /// Once executer is called, it will execute the action once and then dispose.
        /// </summary>
        /// <typeparam name="T">The type of the action.</typeparam>
        /// <param name="callable">The callable to execute once.</param>
        /// <param name="crashOnRetry">The callable to execute once.</param>
        /// <returns>The function that can execute the callable once.</returns>
        public static Func<T> Once<T>(Func<T> callable, bool crashOnRetry = false)
        {
            bool executed = false;
            T result = default(T);

            return () =>
            {
                if (!executed)
                {
                    result = callable();
                    executed = true;
                    return result;
                }else{
                    if(crashOnRetry){
                        throw new AlreadyCalledException("This function can only be executed once.");
                    }
                    else{
                        return result;
                    }
                }
            };
        }

        /// <summary>
        /// Once executer is called, it will execute the action once and then dispose.
        /// </summary>
        /// <typeparam name="T">The type of the action.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <param name="callable">The callable to execute once.</param>
        /// <param name="crashOnRetry">The callable to execute once.</param>
        /// <returns>The function that can execute the callable once.</returns>
        public static Func<T1, T> Once<T, T1>(Func<T1, T> callable, bool crashOnRetry = false)
        {
            bool executed = false;
            T result = default(T);

            return (x) =>
            {
                if (!executed)
                {
                    result = callable(x);
                    executed = true;
                    return result;
                }else{
                    if(crashOnRetry){
                        throw new AlreadyCalledException("This function can only be executed once.");
                    }
                    else{
                        return result;
                    }
                }
            };
        }

        /// <summary>
        /// Once executer is called, it will execute the action once and then dispose.
        /// </summary>
        /// <typeparam name="T">The type of the action.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="callable">The callable to execute once.</param>
        /// <param name="crashOnRetry">The callable to execute once.</param>
        /// <returns>The function that can execute the callable once.</returns>
        public static Func<T1, T2, T> Once<T, T1, T2>(Func<T1, T2, T> callable, bool crashOnRetry = false)
        {
            bool executed = false;
            T result = default(T);

            return (x, y) =>
            {
                if (!executed)
                {
                    result = callable(x, y);
                    executed = true;
                    return result;
                }else{
                    if(crashOnRetry){
                        throw new AlreadyCalledException("This function can only be executed once.");
                    }
                    else{
                        return result;
                    }
                }
            };
        }

        /// <summary>
        /// Once executer is called, it will execute the action once and then dispose.
        /// </summary>
        /// <typeparam name="T">The type of the action.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="callable">The callable to execute once.</param>
        /// <param name="crashOnRetry">The callable to execute once.</param>
        /// <returns>The function that can execute the callable once.</returns>
        public static Func<T1, T2, T3, T> Once<T, T1, T2, T3>(Func<T1, T2, T3, T> callable, bool crashOnRetry = false)
        {
            bool executed = false;
            T result = default(T);

            return (x, y, z) =>
            {
                if (!executed)
                {
                    result = callable(x, y, z);
                    executed = true;
                    return result;
                }else{
                    if(crashOnRetry){
                        throw new AlreadyCalledException("This function can only be executed once.");
                    }
                    else{
                        return result;
                    }
                }
            };
        }

        /// <summary>
        /// Once executer is called, it will execute the action once and then dispose.
        /// The smiliar to the Once function, but without returning the result.
        /// </summary>
        /// <param name="callable">The callable to execute once.</param>
        /// <param name="crashOnRetry">The callable to execute once.</param>
        /// <returns>The function that can execute the callable once.</returns>
        public static Action Once(Action callable, bool crashOnRetry = false)
        {
            bool executed = false;

            return () =>
            {
                if (!executed)
                {
                    callable();
                    executed = true;
                }else{
                    if(crashOnRetry){
                        throw new AlreadyCalledException("This function can only be executed once.");
                    }
                }
            };
        }

        /// <summary>
        /// Once executer is called, it will execute the action once and then dispose.
        /// The smiliar to the Once function, but without returning the result.
        /// </summary>
        /// <typeparam name="T">The type of the action.</typeparam>
        /// <param name="callable">The callable to execute once.</param>
        /// <param name="crashOnRetry">The callable to execute once.</param>
        /// <returns>The function that can execute the callable once.</returns>
        public static Action<T> Once<T>(Action<T> callable, bool crashOnRetry = false)
        {
            bool executed = false;

            return (x) =>
            {
                if (!executed)
                {
                    callable(x);
                    executed = true;
                }
                else
                {
                    if (crashOnRetry)
                    {
                        throw new AlreadyCalledException("This function can only be executed once.");
                    }
                }
            };
        }

        /// <summary>
        /// Once executer is called, it will execute the action once and then dispose.
        /// The smiliar to the Once function, but without returning the result.
        /// </summary>
        /// <typeparam name="T">The type of the action.</typeparam>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <param name="callable">The callable to execute once.</param>
        /// <param name="crashOnRetry">The callable to execute once.</param>
        /// <returns>The function that can execute the callable once.</returns>
        public static Action<T1> Once<T, T1>(Action<T1> callable, bool crashOnRetry = false)
        {
            bool executed = false;

            return (x) =>
            {
                if (!executed)
                {
                    callable(x);
                    executed = true;
                }

                else
                {
                    if (crashOnRetry)
                    {
                        throw new AlreadyCalledException("This function can only be executed once.");
                    }
                }
            };
        }

        /// <summary>
        /// Concatenates many delegates into one.
        /// </summary>
        /// <param name="callables">The callables to concatenate.</param>
        /// <returns>The concatenated delegate.</returns>
        public static Action Concat(params Action[] callables)
        {
            return () =>
            {
                foreach (var callable in callables)
                {
                    callable();
                }
            };
        }

        /// <summary>
        /// Call as pipeline many delegates into one.
        /// </summary>
        /// <param name="callables">The callables to concatenate. Should be Delegate instances.</param>
        public static object CallAsPipeline(params Delegate[] callables)
        {
            // validate that array is not empty
            if (callables.Length == 0)
            {
                throw new ArgumentException("CallAsPipeline requires at least one delegate.");
            }

            // the first should have no parameters
            if (callables[0].Method.GetParameters().Length != 0)
            {
                throw new ArgumentException("The first delegate in a CallAsPipeline must have no parameters.");
            }

            // call the first delegate
            var first = callables[0];
            object state = first.DynamicInvoke();

            // call the rest of the delegates
            // the return type of the next delegate should be the same as the first argument of the its next delegate
            for (int i = 1; i < callables.Length; i++)
            {
                var next = callables[i];
                var nextMethod = next.Method;
                var nextParameters = nextMethod.GetParameters();

                // validate that the next delegate has one parameter o whether more the rest argument has default values
                if (nextParameters.Length < 2 || nextParameters.Skip(1).All(x => x.IsOptional))
                {
                    throw new ArgumentException("The next delegate in a CallAsPipeline must have one parameter or the rest should be optionals.");
                }

                // call the next delegate and passed the last result as the first argument
                state = next.DynamicInvoke(state);
            }

            // return the last result
            return state;
        }
    }

    /// <summary>
    /// A class that can be used to execute a delegate once.
    /// </summary>
    public class AlreadyCalledException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AlreadyCalledException"/> class.
        /// </summary>
        public AlreadyCalledException()
            : base("This function can only be executed once."){}

        /// <summary>
        /// Initializes a new instance of the <see cref="AlreadyCalledException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AlreadyCalledException(string message)
            : base(message){}
            
    }
}