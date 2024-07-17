using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LinqBatch
{
    public static class LinqBatchMin
    {

        public static int TotalMin(this IEnumerable<IEnumerable<int>> input) => TotalMinBinary(input);
        public static long TotalMin(this IEnumerable<IEnumerable<long>> input) => TotalMinBinary(input);

        /// <summary>
        /// Finds minimum of input collection - variant for integers
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> minimum across all batches </returns>
        public static T TotalMinBinary<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IBinaryInteger<T>
        {
            IList<T> l = [];
            foreach (var item in input)
            {
                l.Add(item.Min());
            }
            return l.Min();
        }

        public static double TotalMin(this IEnumerable<IEnumerable<double>> input) => TotalMinFloating(input);
        public static float TotalMin(this IEnumerable<IEnumerable<float>> input) => TotalMinFloating(input);

        /// <summary>
        /// Finds minimum of input collection - variant for floating points
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> minimum across all batches </returns>
        public static T TotalMinFloating<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IFloatingPointIeee754<T>
        {
            IList<T> l = [];
            foreach (var item in input)
            {
                l.Add(item.Min());
            }
            return l.Min();
        }

        public static IEnumerable<int> BatchMin(this IEnumerable<IEnumerable<int>> input) => BatchMinBinary(input);
        public static IEnumerable<long> BatchMin(this IEnumerable<IEnumerable<long>> input) => BatchMinBinary(input);

        /// <summary>
        /// Finds minimum of each batch - variant for integers
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> minimum for each batch </returns>
        public static IEnumerable<T> BatchMinBinary<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IBinaryInteger<T>
        {
            if(!input.Any())
            {
                throw new InvalidOperationException();
            }
            foreach (var item in input)
            {
                T min = item.Min();
                yield return min;
            }
        }

        public static IEnumerable<double> BatchMin(this IEnumerable<IEnumerable<double>> input) => BatchMinFloating(input);
        public static IEnumerable<float> BatchMin(this IEnumerable<IEnumerable<float>> input) => BatchMinFloating(input);

        /// <summary>
        /// Finds minimum of each batch - variant for floating points
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> minimum for each batch </returns>
        public static IEnumerable<T> BatchMinFloating<T>(this IEnumerable<IEnumerable<T>> input)
            where T : struct, IFloatingPointIeee754<T>
        {
            if (!input.Any())
            {
                throw new InvalidOperationException();
            }
            foreach (var item in input)
            {
                T min = item.Min();
                yield return min;
            }
        }
    }
}