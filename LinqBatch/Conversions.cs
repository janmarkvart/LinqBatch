using System.Collections.Generic;
using System.Linq;

namespace LinqBatch
{
    public static class LinqBatchConversions
    {
        /// <summary>
        /// Converts IEnumerable<IEnumerable<T>> input to IList<T>
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> IList of type T with "squashed" collection </returns>
        public static IList<T> BatchesToList<T>(this IEnumerable<IEnumerable<T>> input)
        {
            IList<T> l = [];
            foreach (var item in input)
            {
                foreach (var batchitem in item)
                {
                    l.Add(batchitem);
                }
            }
            return l;
        }

        /// <summary>
        /// Converts IEnumerable<IEnumerable<T>> input to T[] array
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> array of T with "squashed" collection </returns>
        public static T[] BatchesToArray<T>(this IEnumerable<IEnumerable<T>> input)
        {
            IList<T> l = [];
            foreach (var item in input)
            {
                foreach (var batchitem in item)
                {
                    l.Add(batchitem);
                }
            }
            return l.ToArray();
        }
    }
}
