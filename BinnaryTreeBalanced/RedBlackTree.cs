using System;
using System.Data.SqlTypes;

namespace AlrogithmSamples.BinaryTreeBalanced {

    public enum NodeColor {
        Red,
        Black
    }

    public enum DeleteStatus {
        Ok = 0,
        NotFound = 1
    }

    public enum InsertNodeStatus {
        Ok = 0,
        DuplicateKey = 1
    }


    public class RedBlackTree<T, TKey> where TKey: IComparable {
        private RedBlackNode<T> Root { get; set; }
        private readonly RedBlackNode<T> Nil;
        private readonly Func<T, TKey> _compareFunc;

        public RedBlackTree(Func<T, TKey> compareFunc) {
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
            var y = x.Right;
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
        public InsertNodeStatus Insert(T value) {
            var current = Root;
            var keyValue = _compareFunc(value);
            RedBlackNode<T> parent = null;

            /* find the parent */
            while (current != Nil) {
                if (CompareEq(keyValue, current.ItemKey)) {
                    return InsertNodeStatus.DuplicateKey;
                }
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
            return InsertNodeStatus.Ok;
        }

        public void DeleteFixup(RedBlackNode<T> x) {
            /*
             * maintain red-blackk tree after deleting a note
             */
            while (x != Root && x.Color == NodeColor.Black) {
                if (x == x.Parent.Left) {
                    var w = x.Parent.Right;
                    if (w.Color == NodeColor.Red) {
                        w.Color = NodeColor.Black;
                        x.Parent.Color = NodeColor.Red;
                        RotateLeft(x.Parent);
                        w = x.Parent.Right;
                    }

                    if (w.Left.Color == NodeColor.Black && w.Right.Color == NodeColor.Black) {
                        w.Color = NodeColor.Red;
                        x = x.Parent;
                    } else {
                        if (x.Right.Color == NodeColor.Black) {
                            w.Left.Color = NodeColor.Black;
                            w.Color = NodeColor.Red;
                            RotateRight(w);
                            w = x.Parent.Right;
                        }

                        w.Color = x.Parent.Color;
                        x.Parent.Color = NodeColor.Black;
                        w.Right.Color = NodeColor.Black;
                        RotateLeft(x.Parent);
                        x = Root;
                    }
                } else {
                    var w = x.Parent.Left;
                    if (w.Color == NodeColor.Red) {
                        x.Color = NodeColor.Black;
                        x.Parent.Color = NodeColor.Red;
                        RotateRight(x.Parent);
                        w = x.Parent.Left;
                    }

                    if (w.Right.Color == NodeColor.Black && w.Left.Color == NodeColor.Black) {
                        w.Color = NodeColor.Red;
                        x = x.Parent;
                    } else {
                        if (w.Left.Color == NodeColor.Black) {
                            w.Right.Color = NodeColor.Black;
                            w.Color = NodeColor.Red;
                            RotateLeft(w);
                            w = x.Parent.Left;
                        }

                        w.Color = x.Parent.Color;
                        x.Parent.Color = NodeColor.Black;
                        w.Left.Color = NodeColor.Black;
                        RotateRight(x.Parent);
                        x = Root;
                    }
                }
            }

            x.Color = NodeColor.Black;
        }

        public DeleteStatus Delete(TKey key) {
            RedBlackNode<T> x, y;
            
            /* delete node z from the tree */
            /* find node in the tree */
            var z = Root;
            while (z != Nil) {
                if (CompareEq(key, z.ItemKey)) {
                    break;
                }
                z = CompareLt(key, z.ItemKey) ? z.Left : z.Right;
            }

            if (z == Nil) {
                return DeleteStatus.NotFound;
            }

            if (z.Left == Nil || z.Right == Nil) {
                /* y has a NIL node as a child */
                y = z;
            } else {
                /* find tree successor with a NIL node as a child */
                y = z.Right;
                while (y.Left != Nil) {
                    y = y.Left;
                }
            }

            /* x is y's only child */
            if (y.Left != Nil) {
                x = y.Left;
            } else {
                x = y.Right;
            }

            /* remove y from the parent chain */
            x.Parent = y.Parent;
            if (y.Parent != null) {
                if (y == y.Parent.Left) {
                    y.Parent.Left = x;
                } else {
                    y.Parent.Right = x;
                }
            } else {
                Root = x;
            }

            if (y != z) {
                z.ItemKey = y.ItemKey;
                z.Value = y.Value;
            }

            if (y.Color == NodeColor.Black) {
                DeleteFixup(x);
            }

            return DeleteStatus.Ok;
        }

        public RedBlackNode<T> Find(TKey key) {
            var current = Root;
            while (current != Nil) {
                if (CompareEq(key, current.ItemKey)) {
                    return current;
                }
                current = CompareLt(key, current.ItemKey) ? current.Left : current.Right;
            }
            return null;
        }

        public void DisplayTree() {
            var allLevels = new string[20];
            AddNodeViewToLevel(allLevels, 0, Root);
            foreach (var strLevel in allLevels) {
                if (!string.IsNullOrEmpty(strLevel)) {
                    Console.WriteLine(strLevel);
                }
            }
        }

        private void AddNodeViewToLevel(string[] levels, int currentLevel, RedBlackNode<T> node) {
            var strLevel = levels[currentLevel] ?? $"{currentLevel} > ";
            strLevel += NodeView(node);

            levels[currentLevel] = strLevel;
            if (node != Nil) {
                AddNodeViewToLevel(levels, currentLevel+1, node.Left);
                AddNodeViewToLevel(levels, currentLevel+1, node.Right);
            }
        }

        private string NodeView(RedBlackNode<T> node) {
            var strData = node == Nil ? "Nil" : node.Value.ToString();
            return node.Color == NodeColor.Black ? $" ({strData}) " : $" (({strData})) ";
        }
    }
}