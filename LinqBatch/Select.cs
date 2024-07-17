using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBatch
{
    public static class LinqBatchSelect
    {
        /// <summary>
        /// Extension of basic Linq Select on IEnumerable<IEnumerable<T>> input/output
        /// </summary>
        /// <typeparam name="T"> generic type of input  </typeparam>
        /// <typeparam name="R"> generic type of output </typeparam>
        /// <param name="input"> input collection </param>
        /// <param name="f"> delegate to function </param>
        /// <returns> enumerable of processed batches </returns>
        public static IEnumerable<R[]> Select<T, R>(this IEnumerable<IEnumerable<T>> input, Func<T, R> f)
        {
            foreach (var item in input)
            {
                IList<R> l = [];
                foreach (var batchitem in item)
                {
                    l.Add(f(batchitem));
                }
                yield return l.ToArray();
            }
        }
    }
}
