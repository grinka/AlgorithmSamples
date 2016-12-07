using System;

namespace AlgorithmSamples.BinaryTreeBalanced.RedBlackTree {

    #region Public Enums
    /// <summary>
    /// Represents the node color - red or black.
    /// </summary>
    public enum NodeColor {
        Red,
        Black
    }

    /// <summary>
    /// Represents the node operation result status.
    /// </summary>
    public enum NodeOperationStatus {
        Ok = 0,
        NotFound = 1,
        DuplicateKey = 2
    }
    #endregion


    public class RedBlackTree<T, TKey> where TKey: IComparable {
        #region Local fields
        /// <summary>
        /// Root node of the tree.
        /// </summary>
        private RedBlackNode<T> Root { get; set; }

        /// <summary>
        /// The sentinel nill node, used to identify empty leafs and empty root node.
        /// </summary>
        private readonly RedBlackNode<T> Nil;

        /// <summary>
        /// Function which allows to get the key value based on the data value.
        /// </summary>
        private readonly Func<T, TKey> _compareFunc;
        #endregion

        #region Constructors
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
        #endregion

        #region Utility Methods

        #region Keys manipulation
        /// <summary>
        /// Compares two keys if they are equal.
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <returns>True if keys are equal.</returns>
        private static bool CompareEq(IComparable key1, IComparable key2)
        {
            return key1.CompareTo(key2) == 0;
        }

        /// <summary>
        /// Compares two keys if the first key is less than second one.
        /// </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        /// <returns>True if the first key is smaller than second one.</returns>
        private static bool CompareLt(IComparable key1, IComparable key2)
        {
            return key1.CompareTo(key2) < 0;
        }
        #endregion

        #region Nodes manipulation
        /// <summary>
        /// Rotate the node subtree to the left.
        /// </summary>
        /// <param name="node">Parent node of the subtree.</param>
        public void RotateLeft(RedBlackNode<T> node) {
            var rightChild = node.Right;
            node.Right = rightChild.Left;
            if (rightChild.Left != Nil) {
                rightChild.Left.Parent = node;
            }

            /* Establish child.Parent link */
            if (rightChild != Nil) {
                rightChild.Parent = node.Parent;
            }

            if (node.Parent != null) {
                if (node.IsLeftNode()) {
                    node.Parent.Left = rightChild;
                } else {
                    node.Parent.Right = rightChild;
                }
            } else {
                Root = rightChild;
            }

            /* link node and child node */
            rightChild.Left = node;
            if (node != Nil) {
                node.Parent = rightChild;
            }
        }

        /// <summary>
        /// Rotate the node subtree to the right.
        /// </summary>
        /// <param name="node">The parent node of the subtree.</param>
        public void RotateRight(RedBlackNode<T> node) {
            var leftChild = node.Left;
            if (leftChild.Right != Nil) {
                leftChild.Right.Parent = node;
            }

            /* establish child.parent link */
            if (leftChild != Nil) {
                leftChild.Parent = node.Parent;
            }

            if (node.Parent != null) {
                if (node.IsRightNode()) {
                    node.Parent.Right = leftChild;
                } else {
                    node.Parent.Left = leftChild;
                }
            } else {
                Root = leftChild;
            }

            /* link node and child node */
            leftChild.Right = node;
            if (node != Nil) {
                node.Parent = leftChild;
            }
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
        /// Maintain red-blue balance after deleting the node.
        /// </summary>
        /// <param name="x"></param>
        public void DeleteFixup(RedBlackNode<T> x)
        {
            /*
             * maintain red-blackk tree after deleting a note
             */
            while (x != Root && x.Color == NodeColor.Black)
            {
                if (x == x.Parent.Left)
                {
                    var w = x.Parent.Right;
                    if (w.Color == NodeColor.Red)
                    {
                        w.Color = NodeColor.Black;
                        x.Parent.Color = NodeColor.Red;
                        RotateLeft(x.Parent);
                        w = x.Parent.Right;
                    }

                    if (w.Left.Color == NodeColor.Black && w.Right.Color == NodeColor.Black)
                    {
                        w.Color = NodeColor.Red;
                        x = x.Parent;
                    }
                    else
                    {
                        if (x.Right.Color == NodeColor.Black)
                        {
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
                }
                else
                {
                    var w = x.Parent.Left;
                    if (w.Color == NodeColor.Red)
                    {
                        x.Color = NodeColor.Black;
                        x.Parent.Color = NodeColor.Red;
                        RotateRight(x.Parent);
                        w = x.Parent.Left;
                    }

                    if (w.Right.Color == NodeColor.Black && w.Left.Color == NodeColor.Black)
                    {
                        w.Color = NodeColor.Red;
                        x = x.Parent;
                    }
                    else
                    {
                        if (w.Left.Color == NodeColor.Black)
                        {
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
        #endregion

        #region Display Tree Nodes
        /// <summary>
        /// Concatenate the node string representation to the tree string representation.
        /// Recursively called for all descendant nodes.
        /// </summary>
        /// <param name="levels">Array of tree strings - one string for each level, starting from root.</param>
        /// <param name="currentLevel">Level of the current node.</param>
        /// <param name="node">The node object.</param>
        private void AddNodeViewToLevel(string[] levels, int currentLevel, RedBlackNode<T> node)
        {
            var strLevel = levels[currentLevel] ?? $"{currentLevel} > ";
            strLevel += NodeView(node);

            levels[currentLevel] = strLevel;
            if (node != Nil)
            {
                AddNodeViewToLevel(levels, currentLevel + 1, node.Left);
                AddNodeViewToLevel(levels, currentLevel + 1, node.Right);
            }
        }

        /// <summary>
        /// Returns the string representation of the one node.
        /// </summary>
        /// <param name="node">Node object to be displayed.</param>
        /// <returns>String representing the node data. Displays the node value or "Nill" for the nill nodes in
        /// parentles for black and double parentless for red nodes.</returns>
        private string NodeView(RedBlackNode<T> node)
        {
            var strData = node == Nil ? "Nil" : node.Value.ToString();
            return node.Color == NodeColor.Black ? $" ({strData}) " : $" (({strData})) ";
        }
        #endregion
        #endregion

        #region Public Methods - Tree Manipulation

        public void Insert(T[] values) {
            foreach (var value in values) {
                Insert(value);
            }
        }

        /// <summary>
        /// Insert the node into tree.
        /// </summary>
        /// <param name="value"></param>
        public NodeOperationStatus Insert(T value) {
            var current = Root;
            var keyValue = _compareFunc(value);
            RedBlackNode<T> parent = null;

            /* find the parent */
            while (current != Nil) {
                if (CompareEq(keyValue, current.ItemKey)) {
                    return NodeOperationStatus.DuplicateKey;
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
            return NodeOperationStatus.Ok;
        }

        /// <summary>
        /// Delete the node from the tree found by the key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public NodeOperationStatus Delete(TKey key) {
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
                return NodeOperationStatus.NotFound;
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

            return NodeOperationStatus.Ok;
        }

        /// <summary>
        /// Find the node in the tree by the key.
        /// </summary>
        /// <param name="key">The data key.</param>
        /// <returns>The node with given key. Null if node is not found.</returns>
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
        #endregion

        public void DisplayTree() {
            var allLevels = new string[20];
            AddNodeViewToLevel(allLevels, 0, Root);
            foreach (var strLevel in allLevels) {
                if (!string.IsNullOrEmpty(strLevel)) {
                    Console.WriteLine(strLevel);
                }
            }
        }
    }
}