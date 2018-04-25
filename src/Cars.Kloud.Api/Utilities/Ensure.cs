using System;
using System.Diagnostics;

namespace Cars.Kloud.Api.Utilities
{
    public static class Ensure
    {
        /// <summary>
        /// Checks if the string passed in is null or empty and if so, throws an ArgumentException.
        /// </summary>
        /// <param name="param"></param>
        /// <param name="name"></param>
        [DebuggerStepThrough]
        public static void NotNullOrEmpty(string param, string name)
        {
            if (string.IsNullOrEmpty(param))
            {
                BreakIfDebuggerAttached();
                throw new ArgumentException("Parameter cannot be empty or null", name);
            }
        }


        /// <summary>
        /// Checks if the string passed in is not a URL, throws an ArgumentException.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        [DebuggerStepThrough]
        public static void IsUrl(string url, string name)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out _)) return;
            BreakIfDebuggerAttached();
            throw new ArgumentException("Parameter cannot be empty or null", name);
        }

        /// <summary>
        /// Checks if the parameter passed in is null and if so, throws an ArgumentNullException with the parameter name
        /// </summary>
        /// <param name="param">The parameter to check for null</param>
        /// <param name="name">The name of the parameter</param>
        [DebuggerStepThrough]
        public static void NotNull(object param, string name)
        {
            if (param != null) return;
            BreakIfDebuggerAttached();
            throw new ArgumentNullException(name);
        }
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        private static void BreakIfDebuggerAttached()
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
        }
    }
}