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

        /// <summary>
        /// Finds maximum of input collection - variant for integers
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> maximum across all batches </returns>
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

        /// <summary>
        /// Finds maximum of input collection - variant for floating points
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> maximum across all batches </returns>
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

        /// <summary>
        /// Finds maximum of each batch - variant for integers
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> maximum for each batch </returns>
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

        /// <summary>
        /// Finds maximum of each batch - variant for floating points
        /// </summary>
        /// <typeparam name="T"> generic type of input </typeparam>
        /// <param name="input"> input collection </param>
        /// <returns> maximum for each batch </returns>
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