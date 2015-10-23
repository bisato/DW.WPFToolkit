using System;
using System.Collections.Generic;
using System.Linq;

namespace DW.WPFToolkit.Tryout
{
    public static class Helper
    {
        /// <summary>
        ///     Flattens the specified hierarchical List.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e">The e.</param>
        /// <param name="f">The f.</param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> e, Func<T, IEnumerable<T>> f)
        {
            return e.SelectMany(c => f(c).Flatten(f)).Concat(e);
        }
    }
}