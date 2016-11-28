using System;
using System.Data.SqlTypes;

namespace AlrogithmSamples.BinaryTreeBalanced {

    public enum NodeColor {
        Red,
        Black
    }

    public class RedBlackTree<T> where T: INullable{
        private RedBlackNode<T> Root { get; set; }
        private readonly RedBlackNode<T> Nil;
        private readonly Func<T, IComparable> _compareFunc;

        public RedBlackTree(Func<T, IComparable> compareFunc) {
            _compareFunc = compareFunc;
            Nil = new RedBlackNode<T>();
            Nil.Right = Nil;
            Nil.Left = Nil;
            Nil.Parent = null;
            Nil.Color = NodeColor.Black;
            Nil.Count = 0;

            Root = Nil;
        }

        public void RotateLeft(RedBlackNode<T> x) {
            RedBlackNode<T> y = x.Right;
            x.Right = y.Left;
            if (y.Left != Nil) {
                y.Left.Parent = x;
            }

            /* Establish y.Parent link */
            if (y != Nil) {
                y.Parent = x.Parent;
            }

            if (x.Parent != null) {
                if (x == x.Parent.Left) {
                    x.Parent.Left = y;
                } else {
                    x.Parent.Right = y;
                }
            } else {
                Root = y;
            }

            /* link x and y */
            y.Left = x;
            if (x != Nil) {
                x.Parent = y;
            }
        }

        public void RotateRight(RedBlackNode<T> x) {
            var y = x.Left;
            /* establish x.left link */
            if (y.Right != Nil) {
                y.Right.Parent = x;
            }

            /* establish y.parent link */
            if (y != Nil) {
                y.Parent = x.Parent;
            }

            if (x.Parent != null) {
                if (x == x.Parent.Right) {
                    x.Parent.Right = y;
                } else {
                    x.Parent.Left = y;
                }
            } else {
                Root = y;
            }

            /* link x and y */
            y.Right = x;
            if (x != Nil) {
                x.Parent = y;
            }
        }


        private static bool CompareEq(IComparable key1, IComparable key2) {
            return key1.CompareTo(key2) == 0;
        }

        private static bool CompareLt(IComparable key1, IComparable key2) {
            return key1.CompareTo(key2) < 0;
        }

        private bool CompareEq(RedBlackNode<T> node1, RedBlackNode<T> node2) {
            return CompareEq(node1.ItemKey, node2.ItemKey);
        }

        /// <summary>
        /// Compares two items using the values, retrieved by the compare function.
        /// </summary>
        /// <param name="item1">First item to be compared.</param>
        /// <param name="item2">Second item to be compared.</param>
        /// <returns>true if the comparable value of the first item is smaller than the 
        /// comparable value of the second second.</returns>
        private bool IsSmaller(T item1, T item2) {
            return (_compareFunc(item1).CompareTo(_compareFunc(item2)) < 0);
        }

        /// <summary>
        /// Compares two items using the values, retrieved by the compare function.
        /// </summary>
        /// <param name="item1">First item to be compared.</param>
        /// <param name="item2">Second item to be compared.</param>
        /// <returns>true if the comparable value of the first item is equal to the
        /// comparable value of the second second.</returns>
        private bool IsEqual(T item1, T item2) {
            return (_compareFunc(item1).CompareTo(_compareFunc(item2)) == 0);
        }

        /// <summary>
        /// Maintain red-blue balance after adding the new node.
        /// </summary>
        /// <param name="x">The node has been added.</param>
        private void InsertFixup(RedBlackNode<T> x) {
            /* check red-black properties */
            while (x != Root && x.Parent.Color == NodeColor.Red) {
                if (x.Parent == x.Parent.Parent.Left) {
                    var y = x.Parent.Parent.Right;
                    if (y.Color == NodeColor.Red) {
                        // uncle is red
                        x.Parent.Color = NodeColor.Black;
                        y.Color = NodeColor.Black;
                        x.Parent.Parent.Color = NodeColor.Red;
                        x = x.Parent.Parent;
                    } else {
                        // uncle is black
                        if (x == x.Parent.Right) {
                            // make x a left child
                            x = x.Parent;
                            RotateLeft(x);
                        }

                        /* recolor and rotate */
                        x.Parent.Color = NodeColor.Black;
                        x.Parent.Parent.Color = NodeColor.Red;
                        RotateRight(x.Parent.Parent);
                    }
                } else {
                    var y = x.Parent.Parent.Left;
                    if (y.Color == NodeColor.Red)
                    {
                        // uncle is red
                        x.Parent.Color = NodeColor.Black;
                        y.Color = NodeColor.Black;
                        x.Parent.Parent.Color = NodeColor.Red;
                        x = x.Parent.Parent;
                    }
                    else
                    {
                        // uncle is black
                        if (x == x.Parent.Left)
                        {
                            // make x a left child
                            x = x.Parent;
                            RotateRight(x);
                        }

                        /* recolor and rotate */
                        x.Parent.Color = NodeColor.Black;
                        x.Parent.Parent.Color = NodeColor.Red;
                        RotateLeft(x.Parent.Parent);
                    }
                }
            }
            Root.Color = NodeColor.Black;
        }

        /// <summary>
        /// Insert the node into tree.
        /// </summary>
        /// <param name="value"></param>
        public void Insert(T value) {
            var current = Root;
            var keyValue = _compareFunc(value);
            RedBlackNode<T> parent = null;

            /* find the parent */
            while (current != Nil) {
                parent = current;
                current = CompareLt(keyValue, current.ItemKey) ? current.Left : current.Right;
            }

            /* create new node */
            var x = new RedBlackNode<T>(value, keyValue, parent) {
                Left = Nil,
                Right = Nil,
                Color = NodeColor.Red
            };

            /* insert node to the tree */
            if (parent != null) {
                if (CompareLt(keyValue, parent.ItemKey)) {
                    parent.Left = x;
                } else {
                    parent.Right = x;
                }
            } else {
                Root = x;
            }

            InsertFixup(x);
        }
    }
}