using System.Linq;
using AlgorithmSamples.BinaryTreeBalanced.AVLTree;
using AlgorithmSamples.BinaryTreeBalanced.RedBlackTree;
using AlgorithmSamples.BinaryTreeSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTest {
    [TestClass]
    public class BinaryTreeTest {
        private string[] StringTreeInit = {
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten"
        };

        private string SortedTreeResult = ":eight:five:four:nine:one:seven:six:ten:three:two";

        [TestMethod]
        [TestCategory("BinaryTree")]
        [TestCategory("MyAvlTree")]
        public void TestMyAvlTree1() {
            var tree = new MyAvlTree<string, string>(x => x);
            tree.Insert(StringTreeInit);
            var ret = tree.GetSortedAscending();
            var strRet = ret.Aggregate<string, string>(
                string.Empty,
                (collector, item) => $"{collector}:{item}");
            Assert.AreEqual(SortedTreeResult, strRet);
        }

        [TestMethod]
        [TestCategory("BinaryTree")]
        public void TestBinaryTreeMethodAsc1() {
            var tree = new BinaryTree<int>();
            tree.Insert(1);
            tree.Insert(12);
            tree.Insert(7);
            var ret = tree.SortedAscending;
            var strRet = ret.Aggregate<int, string>(string.Empty, (s, item) => $"{s} {item}");
            Assert.AreEqual(" 1 7 12", strRet);
        }

        [TestMethod]
        [TestCategory("BinaryTree")]
        public void TestNoncomparableTree1() {
            var strValue = BuildTreeOneTwoThree().SortedAscending.Aggregate(
                string.Empty,
                (accumulator, newValue) => $"{accumulator}:{newValue}");
            Assert.AreEqual(":eight:five:four:One:seven:six:three:two", strValue);
        }

        [TestMethod]
        [TestCategory("BinaryTree")]
        public void TestNoncomparableTree2() {
            var strValue = BuildTreeOneTwoThree().SortedDescending.Aggregate(
                string.Empty,
                (accumulator, newValue) => $"{accumulator}:{newValue}");
            Assert.AreEqual(":two:three:six:seven:One:four:five:eight", strValue);
        }

        [TestMethod]
        [TestCategory("BinaryTree")]
        public void TestNoncomparableTree3() {
            var strValue = BuildTreeOneTwoThreeSecondary().SortedDescending.Aggregate(
                string.Empty,
                (accumulator, newValue) => $"{accumulator}:{newValue}");
            Assert.AreEqual(":two:four:One:six:five:eight:three:seven", strValue);
        }

        private static NonComparableBinaryTree<string> BuildTreeOneTwoThreeSecondary() {
            var tree = new NonComparableBinaryTree<string>(x => x.Substring(1));
            FillTreeWithValues(tree);
            return tree;
        }

        private static NonComparableBinaryTree<string> BuildTreeOneTwoThree() {
            var tree = new NonComparableBinaryTree<string>(x => x);
            FillTreeWithValues(tree);
            return tree;
        }

        private static void FillTreeWithValues(NonComparableBinaryTree<string> tree) {
            tree.Insert("One");
            tree.Insert("two");
            tree.Insert("three");
            tree.Insert("four");
            tree.Insert("five");
            tree.Insert("six");
            tree.Insert("seven");
            tree.Insert("eight");
        }

        [TestMethod]
        [TestCategory("BinaryTree")]
        [TestCategory("AvlTree")]
        public void AvlTreeTest1() {
            var tree = new AvlTree<string, string>((s) => s.ToLowerInvariant());
            tree.Insert(StringTreeInit);

            var result = tree.Aggregate(
                string.Empty,
                (accumulator, addValue) => $"{accumulator}:{addValue}");

            Assert.AreEqual(SortedTreeResult, result);
        }

        //[TestMethod]
        //[TestCategory("BinaryTree")]
        //[TestCategory("RedBlackTree")]
        //public void RedBlackTreeTest1() {
        //    var tree = new RedBlackTree<string, string>((s) => s);
        //    tree.Insert(StringTreeInit);
        //}
    }
}