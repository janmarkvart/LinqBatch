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

        /// <summary>
        /// Finds average of input collection - variant for integers
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> average across all batches </returns>
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

        /// <summary>
        /// Finds average of input collection - variant for floating points
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> average across all batches </returns>
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

        /// <summary>
        /// Finds average of each batch - variant for integers
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> average for each batch </returns>
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

        /// <summary>
        /// Finds average of each batch - variant for floating points
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> average for each batch </returns>
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