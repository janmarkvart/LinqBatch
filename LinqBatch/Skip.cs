using System.Collections.Generic;
using System.Linq;

namespace LinqBatch
{
    public static class LinqBatchSkip
    {
        /// <summary>
        /// Skips first *count* items from each input collection batch
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <param name="count"> count of how many items to get </param>
        /// <returns> Enumerable of batches 
        /// containing all elements except first *count* </returns>
        public static IEnumerable<T[]> SkipBatch<T>(this IEnumerable<IEnumerable<T>> input, int count)
        {
            foreach (var item in input)
            {
                IList<T> l = [];
                int i = 0;
                if (count <= 0) yield return [];

                foreach (var batchitem in item)
                {
                    if (i >= count)
                    {
                        l.Add(batchitem);
                    }
                    i++;
                }
                yield return l.ToArray();
            }
        }
    }
}
