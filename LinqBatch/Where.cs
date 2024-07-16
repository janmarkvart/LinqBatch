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
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <param name="condition"> delegate to condition method </param>
        /// <returns></returns>
        public static IEnumerable<T[]> Where<T>(this IEnumerable<IEnumerable<T>> input, Func<T, bool> condition)
        {
            foreach (var item in input)
            {
                IList<T> l = [];
                foreach (var batchitem in item)
                {
                    if (condition(batchitem))
                    {
                        l.Add(batchitem);
                    }
                }
                yield return l.ToArray();
            }
        }
    }
}
