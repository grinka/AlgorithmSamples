using System.Runtime.InteropServices;

namespace AlgorithmSamples.BinaryTreeBalanced.AVLTree {
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// It's just a simple my own implementation of the Avl Tree.
    /// </summary>
    public class MyAvlTree<T, TKey> where TKey : IComparable {
        private Func<T, TKey> _keyFunc;
        private AvlNode Root;
        private int Quantity; // total nodes quantity

        /// <summary>
        /// Simply inserts the node into the tree. Recalculates balance and height.
        /// Executes <see cref="BalanceInsert"/> to rebalance the tree.
        /// </summary>
        /// <param name="value"></param>
        public void Insert(T value) {
            if (Root == null) {
                Root = new AvlNode {
                    Parent = null,
                    Left = null,
                    Right = null,
                    Value = value,
                    Key = _keyFunc(value),
                    Balance = 0,
                    Height = 0
                };
                return;
            }
            var current = Root;
            var newKey = _keyFunc(value);
            while (current != null) {
                if (LessThan(newKey, current.Key)) {
                    if (current.Left == null) {
                        current.Left = new AvlNode {
                            Parent = current,
                            Left = null,
                            Right = null,
                            Value = value,
                            Key = newKey,
                            Balance = 0,
                            Height = 0
                        };
                        //current.Balance--;
                        break;
                    } else {
                        current = current.Left;
                    }
                } else {
                    if (current.Right == null) {
                        current.Right = new AvlNode {
                            Parent = current,
                            Left = null,
                            Right = null,
                            Value = value,
                            Key = newKey,
                            Balance = 0,
                            Height = 0
                        };
                        //current.Balance++;
                        break;
                    } else {
                        current = current.Right;
                    }
                }
            }

            RecalculateParentHeightAndBalance(current);
            BalanceInsert(current);
        }

        private void RecalculateParentHeightAndBalance(AvlNode childNode) {
            var parent = childNode;
            while (parent != null) {
                RecalculateNodeHeightAndBalance(parent);
                parent = parent.Parent;
            }
        }

        private void RecalculateNodeHeightAndBalance(AvlNode node) {
            var leftHeight = node.Left?.Height + 1 ?? 0;
            var rightHeight = node.Right?.Height + 1 ?? 0;
            node.Height = (leftHeight > rightHeight ? leftHeight : rightHeight);
            node.Balance = leftHeight - rightHeight;
        }

        public void Insert(IEnumerable<T> values) {
            foreach (var value in values) {
                Insert(value);
            }
        }

        public IEnumerable<T> GetSortedAscending() {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetSortedDescending() {
            throw new NotImplementedException();
        }

        private void BalanceInsert(AvlNode newNode) {
            var current = newNode;
            while (current != null) {
                var saveParent = current.Parent;
                switch (current.Balance) {
                    case 2:
                        switch (current.Left.Balance) {
                            case 1:
                                RotateLeftLeft(current);
                                break;
                            case -1:
                                RotateLeftRight(current);
                                break;
                        }
                        if (saveParent != null) {
                            // not a root note
                            RecalculateNodeHeightAndBalance(saveParent.Left.Right);
                            RecalculateNodeHeightAndBalance(saveParent.Left.Left);
                            RecalculateParentHeightAndBalance(saveParent.Left);
                        } else {
                            RecalculateNodeHeightAndBalance(Root.Right);
                            RecalculateNodeHeightAndBalance(Root.Left);
                            RecalculateNodeHeightAndBalance(Root);
                        }
                        break;
                    case -2:
                        switch (current.Right.Balance) {
                            case 1:
                                RotateRightLeft(current);
                                break;
                            case -1:
                                RotateRightRight(current);
                                break;
                        }
                        if (saveParent != null)
                        {
                            // not a root note
                            RecalculateNodeHeightAndBalance(saveParent.Right.Right);
                            RecalculateNodeHeightAndBalance(saveParent.Right.Left);
                            RecalculateParentHeightAndBalance(saveParent.Left);
                        }
                        else
                        {
                            RecalculateNodeHeightAndBalance(Root.Right);
                            RecalculateNodeHeightAndBalance(Root.Left);
                            RecalculateNodeHeightAndBalance(Root);
                        }
                        break;
                }

                current = current.Parent;
            }
        }

        private void RotateRightRight(AvlNode node) {
            var top = node.Parent;
            if (top != null) {
                if (node.IsLeftNode) {
                    top.Left = node.Right;
                } else {
                    top.Right = node.Right;
                }
            } else {
                Root = node.Right;
            }
            node.Right.Parent = top;
            node.Right.Left = node;
            node.Right = null;
            node.Parent = node.Right;
        }

        private void RotateLeftLeft(AvlNode node) {
            var top = node.Parent;
            if (top != null) {
                if (node.IsLeftNode) {
                    top.Left = node.Left;
                } else {
                    top.Right = node.Left;
                }
            } else {
                Root = node.Left;
            }
            node.Left.Parent = top;
            node.Left.Right = node;
            node.Left = null;
            node.Parent = node.Left;
        }

        private void RotateRightLeft(AvlNode node) {
            var top = node.Parent;
            var newTop = node.Right.Left;
            var newLeft = node;
            var newRight = node.Right;

            node.Right.Left = null;
            node.Right = null;

            if (top != null) {
                if (node.IsLeftNode) {
                    top.Left = newTop;
                } else {
                    top.Right = newTop;
                }
            } else {
                Root = newTop;
            }

            ReassignVertexes(newTop, newLeft, newRight, top);
        }

        private void RotateLeftRight(AvlNode node) {
            var top = node.Parent;
            var newTop = node.Left.Right;
            var newLeft = node.Left;
            var newRight = node;

            node.Left.Right = null;
            node.Left = null;

            if (top != null) {
                if (node.IsLeftNode) {
                    top.Left = newTop;
                } else {
                    top.Right = newTop;
                }
            } else {
                Root = newTop;
            }

            ReassignVertexes(newTop, newLeft, newRight, top);
        }

        private void ReassignVertexes(AvlNode newTop, AvlNode newLeft, AvlNode newRight, AvlNode topParent) {
            newTop.Parent = topParent;
            newTop.Left = newLeft;
            newTop.Right = newRight;
            newLeft.Parent = newTop;
            newRight.Parent = newTop;
        }

        public string[] DisplayTreeAsIs() {
            var queue = new Queue<NodeWithLevel>();
            var lastLevel = 0;
            var lastLine = string.Empty;
            var result = new List<string>();
            queue.Enqueue(new NodeWithLevel(Root, 0));

            while (queue.Count > 0) {
                var current = queue.Dequeue();
                if (current.Level > lastLevel) {
                    result.Add(lastLine);
                    lastLevel = current.Level;
                    lastLine = string.Empty;
                }
                if (current.Node != null) {
                    lastLine +=
                        $"({current.Node.Value}:{current.Node.Height}:{current.Node.Balance}) ";
                    queue.Enqueue(new NodeWithLevel(current.Node.Left, lastLevel + 1));
                    queue.Enqueue(new NodeWithLevel(current.Node.Right, lastLevel + 1));
                } else {
                    lastLine += "(_null_:0:0) ";
                }
            }

            return result.ToArray();
        }

        private class NodeWithLevel {
            public AvlNode Node { get; }
            public int Level { get; }

            public NodeWithLevel(AvlNode node, int level) {
                Node = node;
                Level = level;
            }
        }

        public MyAvlTree(Func<T, TKey> keyFunc) {
            _keyFunc = keyFunc;
        }

        #region Compare methods

        /// <summary>
        /// Compares the key1 and key2 values.
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <returns>true if key1 less than key2</returns>
        private bool LessThan(TKey key1, TKey key2) {
            return key1.CompareTo(key2) < 0;
        }

        private bool LessOrEqual(TKey key1, TKey key2) {
            return key1.CompareTo(key2) < 1;
        }

        private bool BiggerThan(TKey key1, TKey key2) {
            return key1.CompareTo(key2) > 0;
        }

        #endregion

        private class AvlNode {
            public int Height { get; set; }
            public int Balance { get; set; }
            public T Value { get; set; }

            public AvlNode Parent { get; set; }
            public AvlNode Left { get; set; }
            public AvlNode Right { get; set; }

            public TKey Key { get; set; }

            public bool IsLeftNode => Parent.Left == this;
            public bool IsRightNode => Parent.Right == this;
        }
    }
}