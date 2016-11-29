using System;
using System.Data.SqlTypes;

namespace AlrogithmSamples.BinaryTreeBalanced {
    public class RedBlackNode<T> {
        public RedBlackNode<T> Left { get; set; }
        public RedBlackNode<T> Right { get; set; }
        public RedBlackNode<T> Parent { get; set; }
        public NodeColor Color { get; set; }
        public T Value { get; set; }
        public int Count { get; set; }
        public IComparable ItemKey { get; set; }

        public RedBlackNode() {
        }

        public RedBlackNode(T data, IComparable key) {
            Left = null;
            Right = null;
            Parent = null;
            Count = 1;
            Color = NodeColor.Black;
            Value = data;
            ItemKey = key;
        }

        public RedBlackNode(T data, IComparable key, RedBlackNode<T> parent) : this(data, key) {
            Parent = parent;
        }
    }
}