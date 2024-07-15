using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LinqBatch
{
    public static class LinqBatchAverage
    {

        public static int TotalAverage(this IEnumerable<IEnumerable<int>> input) => TotalAverageBinary(input);
        public static long TotalAverage(this IEnumerable<IEnumerable<long>> input) => TotalAverageBinary(input);

        //TODO: comments
        public static T TotalAverageBinary<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IBinaryInteger<T>
        {
            T totalSum = T.Zero;
            T totalCount = T.Zero;
            foreach (var item in input)
            {
                foreach (var i in item)
                {
                    totalSum += i;
                    totalCount++;
                }
            }
            if (totalCount.Equals(T.Zero)) throw new InvalidOperationException();
            return totalSum / totalCount;
        }

        public static double TotalAverage(this IEnumerable<IEnumerable<double>> input) => TotalAverageFloating(input);
        public static float TotalAverage(this IEnumerable<IEnumerable<float>> input) => TotalAverageFloating(input);

        //TODO: comments
        public static T TotalAverageFloating<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IFloatingPointIeee754<T>
        {
            T totalSum = T.Zero;
            T totalCount = T.Zero;
            foreach (var item in input)
            {
                foreach (var i in item)
                {
                    totalSum += i;
                    totalCount++;
                }
            }
            if (totalCount.Equals(T.Zero)) throw new InvalidOperationException();
            return totalSum/totalCount;
        }

        public static IEnumerable<int> BatchAverage(this IEnumerable<IEnumerable<int>> input) => BatchAverageBinary(input);
        public static IEnumerable<long> BatchAverage(this IEnumerable<IEnumerable<long>> input) => BatchAverageBinary(input);

        //TODO: comments
        public static IEnumerable<T> BatchAverageBinary<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IBinaryInteger<T>
        {
            if (!input.Any())
            {
                throw new InvalidOperationException();
            }
            foreach (var item in input)
            {
                T sum = T.Zero;
                T count = T.Zero;
                foreach(var i in item)
                {
                    checked
                    {
                        sum += i;
                        count++;
                    }
                }
                if (count.Equals(T.Zero)) throw new InvalidOperationException();
                yield return sum/count;
            }
        }

        public static IEnumerable<double> BatchAverage(this IEnumerable<IEnumerable<double>> input) => BatchAverageFloating(input);
        public static IEnumerable<float> BatchAverage(this IEnumerable<IEnumerable<float>> input) => BatchAverageFloating(input);

        //TODO: comments
        public static IEnumerable<T> BatchAverageFloating<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IFloatingPointIeee754<T>
        {
            if (!input.Any())
            {
                throw new InvalidOperationException();
            }
            foreach (var item in input)
            {
                T sum = T.Zero;
                T count = T.Zero;
                foreach (var i in item)
                {
                    checked
                    {
                        sum += i;
                        count++;
                    }
                }
                if (count.Equals(T.Zero)) throw new InvalidOperationException();
                yield return sum / count;
            }
        }
    }
}