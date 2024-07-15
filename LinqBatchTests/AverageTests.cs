using System;
using LinqBatch;
using System.Linq;
using System.Collections.Generic;

namespace LinqBatchTests
{
    public class AverageTests
    {
        int[][] intBatches;
        List<List<int>> listIntBatches;
        long[][] longBatches;
        List<List<long>> listLongBatches;
        double[][] doubleBatches;
        List<List<double>> listDoubleBatches;
        float[][] floatBatches;
        List<List<float>> listFloatBatches;
        int[][] emptyBatches;
        int[][] emptyTopArray;
        [SetUp]
        public void Setup()
        {
            int[] a = [3, 2, 1];
            int[] b = [6, 4, 5];
            int[] c = [0, -1, -2];
            intBatches = [a, b, c];
            List<int> lia = new(a);
            List<int> lib = new(b);
            List<int> lic = new(c);
            listIntBatches = [lia, lib, lic];
            long[] longa = [10, 4, 2];
            long[] longb = [2, 3, 100000000];
            long[] longc = [0, -1, -2];
            longBatches = [longa, longb, longc];
            List<long> lla = new(longa);
            List<long> llb = new(longb);
            List<long> llc = new(longc);
            listLongBatches = [lla, llb, llc];
            double[] doublea = [1.5, 9, 55, 3];
            double[] doubleb = [100000, 6.457, 6.458, 6.5];
            double[] doublec = [1.5, -9, -55, 3];
            doubleBatches = [doublea, doubleb, doublec];
            List<double> lda = new(doublea);
            List<double> ldb = new(doubleb);
            List<double> ldc = new(doublec);
            listDoubleBatches = [lda, ldb, ldc];
            float[] floata = [1.0f, 0f, 2.5f];
            float[] floatb = [100f, 1f, 2.5f];
            float[] floatc = [-1.0f, 0f, -2.5f];
            floatBatches = [floata, floatb, floatc];
            List<float> lfa = new(floata);
            List<float> lfb = new(floatb);
            List<float> lfc = new(floatc);
            listFloatBatches = [lfa, lfb, lfc];
            int[] ea = [];
            int[] eb = [];
            emptyBatches = [ea, eb];
            emptyTopArray = [];
        }

        [Test]
        public void TestIntSimple()
        {
            int expected = 2;
            int res = intBatches.TotalAverage();
            Assert.That(res, Is.EqualTo(expected));
            int res2 = listIntBatches.TotalAverage();
            Assert.That(res2, Is.EqualTo(expected));
        }

        [Test]
        public void TestLongSimple()
        {
            long expected = 11111113;
            long res = longBatches.TotalAverage();
            Assert.That(res, Is.EqualTo(expected));
            long res2 = listLongBatches.TotalAverage();
            Assert.That(res2, Is.EqualTo(expected));
        }

        [Test]
        public void TestDoubleSimple()
        {
            double expected = 8335.70125;
            double res = doubleBatches.TotalAverage();
            Assert.That(res, Is.EqualTo(expected));
            double res2 = listDoubleBatches.TotalAverage();
            Assert.That(res2, Is.EqualTo(expected));
        }

        [Test]
        public void TestFloatSimple()
        {
            float expected = 11.5f;
            float res = floatBatches.TotalAverage();
            Assert.That(res, Is.EqualTo(expected));
            float res2 = listFloatBatches.TotalAverage();
            Assert.That(res2, Is.EqualTo(expected));
        }

        [Test]
        public void TestEmptyBatches()
        {
            int[] expected = [];
            Assert.Throws<InvalidOperationException>(() => emptyBatches.TotalAverage());
        }

        [Test]
        public void TestEmptyTopArray()
        {
            int[] expected = [];
            Assert.Throws<InvalidOperationException>(() => emptyTopArray.TotalAverage());
        }

        [Test]
        public void BatchTestIntSimple()
        {
            int[] expected = [2, 5, -1];
            var res = intBatches.BatchAverage();
            int i = 0;
            foreach (var x in res)
            {
                Assert.That(x, Is.EqualTo(expected[i]));
                i++;
            }
            var res2 = listIntBatches.BatchAverage();
            i = 0;
            foreach (var x in res2)
            {
                Assert.That(x, Is.EqualTo(expected[i]));
                i++;
            }
        }

        [Test]
        public void BatchTestLongSimple()
        {
            long[] expected = [5, 33333335, -1];
            var res = longBatches.BatchAverage();
            int i = 0;
            foreach (var x in res)
            {
                Assert.That(x, Is.EqualTo(expected[i]));
                i++;
            }
            var res2 = listLongBatches.BatchAverage();
            i = 0;
            foreach (var x in res2)
            {
                Assert.That(x, Is.EqualTo(expected[i]));
                i++;
            }
        }

        [Test]
        public void BatchTestDoubleSimple()
        {
            double[] expected = [17.125, 25004.85375, -14.875];
            var res = doubleBatches.BatchAverage().ToArray();
            int i = 0;
            foreach (var x in res)
            {
                Assert.That(x, Is.EqualTo(expected[i]));
                i++;
            }
            var res2 = listDoubleBatches.BatchAverage().ToArray();
            i = 0;
            foreach (var x in res2)
            {
                Assert.That(x, Is.EqualTo(expected[i]));
                i++;
            }
        }

        [Test]
        public void BatchTestFloatSimple()
        {
            float[] expected = [1.1666666f, 34.5f, -1.1666666f];
            var res = floatBatches.BatchAverage();
            int i = 0;
            foreach (var x in res)
            {
                Assert.That(x, Is.EqualTo(expected[i]));
                i++;
            }
            var res2 = listFloatBatches.BatchAverage();
            i = 0;
            foreach (var x in res2)
            {
                Assert.That(x, Is.EqualTo(expected[i]));
                i++;
            }
        }

        [Test]
        public void BatchTestEmptyBatches()
        {
            int[] expected = [];
            var res = emptyBatches.BatchAverage();
            Assert.Throws<InvalidOperationException>(() => res.Any());
        }

        [Test]
        public void BatchTestEmptyTopArray()
        {
            int[] expected = [];
            var res = emptyTopArray.BatchAverage();
            Assert.Throws<InvalidOperationException>(() => res.Any());
        }
    }
}
