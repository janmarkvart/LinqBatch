using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBatch
{
    public static class LinqBatchOrderBy
    {
        /// <summary>
        /// Extension of basic Linq OrderBy on IEnumerable<IEnumerable<>> input
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <typeparam name="TKey"> generic type of key to order by </typeparam>
        /// <param name="input"> input collection </param>
        /// <param name="keySelector"> delegate retrieving desired key from T </param>
        /// <returns> batches of ordered elements </returns>
        public static IEnumerable<IOrderedEnumerable<T>> OrderBatchesBy<T, TKey>(this IEnumerable<IEnumerable<T>> input, Func<T, TKey> keySelector)
        {
            foreach (var item in input)
            {
                IOrderedEnumerable<T> ord = item.OrderBy(x => keySelector(x));
                yield return ord;
            }
        }
        /// <summary>
        /// Extension of OrderBy using custom comparer
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <typeparam name="TKey"> generic type of key to order by </typeparam>
        /// <param name="input"> input collection </param>
        /// <param name="keySelector"> delegate retrieving desired key from T </param>
        /// <param name="comparer"> custom comparison </param>
        /// <returns> batches of ordered elements </returns>
        public static IEnumerable<IOrderedEnumerable<T>> OrderBatchesBy<T, TKey>(this IEnumerable<IEnumerable<T>> input, Func<T, TKey> keySelector, IComparer<TKey> comparer)
        {
            foreach (var item in input)
            {
                IOrderedEnumerable<T> ord = item.OrderBy(x => keySelector(x), comparer);
                yield return ord;
            }
        }
    }
}
