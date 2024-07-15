using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LinqBatch
{
    public static class LinqBatchMax
    {

        public static int TotalMax(this IEnumerable<IEnumerable<int>> input) => TotalMaxBinary(input);
        public static long TotalMax(this IEnumerable<IEnumerable<long>> input) => TotalMaxBinary(input);

        //TODO: comments
        public static T TotalMaxBinary<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IBinaryInteger<T>
        {
            IList<T> l = [];
            foreach (var item in input)
            {
                l.Add(item.Max());
            }
            return l.Max();
        }

        public static double TotalMax(this IEnumerable<IEnumerable<double>> input) => TotalMaxFloating(input);
        public static float TotalMax(this IEnumerable<IEnumerable<float>> input) => TotalMaxFloating(input);

        //TODO: comments
        public static T TotalMaxFloating<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IFloatingPointIeee754<T>
        {
            IList<T> l = [];
            foreach (var item in input)
            {
                l.Add(item.Max());
            }
            return l.Max();
        }

        public static IEnumerable<int> BatchMax(this IEnumerable<IEnumerable<int>> input) => BatchMaxBinary(input);
        public static IEnumerable<long> BatchMax(this IEnumerable<IEnumerable<long>> input) => BatchMaxBinary(input);

        //TODO: comments
        public static IEnumerable<T> BatchMaxBinary<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IBinaryInteger<T>
        {
            if (!input.Any())
            {
                throw new InvalidOperationException();
            }
            foreach (var item in input)
            {
                T min = item.Max();
                yield return min;
            }
        }

        public static IEnumerable<double> BatchMax(this IEnumerable<IEnumerable<double>> input) => BatchMaxFloating(input);
        public static IEnumerable<float> BatchMax(this IEnumerable<IEnumerable<float>> input) => BatchMaxFloating(input);

        //TODO: comments
        public static IEnumerable<T> BatchMaxFloating<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IFloatingPointIeee754<T>
        {
            if (!input.Any())
            {
                throw new InvalidOperationException();
            }
            foreach (var item in input)
            {
                T min = item.Max();
                yield return min;
            }
        }
    }
}