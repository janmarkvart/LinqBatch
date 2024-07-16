using System.Collections.Generic;
using System.Linq;
using LinqBatch;

namespace LinqBatchTests
{
    public class ConversionTests
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
        public void TestToArrayIntSimple()
        {
            int[] expected = [1, 2, 3, 4, 5, 4, 5, 6];
            var res = intBatches.BatchesToArray();
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestToArrayIntSimple2()
        {
            int[] expected = [1, 2, 3, 4, 5, 4, 5, 6];
            var res = listIntBatches.BatchesToArray();
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestToArrayStringSimple()
        {
            string[] expected = ["apple", "orange", "pear", "train"];
            var res = stringBatches.BatchesToArray();
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestToArrayEmptyBatches()
        {
            string[] expected = [];
            var res = emptyBatches.BatchesToArray();
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestToArrayEmptyTopArray()
        {
            var res = emptyTopArray.BatchesToArray();
            Assert.That(res, Is.EqualTo(emptyTopArray));
        }

        [Test]
        public void TestToListIntSimple()
        {
            List<int> expected = [1, 2, 3, 4, 5, 4, 5, 6];
            var res = intBatches.BatchesToList();
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestToListIntSimple2()
        {
            List<int> expected = [1, 2, 3, 4, 5, 4, 5, 6];
            var res = listIntBatches.BatchesToList();
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestToListStringSimple()
        {
            string[] expected = ["apple", "orange", "pear", "train"];
            var res = stringBatches.BatchesToList();
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestToListEmptyBatches()
        {
            List<string> expected = [];
            var res = emptyBatches.BatchesToList();
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestToListEmptyTopArray()
        {
            var res = emptyTopArray.BatchesToList();
            Assert.That(res, Is.EqualTo(emptyTopArray));
        }
    }
}
