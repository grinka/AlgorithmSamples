# AlgorithmSamples

## Main purpose

This projects demonstrates the different programming algorithms.

## Alrogithms used

### Binary Trees

Implementation of Binary trees.
Each node of the tree may have two child nodes - node with less weight goes left and
node with same or bigger weight goes right. The nodes position is found when the tree
is being created - each new node with value added to the corresponding place.

Contains two groups of trees - balanced and unbalanced. 

#### Unbalanced binary tree

Each node is added "as is" without additional tree rearrangement. Nodes are added in the order
how they presented in the source.

We present two types of such trees

- comparable: where each tree node has the  value of comparable type, so two node can be compared their value.
- uncomparable: where each tree node has the object value and two nodes can be compared
    using the comparing function, which can represent one value property or any function of
    the value object.

In both cases new nodes, added to the tree are put into their "place" accordingly
to their comparable weight.

#### Balanced binary tree

Should contain the implementation of the binary tree with automatic balancing - 
the longest path of the left and right descendants of each the node should not differ on
more than 1.

### Sorting

Standard sorting algorithms, working with an array as a source. Source values may be presented as
comparable values or as an objects with comparing functions assigned.

#### Bobble

Simplest bobble sorting.
System goes through the array, comparing the sibling values. Every time when the first compared
value is bigger than second one, they should be switched. If no switches are performed after the
round, array is considered as fully sorted in ascending order.

The algorithm complexity is: O(n2)

#### Heap

#### Quick

#### Shell

#### Smooth

