using System.Linq;
using AlgorithmSamples.BinaryTreeBalanced.AVLTree;
using AlgorithmSamples.BinaryTreeBalanced.RedBlackTree;
using AlgorithmSamples.BinaryTreeSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SamplesTest {
    [TestClass]
    public class BinaryTreeTest {
        private string[] StringTreeInit = {
            "One",
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

        private string SortedTreeResult = ":eight:five:four:nine:One:seven:six:ten:three:two";

        [TestMethod]
        [TestCategory("BinaryTree")]
        public void TestBinaryTreeMethodAsc1() {
            var tree = new BinaryTree<int>();
            tree.AddValue(1);
            tree.AddValue(12);
            tree.AddValue(7);
            var ret = tree.SortedAscending;
            ret.Aggregate<int, string>(string.Empty, (item, s) => $"{s} {item}");
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
            tree.AddValue("One");
            tree.AddValue("two");
            tree.AddValue("three");
            tree.AddValue("four");
            tree.AddValue("five");
            tree.AddValue("six");
            tree.AddValue("seven");
            tree.AddValue("eight");
        }

        [TestMethod]
        [TestCategory("BinaryTree.AvlTree")]
        public void AvlTreeTest1() {
            var tree = new AvlTree<string, string>((s) => s);
            tree.Insert(StringTreeInit);

            var result = tree.Aggregate(
                string.Empty,
                (accumulator, addValue) => $"{accumulator}:{addValue}");

            Assert.AreEqual(SortedTreeResult, result);
        }

        [TestMethod]
        [TestCategory("BinaryTree")]
        [TestCategory("RedBlackTree")]
        public void RedBlackTreeTest1() {
            var tree = new RedBlackTree<string, string>((s) => s);
            tree.Insert(StringTreeInit);
        }
    }
}