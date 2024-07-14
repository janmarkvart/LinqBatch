using System.Globalization;
using System.Linq;
using LinqBatch;

namespace LinqBatchTests
{
    public class WhereTests
    {
        int[][] intBatches;
        string[][] stringBatches;
        int[][] emptyBatches;
        string[][] emptyTopArray;
        [SetUp]
        public void Setup()
        {
            int[] a = [1, 2, 3];
            int[] b = [4, 5, 6];
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
            //select only even numbers
            int[][] expected = [[2], [4, 6]];
            var res = from x in intBatches where x%2==0 select x;
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestIntSimple2()
        {
            //select numbers bigger or equal 3
            int[][] expected = [[3], [4, 5, 6]];
            var res = from x in intBatches where x>=3  select x;
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestIntAdvanced()
        {
            //select only odd numbers bigger or equal 2
            int[][] expected = [[3], [5]];
            var res = from x in intBatches where x%2==1 where x >= 2 select x;
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestStringSimple()
        {
            //only longer than 4 characters
            string[][] expected = [["apple", "orange"], ["train"]];
            var res = from x in stringBatches where x.Length > 4 select x;
            int i = 0;
            foreach (string[] s in res)
            {
                Assert.That(s, Is.EqualTo(expected[i]));
                i++;
            }
        }

        [Test]
        public void TestNoMatches()
        {
            //x greater than 10 (none are)
            int[][] expected = [[],[]];
            var res = from x in intBatches where x>10 select x;
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestEmptyBatches()
        {
            int[][] expected = [[], []];
            var res = from x in emptyBatches where x==0 select x;
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestEmptyTopArray()
        {
            string[][] expected = [];
            var res = from x in emptyTopArray where x == "hello" select x;
            Assert.That(res, Is.EquivalentTo(expected));
        }
    }
}
