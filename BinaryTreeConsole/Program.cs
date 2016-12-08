using System;
using System.Collections.Generic;
using AlgorithmSamples.BinaryTreeBalanced.AVLTree;
using AlgorithmSamples.BinaryTreeBalanced.RedBlackTree;

namespace BinaryTreeConsole {
    class Program {
        static void Main() {
            //TestTreeAdding();
            //TestTreeBalanceRight();
            //TestTreeBalanceLeft();
            TestTreeBalanceLeftRight();
            TestTreeBalanceRightLeft();
        }

        private static void TestTreeBalanceLeftRight() {
            var tree = new MyAvlTree<int, int>((x) => x);
            tree.Insert(18);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            tree.Insert(10);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            tree.Insert(16);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
        }

        private static void TestTreeBalanceRightLeft() {
            var tree = new MyAvlTree<int, int>((x) => x);
            tree.Insert(10);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            tree.Insert(18);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            tree.Insert(16);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();

        }

        private static void TestTreeBalanceLeft() {
            var tree = new MyAvlTree<int, int>((x) => x);
            tree.Insert(18);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
            tree.Insert(16);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
            tree.Insert(10);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
        }

        private static void TestTreeBalanceRight() {
            var tree = new MyAvlTree<int, int>((x) => x);
            tree.Insert(10);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
            tree.Insert(16);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
            tree.Insert(18);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
        }

        private static void TestTreeAdding() {
            var tree = new MyAvlTree<int, int>((x) => x);
            tree.Insert(7);
            tree.Insert(3);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
            tree.Insert(18);
            tree.Insert(10);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
            tree.Insert(22);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
            tree.Insert(8);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
            tree.Insert(11);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.ReadKey();
            tree.Insert(26);
            DisplayTree(tree.DisplayTreeAsIs());
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Fin");
            Console.ReadKey();
        }

        static void DisplayTree(IList<string> treeView) {
            foreach (var treeLine in treeView) {
                Console.WriteLine(treeLine);
            }
        }
    }
}