using System;
using LinqBatch;
using System.Linq;
using System.Collections.Generic;

namespace LinqBatchTests
{
    public class SumTests
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
            int expected = 18;
            int res = intBatches.TotalSum();
            Assert.That(res, Is.EqualTo(expected));
            int res2 = listIntBatches.TotalSum();
            Assert.That(res2, Is.EqualTo(expected));
        }

        [Test]
        public void TestLongSimple()
        {
            long expected = 100000018;
            long res = longBatches.TotalSum();
            Assert.That(res, Is.EqualTo(expected));
            long res2 = listLongBatches.TotalSum();
            Assert.That(res2, Is.EqualTo(expected));
        }

        [Test]
        public void TestDoubleSimple()
        {
            double expected = 100028.415;
            double res = doubleBatches.TotalSum();
            Assert.That(res, Is.EqualTo(expected));
            double res2 = listDoubleBatches.TotalSum();
            Assert.That(res2, Is.EqualTo(expected));
        }

        [Test]
        public void TestFloatSimple()
        {
            float expected = 103.5f;
            float res = floatBatches.TotalSum();
            Assert.That(res, Is.EqualTo(expected));
            float res2 = listFloatBatches.TotalSum();
            Assert.That(res2, Is.EqualTo(expected));
        }

        [Test]
        public void TestEmptyBatches()
        {
            int expected = 0;
            var res = emptyBatches.TotalSum();
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestEmptyTopArray()
        {
            int expected = 0;
            var res = emptyTopArray.TotalSum();
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void BatchTestIntSimple()
        {
            int[] expected = [6, 15, -3];
            var res = intBatches.BatchSum();
            int i = 0;
            foreach (var x in res)
            {
                Assert.That(x, Is.EqualTo(expected[i]));
                i++;
            }
            var res2 = listIntBatches.BatchSum();
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
            long[] expected = [16, 100000005, -3];
            var res = longBatches.BatchSum();
            int i = 0;
            foreach (var x in res)
            {
                Assert.That(x, Is.EqualTo(expected[i]));
                i++;
            }
            var res2 = listLongBatches.BatchSum();
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
            double[] expected = [68.5, 100019.415, -59.5];
            var res = doubleBatches.BatchSum().ToArray();
            int i = 0;
            foreach (var x in res)
            {
                Assert.That(x, Is.EqualTo(expected[i]));
                i++;
            }
            var res2 = listDoubleBatches.BatchSum().ToArray();
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
            float[] expected = [3.5f, 103.5f, -3.5f];
            var res = floatBatches.BatchSum();
            int i = 0;
            foreach (var x in res)
            {
                Assert.That(x, Is.EqualTo(expected[i]));
                i++;
            }
            var res2 = listFloatBatches.BatchSum();
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
            int[] expected = [0, 0];
            var res = emptyBatches.BatchSum();
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void BatchTestEmptyTopArray()
        {
            var res = emptyTopArray.BatchSum();
            Assert.Throws<InvalidOperationException>(() => res.Any());
        }
    }
}
