using System.Collections.Generic;
using System.Linq;
using LinqBatch;

namespace LinqBatchTests
{
    public class SelectTests
    {
        int[][] intBatches;
        List<List<int>> listIntBatches;
        string[][] stringBatches;
        List<List<string>> listStringBatches;
        object[][] emptyBatches;
        object[][] emptyTopArray;
        [SetUp]
        public void Setup()
        {
            int[] a = [1, 2, 3];
            int[] b = [4, 5, 6];
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
            object[] oa = [];
            object[] ob = [];
            emptyBatches = [oa, ob];
            emptyTopArray = [];
        }

        [Test]
        public void TestIntSimple()
        {
            var res = from x in intBatches select x;
            Assert.That(res, Is.EqualTo(intBatches));
            var res2 = from x in listIntBatches select x;
            Assert.That(res2, Is.EqualTo(intBatches));
        }

        [Test]
        public void TestIntSimple2()
        {
            int[] newa = [2, 4, 6];
            int[] newb = [8, 10, 12];
            int[][] expected = [newa, newb];
            var res = from x in intBatches select x * 2;
            Assert.That(res, Is.EqualTo(expected));
            var res2 = from x in listIntBatches select x * 2;
            Assert.That(res, Is.EqualTo(expected));
        }

        [Test]
        public void TestStringSimple()
        {
            var res = from x in stringBatches select x;
            Assert.That(res, Is.EqualTo(stringBatches));
            var res2 = from x in listStringBatches select x;
            Assert.That(res2, Is.EqualTo(stringBatches));
        }

        [Test]
        public void TestEmptyBatches()
        {
            var res = from x in emptyBatches select x;
            Assert.That(res, Is.EqualTo(emptyBatches));
        }

        [Test]
        public void TestEmptyTopArray()
        {
            var res = from x in emptyTopArray select x;
            Assert.That(res, Is.EqualTo(emptyTopArray));
        }
    }
}
