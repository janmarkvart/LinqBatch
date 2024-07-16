using System.Collections.Generic;
using System.Linq;
using LinqBatch;

namespace LinqBatchTests
{
    public class SkipTests
    {
        int[][] intBatches;
        List<List<int>> listIntBatches;
        string[][] stringBatches;
        object[][] emptyBatches;
        object[][] emptyTopArray;
        [SetUp]
        public void Setup()
        {
            int[] a = [1, 2, 3, 4, 5];
            int[] b = [4, 5, 6];
            intBatches = [a, b];
            List<int> lia = new(a);
            List<int> lib = new(b);
            listIntBatches = [lia, lib];
            string[] stringa = ["apple", "orange", "pear"];
            string[] stringb = ["train"];
            stringBatches = [stringa, stringb];
            object[] oa = [];
            object[] ob = [];
            emptyBatches = [oa, ob];
            emptyTopArray = [];
        }

        [Test]
        public void TestIntSimple()
        {
            int[] newa = [5];
            int[] newb = [];
            int[][] expected = [newa, newb];
            var res = intBatches.SkipBatch(4);
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestIntSimple2()
        {
            int[] newa = [5];
            int[] newb = [];
            int[][] expected = [newa, newb];
            var res = listIntBatches.SkipBatch(4);
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestStringSimple()
        {
            string[][] expected = [["pear"],[]];
            var res = stringBatches.SkipBatch(2);
            int i = 0;
            foreach (var batch in res)
            {
                Assert.That(batch, Is.EqualTo(expected[i]));
                i++;
            }
        }

        [Test]
        public void TestEmptyBatches()
        {
            var res = emptyBatches.SkipBatch(10);
            Assert.That(res, Is.EqualTo(emptyBatches));
        }

        [Test]
        public void TestEmptyTopArray()
        {
            var res = emptyTopArray.SkipBatch(5);
            Assert.That(res, Is.EqualTo(emptyTopArray));
        }
    }
}
