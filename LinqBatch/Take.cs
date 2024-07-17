using System.Collections.Generic;
using System.Linq;

namespace LinqBatch
{
    public static class LinqBatchTake
    {
        /// <summary>
        /// Retrieves first *count* items for each batch from input collection
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <param name="count"> count of how many items to get </param>
        /// <returns> Enumerable of batches 
        /// containing first *count* elements per batch </returns>
        public static IEnumerable<T[]> TakeBatch<T>(this IEnumerable<IEnumerable<T>> input, int count)
        {
            foreach (var item in input)
            {
                IList<T> l = [];
                int i = 0;
                if (count <= 0) yield return [];
                
                foreach (var batchitem in item)
                {
                    l.Add(batchitem);
                    i++;
                    if (i == count) break;
                }
                yield return l.ToArray();
            }
        }
    }
}
