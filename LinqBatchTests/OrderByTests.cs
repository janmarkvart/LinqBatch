using System.Collections.Generic;
using System.Linq;
using LinqBatch;

namespace LinqBatchTests
{
    public class OrderByTests
    {
        int[][] intBatches;
        List<List<int>> listIntBatches;
        string[][] stringBatches;
        List<List<string>> listStringBatches;
        int[][] emptyBatches;
        string[][] emptyTopArray;
        [SetUp]
        public void Setup()
        {
            int[] a = [10, 1, 3];
            int[] b = [-2, 5, -6];
            intBatches = [a, b];
            List<int> lia = new(a);
            List<int> lib = new(b);
            listIntBatches = [lia, lib];
            string[] stringa = ["apple", "orange", "pear"];
            string[] stringb = ["car", "bike", "train"];
            stringBatches = [stringa, stringb];
            List<string> lsa = new(stringa);
            List<string> lsb = new(stringb);
            listStringBatches = [lsa, lsb];
            int[] oa = [];
            int[] ob = [];
            emptyBatches = [oa, ob];
            emptyTopArray = [];
        }

        [Test]
        public void TestIntSimple()
        {
            int[][] expected = [[1, 3, 10], [-6, -2, 5]];
            var res = intBatches.BatchOrderBy(x => x);
            Assert.That(res, Is.EqualTo(expected));
            var res2 = listIntBatches.BatchOrderBy(x => x);
            Assert.That(res2, Is.EqualTo(expected));
        }

        [Test]
        public void TestStringSimple()
        {
            string[][] expected = [["apple", "orange", "pear"], ["bike", "car", "train"]];
            var res = stringBatches.BatchOrderBy(x => x);
            int i = 0;
            foreach (var s in res)
            {
                Assert.That(s, Is.EqualTo(expected[i]));
                i++;
            }
            var res2 = listStringBatches.BatchOrderBy(x => x);
            i = 0;
            foreach (var s in res2)
            {
                Assert.That(s, Is.EqualTo(expected[i]));
                i++;
            }
        }

        [Test]
        public void TestEmptyBatches()
        {
            int[][] expected = [[], []];
            var res = emptyBatches.BatchOrderBy(x => x);
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestEmptyTopArray()
        {
            string[][] expected = [];
            var res = emptyTopArray.BatchOrderBy(x => x);
            Assert.That(res, Is.EquivalentTo(expected));
        }
    }
}
