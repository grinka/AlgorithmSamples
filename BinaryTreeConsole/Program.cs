﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlrogithmSamples.BinaryTreeBalanced;

namespace BinaryTreeConsole
{
    class Program
    {
        static void Main(string[] args) {
            var tree = new RedBlackTree<int, int>(i => i);
            tree.Insert(7);
            tree.Insert(3);
            tree.Insert(18);
            tree.Insert(10);
            tree.Insert(22);
            tree.Insert(8);
            tree.Insert(11);
            tree.Insert(26);
            tree.DisplayTree();
        }
    }
}
