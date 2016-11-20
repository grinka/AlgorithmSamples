using System.Linq;
using AlgorithmSamples.BinaryTreeSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTest {
    [TestClass]
    public class SortingTest {
        [TestMethod]
        public void TestBinaryTreeMethodAsc1() {
            var tree = new BinaryTree<int>();
            tree.AddValue(1);
            tree.AddValue(12);
            tree.AddValue(7);
            var ret = tree.SortedAscending;
            ret.Aggregate<int, string>(string.Empty, (item, s) => $"{s} {item}");
        }

        [TestMethod]
        public void TestNoncomparableTree1() {
            var strValue = BuildTreeOneTwoThree().SortedAscending.Aggregate(
                string.Empty,
                (accumulator, newValue) => $"{accumulator}:{newValue}");
            Assert.AreEqual(":eight:five:four:One:seven:six:three:two", strValue);
        }

        [TestMethod]
        public void TestNoncomparableTree2()
        {
            var strValue = BuildTreeOneTwoThree().SortedDescending.Aggregate(
                string.Empty,
                (accumulator, newValue) => $"{accumulator}:{newValue}");
            Assert.AreEqual(":two:three:six:seven:One:four:five:eight", strValue);
        }

        [TestMethod]
        public void TestNoncomparableTree3()
        {
            var strValue = BuildTreeOneTwoThreeSecondary().SortedDescending.Aggregate(
                string.Empty,
                (accumulator, newValue) => $"{accumulator}:{newValue}");
            Assert.AreEqual(":two:four:One:six:five:eight:three:seven", strValue);
        }

        private static NonComparableTree<string> BuildTreeOneTwoThreeSecondary()
        {
            var tree = new NonComparableTree<string>(x => x.Substring(1));
            FillTreeWithValues(tree);
            return tree;
        }

        private static NonComparableTree<string> BuildTreeOneTwoThree() {
            var tree = new NonComparableTree<string>(x => x);
            FillTreeWithValues(tree);
            return tree;
        }

        private static void FillTreeWithValues(NonComparableTree<string> tree) {
            tree.AddValue("One");
            tree.AddValue("two");
            tree.AddValue("three");
            tree.AddValue("four");
            tree.AddValue("five");
            tree.AddValue("six");
            tree.AddValue("seven");
            tree.AddValue("eight");
        }
    }
}