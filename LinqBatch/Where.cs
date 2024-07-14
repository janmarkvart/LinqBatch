using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqBatch
{
    public static class LinqBatchWhere
    {
        /// <summary>
        /// Extension of basic Linq Select on IEnumerable<IEnumerable<>> input/output
        /// </summary>
        /// <typeparam name="T"> generic type of input  </typeparam>
        /// <typeparam name="R"> generic type of output </typeparam>
        /// <param name="input"> input collection </param>
        /// <param name="f"> delegate to function </param>
        /// <returns></returns>
        public static IEnumerable<T[]> Where<T>(this IEnumerable<IEnumerable<T>> input, Func<T, bool> f)
        {
            foreach (var item in input)
            {
                IList<T> l = [];
                foreach (var batchitem in item)
                {
                    if (f(batchitem))
                    {
                        l.Add(batchitem);
                    }
                }
                yield return l.ToArray();
            }
        }
    }
}
