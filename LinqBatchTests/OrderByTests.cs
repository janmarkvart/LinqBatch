using System.Linq;
using LinqBatch;

namespace LinqBatchTests
{
    public class OrderByTests
    {
        int[][] intBatches;
        string[][] stringBatches;
        int[][] emptyBatches;
        string[][] emptyTopArray;
        [SetUp]
        public void Setup()
        {
            int[] a = [10, 1, 3];
            int[] b = [-2, 5, -6];
            intBatches = [a, b];
            string[] stringa = ["apple", "orange", "pear"];
            string[] stringb = ["car", "bike", "train"];
            stringBatches = [stringa, stringb];
            int[] oa = [];
            int[] ob = [];
            emptyBatches = [oa, ob];
            emptyTopArray = [];
        }

        [Test]
        public void TestIntSimple()
        {
            int[][] expected = [[1, 3, 10], [-6, -2, 5]];
            var res = intBatches.OrderBatchesBy(x => x);
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestStringSimple()
        {
            string[][] expected = [["apple", "orange", "pear"], ["bike", "car", "train"]];
            var res = stringBatches.OrderBatchesBy(x => x);
            int i = 0;
            foreach (var s in res)
            {
                Assert.That(s, Is.EqualTo(expected[i]));
                i++;
            }
        }

        [Test]
        public void TestEmptyBatches()
        {
            int[][] expected = [[], []];
            var res = emptyBatches.OrderBatchesBy(x => x);
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestEmptyTopArray()
        {
            string[][] expected = [];
            var res = emptyTopArray.OrderBatchesBy(x => x);
            Assert.That(res, Is.EquivalentTo(expected));
        }
    }
}
