using System.Collections.Generic;
using System.Linq;

namespace LinqBatch
{
    public static class LinqBatchSkip
    {
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
