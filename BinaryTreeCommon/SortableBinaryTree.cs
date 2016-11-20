namespace AlgorithmSamples.BinaryTreeCommon
{
    public abstract class SortableBinaryTree<T> {
        protected ISortableNode<T> RootNode;

        public T[] SortedAscending => RootNode.SortedAscending;
        public T[] SortedDescending => RootNode.SortedDescending;

        public void AddValue(T value) {
            if (RootNode == null) {
                RootNode = CreateRootNode(value);
            } else {
                RootNode.AddValue(value);
            }
        }

        protected abstract ISortableNode<T> CreateRootNode(T value);
    }
}
