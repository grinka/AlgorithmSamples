////
//// Original: https://bitlush.com/blog/efficient-avl-tree-in-c-sharp
//// 

using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmSamples.BinaryTreeBalanced.AVLTree {
    public class AvlTree<T, TKey> : IEnumerable<T> where TKey : IComparable {
        private readonly Func<T, TKey> _keyFunc;
        private AvlNode _root;

        private const int LeftBalanceIncrementor = 1;
        private const int RightBalanceIncrementor = -1;

        public AvlTree(Func<T, TKey> keyFunc) {
            _keyFunc = keyFunc;
        }

        private sealed class AvlNode {
            public AvlNode Parent { get; set; }
            public AvlNode Left { get; set; }
            public AvlNode Right { get; set; }
            public T Value { get; set; }
            public int Balance { get; set; }
            public TKey Key { get; set; }
        }

        #region Insert Node

        /// <summary>
        /// Insert a group of values - just call the Insert one value method in a loop.
        /// </summary>
        /// <param name="values"></param>
        public void Insert(T[] values) {
            foreach (var v in values) {
                Insert(v);
            }
        }

        public void Insert(T value) {
            var key = _keyFunc(value);
            if (_root == null) {
                _root = new AvlNode {Value = value, Key = key};
            } else {
                var node = _root;
                while (node != null) {
                    var keyCompare = key.CompareTo(node.Key);
                    if (keyCompare < 0) {
                        if (InsertLeftChildNode(value, key, ref node)) return;
                    } else if (keyCompare > 0) {
                        if (InsertRightChildNode(value, key, ref node)) return;
                    } else {
                        throw new Exception("Node with same key value already exists!");
                    }
                }
            }
        }

        private bool InsertRightChildNode(T value, TKey key, ref AvlNode node) {
            var right = node.Right;
            if (right == null) {
                node.Right = new AvlNode {Key = key, Value = value, Parent = node};
                InsertBalance(node, RightBalanceIncrementor);
                return true;
            } else {
                node = right;
            }
            return false;
        }

        private bool InsertLeftChildNode(T value, TKey key, ref AvlNode node) {
            var left = node.Left;
            if (left == null) {
                node.Left = new AvlNode {Key = key, Value = value, Parent = node};
                InsertBalance(node, LeftBalanceIncrementor);
                return true;
            } else {
                node = left;
            }
            return false;
        }

        private void InsertBalance(AvlNode node, int balance) {
            while (node != null) {
                balance = (node.Balance += balance);
                switch (balance) {
                    case 0:
                        return;
                    case 2:
                        if (node.Left.Balance == LeftBalanceIncrementor) {
                            RotateRight(node);
                        } else {
                            RotateLeftRight(node);
                        }

                        return;
                    case -2:
                        if (node.Right.Balance == RightBalanceIncrementor) {
                            RotateLeft(node);
                        } else {
                            RotateRightLeft(node);
                        }

                        return;
                    default:
                        break;
                }

                var parent = node.Parent;

                if (parent != null) {
                    balance = parent.Left == node ? LeftBalanceIncrementor : RightBalanceIncrementor;
                }

                node = parent;
            }
        }

        #endregion

        #region Rotating Methods

        private AvlNode RotateLeft(AvlNode node) {
            var right = node.Right;
            var rightLeft = right.Left;
            var parent = node.Parent;

            right.Parent = parent;
            right.Left = node;
            node.Right = rightLeft;
            node.Parent = right;

            if (rightLeft != null) {
                rightLeft.Parent = node;
            }

            if (node == _root) {
                _root = right;
            } else if (parent.Right == node) {
                parent.Right = right;
            } else {
                parent.Left = right;
            }

            right.Balance++;
            node.Balance = -right.Balance;

            return right;
        }

        private AvlNode RotateRight(AvlNode node) {
            var left = node.Left;
            var leftRight = left.Right;
            var parent = node.Parent;

            left.Parent = parent;
            left.Right = node;
            node.Left = leftRight;
            node.Parent = left;

            if (leftRight != null) {
                leftRight.Parent = node;
            }

            if (node == _root) {
                _root = left;
            } else if (parent.Left == node) {
                parent.Left = left;
            } else {
                parent.Right = left;
            }

            left.Balance--;
            node.Balance = -left.Balance;

            return left;
        }

        private AvlNode RotateLeftRight(AvlNode node) {
            var left = node.Left;
            var leftRight = left.Right;
            var parent = node.Parent;
            var leftRightRight = leftRight.Right;
            var leftRightLeft = leftRight.Left;

            leftRight.Parent = parent;
            node.Left = leftRightRight;
            left.Right = leftRightLeft;
            leftRight.Left = left;
            leftRight.Right = node;
            left.Parent = leftRight;
            node.Parent = leftRight;

            if (leftRightRight != null) {
                leftRightRight.Parent = node;
            }

            if (leftRightLeft != null) {
                leftRightLeft.Parent = left;
            }

            if (node == _root) {
                _root = leftRight;
            } else if (parent.Left == node) {
                parent.Left = leftRight;
            } else {
                parent.Right = leftRight;
            }

            switch (leftRight.Balance) {
                case -1:
                    node.Balance = 0;
                    left.Balance = 1;
                    break;
                case 0:
                    node.Balance = 0;
                    left.Balance = 0;
                    break;
                default:
                    node.Balance = -1;
                    left.Balance = 0;
                    break;
            }

            leftRight.Balance = 0;

            return leftRight;
        }

        private AvlNode RotateRightLeft(AvlNode node) {
            var right = node.Right;
            var rightLeft = right.Left;
            var parent = node.Parent;
            var rightLeftLeft = rightLeft.Left;
            var rightLeftRight = rightLeft.Right;

            rightLeft.Parent = parent;
            node.Right = rightLeftLeft;
            right.Left = rightLeftRight;
            rightLeft.Right = right;
            rightLeft.Left = node;
            right.Parent = rightLeft;
            node.Parent = rightLeft;

            if (rightLeftLeft != null) {
                rightLeftLeft.Parent = node;
            }

            if (rightLeftRight != null) {
                rightLeftRight.Parent = right;
            }

            if (node == _root) {
                _root = rightLeft;
            } else if (parent.Right == node) {
                parent.Right = rightLeft;
            } else {
                parent.Left = rightLeft;
            }

            switch (rightLeft.Balance) {
                case 1:
                    node.Balance = 0;
                    right.Balance = -1;
                    break;
                case 0:
                    node.Balance = 0;
                    right.Balance = 0;
                    break;
                default:
                    node.Balance = 1;
                    right.Balance = 0;
                    break;
            }

            rightLeft.Balance = 0;

            return rightLeft;
        }

        #endregion

        #region Delete Nodes

        public bool Delete(TKey key) {
            var node = _root;

            while (node != null) {
                if (key.CompareTo(node.Key) < 0) {
                    node = node.Left;
                } else if (key.CompareTo(node.Key) > 0) {
                    node = node.Right;
                } else {
                    var left = node.Left;
                    var right = node.Right;

                    if (left == null) {
                        if (right == null) {
                            if (node == _root) {
                                _root = null;
                            } else {
                                var parent = node.Parent;

                                if (parent.Left == node) {
                                    parent.Left = null;

                                    DeleteBalance(parent, -1);
                                } else {
                                    parent.Right = null;

                                    DeleteBalance(parent, 1);
                                }
                            }
                        } else {
                            Replace(node, right);

                            DeleteBalance(node, 0);
                        }
                    } else if (right == null) {
                        Replace(node, left);

                        DeleteBalance(node, 0);
                    } else {
                        var successor = right;

                        if (successor.Left == null) {
                            var parent = node.Parent;

                            successor.Parent = parent;
                            successor.Left = left;
                            successor.Balance = node.Balance;

                            left.Parent = successor;

                            if (node == _root) {
                                _root = successor;
                            } else {
                                if (parent.Left == node) {
                                    parent.Left = successor;
                                } else {
                                    parent.Right = successor;
                                }
                            }

                            DeleteBalance(successor, 1);
                        } else {
                            while (successor.Left != null) {
                                successor = successor.Left;
                            }

                            var parent = node.Parent;
                            var successorParent = successor.Parent;
                            var successorRight = successor.Right;

                            if (successorParent.Left == successor) {
                                successorParent.Left = successorRight;
                            } else {
                                successorParent.Right = successorRight;
                            }

                            if (successorRight != null) {
                                successorRight.Parent = successorParent;
                            }

                            successor.Parent = parent;
                            successor.Left = left;
                            successor.Balance = node.Balance;
                            successor.Right = right;
                            right.Parent = successor;

                            left.Parent = successor;

                            if (node == _root) {
                                _root = successor;
                            } else {
                                if (parent.Left == node) {
                                    parent.Left = successor;
                                } else {
                                    parent.Right = successor;
                                }
                            }

                            DeleteBalance(successorParent, -1);
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        private void DeleteBalance(AvlNode node, int balance) {
            while (node != null) {
                balance = (node.Balance += balance);

                if (balance == 2) {
                    if (node.Left.Balance >= 0) {
                        node = RotateRight(node);

                        if (node.Balance == -1) {
                            return;
                        }
                    } else {
                        node = RotateLeftRight(node);
                    }
                } else if (balance == -2) {
                    if (node.Right.Balance <= 0) {
                        node = RotateLeft(node);

                        if (node.Balance == 1) {
                            return;
                        }
                    } else {
                        node = RotateRightLeft(node);
                    }
                } else if (balance != 0) {
                    return;
                }

                var parent = node.Parent;

                if (parent != null) {
                    balance = parent.Left == node ? -1 : 1;
                }

                node = parent;
            }
        }

        private static void Replace(AvlNode target, AvlNode source) {
            var left = source.Left;
            var right = source.Right;

            target.Balance = source.Balance;
            target.Key = source.Key;
            target.Value = source.Value;
            target.Left = left;
            target.Right = right;

            if (left != null) {
                left.Parent = target;
            }

            if (right != null) {
                right.Parent = target;
            }
        }

        #endregion

        #region Search

        public bool Search(TKey key, out T value) {
            AvlNode node = _root;

            while (node != null) {
                if (key.CompareTo(node.Key) < 0) {
                    node = node.Left;
                } else if (key.CompareTo(node.Key) > 0) {
                    node = node.Right;
                } else {
                    value = node.Value;

                    return true;
                }
            }

            value = default(T);

            return false;
        }

        #endregion

        #region Clear
        public void Clear()
        {
            _root = null;
        }
        #endregion

        #region Enumerable

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator() {
            return new AvlNodeEnumerator(_root);
        }

        private sealed class AvlNodeEnumerator : IEnumerator<T> {
            private AvlNode _root;
            private Action _action;
            private AvlNode _current;
            private AvlNode _right;

            public AvlNodeEnumerator(AvlNode root) {
                _right = _root = root;
                _action = _root == null ? Action.End : Action.Right;
            }

            public bool MoveNext() {
                switch (_action) {
                    case Action.Right:
                        _current = _right;

                        while (_current.Left != null) {
                            _current = _current.Left;
                        }

                        _right = _current.Right;
                        _action = _right != null ? Action.Right : Action.Parent;

                        return true;

                    case Action.Parent:
                        while (_current.Parent != null) {
                            AvlNode previous = _current;

                            _current = _current.Parent;

                            if (_current.Left == previous) {
                                _right = _current.Right;
                                _action = _right != null ? Action.Right : Action.Parent;

                                return true;
                            }
                        }

                        _action = Action.End;

                        return false;

                    default:
                        return false;
                }
            }

            public void Reset() {
                _right = _root;
                _action = _root == null ? Action.End : Action.Right;
            }

            public T Current {
                get { return _current.Value; }
            }

            object IEnumerator.Current {
                get { return Current; }
            }

            public void Dispose() {}

            enum Action {
                Parent,
                Right,
                End
            }
        }

        #endregion
    }
}