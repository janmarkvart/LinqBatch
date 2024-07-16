using System.Collections.Generic;
using System.Linq;

namespace LinqBatch
{
    public static class LinqBatchTake
    {
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
