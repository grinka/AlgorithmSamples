using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleAlgorithms;

namespace SamplesTest {
    [TestClass]
    public class SimpleAlgorithmTest {
        [TestMethod]
        [TestCategory("SimpleAlgorithms")]
        [TestCategory("BinarySearch")]
        public void TestSimpleBinarySearch1() {
            var ret = SimpleBinarySearch<int>.FindElementInArray(2, new[] {1, 4, 6, 7, 8, 12, 22});
            Assert.AreEqual(-1, ret);
        }

        [TestMethod]
        [TestCategory("SimpleAlgorithms")]
        [TestCategory("BinarySearch")]
        public void TestSimpleBinarySearch2() {
            var ret = SimpleBinarySearch<int>.FindElementInArray(23, new[] {-4444, 0, 12, 13, 14, 23});
            Assert.AreEqual(5, ret);
        }

        [TestMethod]
        [TestCategory("SimpleAlgorithms")]
        [TestCategory("BinarySearch")]
        public void TestSimpleBinarySearch3() {
            var ret = SimpleBinarySearch<string>.FindElementInArray("R", new[] {"A", "D", "R", "S", "T", "W"});
            Assert.AreEqual(2, ret);
        }
    }
}