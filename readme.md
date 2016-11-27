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

Standard sorting algorithms, working with an array as a source. Source values should be presented as
IComparable values.

#### Bobble

Simplest bobble sorting.
System goes through the array, comparing the sibling values. Every time when the first compared
value is bigger than second one, they should be switched. If no switches are performed after the
round, array is considered as fully sorted in ascending order.

The algorithm complexity is: O(n<sup>2</sup>)

#### Heap

#### Quick

Improved implementation of the bobble algorithm. 

On every step system performs the "sorting" of one array range. It takes the some value as a `pivot` (it's a value )
right in the middle of the range. Then system checks the left and right parts of the range trying to put all the
values bigger than `pivot` to the right half and all the values less than the `pivot` to the left part of the range.

So two indexes are running from the left border to the right and from the right border to the left until the left and 
right indexes are met. System compares the values on the left and right `index` places with the `pivot`. 

As soon as the value in the left part which is bigger than `pivot` is found, left index running is stopped. The 
left value for swapping is found. As soon as the value in the right part wich is smaller than `pivot` is
found, right index running is stopped - the right value for swapping is found. 
If both values for swapping are found - just swap them.
If only one value for swapping is found - swap it with the `pivot` value.

After they indexes are met, the new range from left border to the left index and new range from the right index
to the right border should be quick sorted.


So for example we have the range. 
Range size == 8, so pivot position is: 8/2 = 4. We take the value in the position 4.

| L | | |  | pivot | |    | R |
|-|-|
| 2 | 1 | 5 | 3 | 4 | 1 |  2 | 12 |

`leftIndex == 0`, `rightIndex == 7`

| L | | v | |  pivot |   | v | R |
|-|-|
| 2 | 1 | **5** | 3 | 4 | 1 |  **2** | 12 |

`5 > 4`, `2 < 4`
`leftIndex == 2`, `rightIndex == 6`

Swap the values

| L | | v|  | pivot | | v | R|
|-|-|
| 2 | 1 | **2** | 3 | 4 | 1 | **5** |  12 |

Move the indexes

`leftIndex = 3`, `rightIndex = 5`

Continue searching.

| L | | |  | pivot | v |  | R|
|-|-|
| 2 | 1 | 2 | 3 | 4 | **1** | 5 |  12 |

`leftIndex` hit the `pivot` value so it's stopped.
`rightIndex` hit the `1` which is less than the pivot value `4`.

So `leftIndex == 4` , `rightIndex == 5`.
Swap them and continue

| L | | |  |  |  |  | R|
|-|-|
| 2 | 1 | 2 | 3 | **1** | **4** | 5 |  12 |

`leftIndex == 5`, `rightIndex == 4`. Indexes met, so we stopped current step and continue sorting the sub-ranges.

| L1 | | pivot1 |  | R1 | L2 | pivot2 | R2 |
|-|-|
| 2 | 1 | **2** | 3 | 1 | 4 | 5 |  12 |

the right part of the range is already sorted, but second needs some swaps.


| v | |  |  | v | 
|-|-|
| **2** | 1 | **2** | 3 | **1**


|  | v |  | v |  | 
|-|-|
| **1** | 1 | **2** | 3 | **2**

and then both indexes meet the pivot

|  |  | vv |  |  | 
|-|-|
| 1 | 1 | **2** | 3 | 2

`indexLeft == 2`, `indexRight == 2`. Indexes are the same - we don't swap values,  but increment and
decrement the indexes, so `indexLeft == 3`, `indexRight == 1` - it's a time for the next step.

So we have just two sub-ranges: 1-1 and 3-2. They will be processed as well - left sub-range does not need any
changes, the right sub-range will have the values swaped.

#### Shell

It's the version of the insertion sort. It compares several items with given step. All the values which are bigger, than
the most right value in the list, will be moved one step right and the most right value will become the most left.

The main index moves from the left to right so every time we're sure that items in the list which are  at the left
position from the current item in the list are already sorted. That's why we need to find only right position to the
current item and the movement will keep the order.

Complexity: O(n<sup>2</sup>)

#### Selection

Simple sorting algorithm with complexity of O(n<sup>2</sup>). It uses the iterational method - if we expect that
the first element of the range is the bigest (smallest) one, we need just to sort the rest of the range in same
order to have the full sorted range. So we find the bigest (or smallest) element in the range, swap it with the 
first element of the range and repeat same operation with the sub-range, starting from second element.


#### Smooth

3 2 1
  2
main = 1

temp = 2
i = 1
a(i) = 2
a(i-1) = 3
a(i) = 3

i = 0
a(i) = temp

2 3 1
main = 2
temp = 1
1 < 3

i = 2
a(i) = 1
a(i-1) = 3
=> a(i) = a(i-1)
2 3 3

i = 1
a(i) = 3
a(i-1) = 2
2 > 1 => a(i) = a(i-1)
2 2 3

i = 0
a(i) = temp