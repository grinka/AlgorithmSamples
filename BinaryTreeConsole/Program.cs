using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmSamples.BinaryTreeBalanced.AVLTree;
using AlgorithmSamples.BinaryTreeBalanced.RedBlackTree;

namespace BinaryTreeConsole {
    class Program {
        static void Main() {
            //TestTreeAdding();
            //TestTreeBalanceRight();
            //TestTreeBalanceLeft();
            MyAvlTreeStrings();
            //TestTreeBalanceRightLeft();
        }

        private static void DisplayDebugTree(MyAvlTree<string, string> tree) {
            DisplayTree(tree.DisplayTreeAsIs());
        }

        private static void MyAvlTreeStrings() {
            var tree = new MyAvlTree<string, string>(x => x);
            var content = new[] {
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


            tree.Insert(
                new[] {
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
                });
            Console.WriteLine(tree.GetSortedAscending().Aggregate(string.Empty, (s, s1) => $"{s}:{s1}"));
            DisplayTree(tree.DisplayTreeAsIs(), true);
        }

        private static void TestTreeLeftRight2() {
            var tree = new MyAvlTree<int, int>(x => x);
            tree.Insert(new[] {20, 16, 30, 14, 18});
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(19);
            DisplayTree(tree.DisplayTreeAsIs(), true);

            var result = tree.GetSortedAscending();
            Console.WriteLine(
                result.Aggregate<int, string>(string.Empty, (line, newItem) => $"{line}:{newItem}"));
            Console.ReadLine();
        }

        private static void TestTreeBalanceLeftRight() {
            var tree = new MyAvlTree<int, int>((x) => x);
            tree.Insert(18);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(10);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(16);
            DisplayTree(tree.DisplayTreeAsIs(), true);
        }

        private static void TestTreeBalanceRightLeft() {
            var tree = new MyAvlTree<int, int>((x) => x);
            tree.Insert(10);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(18);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(16);
            DisplayTree(tree.DisplayTreeAsIs(), true);
        }

        private static void TestTreeBalanceLeft() {
            var tree = new MyAvlTree<int, int>((x) => x);
            tree.Insert(18);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(16);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(10);
            DisplayTree(tree.DisplayTreeAsIs(), true);
        }

        private static void TestTreeBalanceRight() {
            var tree = new MyAvlTree<int, int>((x) => x);
            tree.Insert(10);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(16);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(18);
            DisplayTree(tree.DisplayTreeAsIs(), true);
        }

        private static void TestTreeAdding() {
            var tree = new MyAvlTree<int, int>((x) => x);
            tree.Insert(7);
            tree.Insert(3);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(18);
            tree.Insert(10);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(22);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(8);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(11);
            DisplayTree(tree.DisplayTreeAsIs());
            tree.Insert(26);
            DisplayTree(tree.DisplayTreeAsIs(), true);
        }

        static void DisplayTreeOnly(IList<string> treeView) {
            foreach (var treeLine in treeView) {
                Console.WriteLine(treeLine);
            }
        }

        static void DisplayTree(IList<string> treeView, bool isFin = false) {
            DisplayTreeOnly(treeView);
            Console.WriteLine("-----------------------------------------------------");
            if (isFin) {
                Console.WriteLine("Fin");
            }
            Console.ReadKey();
        }
    }
}