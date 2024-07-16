using System.Collections.Generic;
using System.Linq;

namespace LinqBatch
{
    public static class LinqBatchConversions
    {
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
