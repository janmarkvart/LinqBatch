using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LinqBatch
{
    public static class LinqBatchSum
    {

        public static int TotalSum(this IEnumerable<IEnumerable<int>> input) => TotalSumBinary(input);
        public static long TotalSum(this IEnumerable<IEnumerable<long>> input) => TotalSumBinary(input);

        /// <summary>
        /// Finds sum of input collection - variant for integers
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> sum across all batches </returns>
        public static T TotalSumBinary<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IBinaryInteger<T>
        {
            T totalSum = T.Zero;
            foreach (var item in input)
            {
                foreach (var i in item)
                {
                    totalSum += i;
                }
            }
            return totalSum;
        }

        public static double TotalSum(this IEnumerable<IEnumerable<double>> input) => TotalSumFloating(input);
        public static float TotalSum(this IEnumerable<IEnumerable<float>> input) => TotalSumFloating(input);

        /// <summary>
        /// Finds sum of input collection - variant for floating points
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> sum across all batches </returns>
        public static T TotalSumFloating<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IFloatingPointIeee754<T>
        {
            T totalSum = T.Zero;
            foreach (var item in input)
            {
                foreach (var i in item)
                {
                    totalSum += i;
                }
            }
            return totalSum;
        }

        public static IEnumerable<int> BatchSum(this IEnumerable<IEnumerable<int>> input) => BatchSumBinary(input);
        public static IEnumerable<long> BatchSum(this IEnumerable<IEnumerable<long>> input) => BatchSumBinary(input);

        /// <summary>
        /// Finds sum of each batch - variant for integers
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> sum for each batch </returns>
        public static IEnumerable<T> BatchSumBinary<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IBinaryInteger<T>
        {
            if (!input.Any())
            {
                throw new InvalidOperationException();
            }
            foreach (var item in input)
            {
                T sum = T.Zero;
                foreach (var i in item)
                {
                    checked
                    {
                        sum += i;
                    }
                }
                yield return sum;
            }
        }

        public static IEnumerable<double> BatchSum(this IEnumerable<IEnumerable<double>> input) => BatchSumFloating(input);
        public static IEnumerable<float> BatchSum(this IEnumerable<IEnumerable<float>> input) => BatchSumFloating(input);

        /// <summary>
        /// Finds sum of each batch - variant for floating points
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> sum for each batch </returns>
        public static IEnumerable<T> BatchSumFloating<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IFloatingPointIeee754<T>
        {
            if (!input.Any())
            {
                throw new InvalidOperationException();
            }
            foreach (var item in input)
            {
                T sum = T.Zero;
                foreach (var i in item)
                {
                    checked
                    {
                        sum += i;
                    }
                }
                yield return sum;
            }
        }
    }
}