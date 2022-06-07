using System;

namespace Helppad.Tree
{
    /// <summary>
    /// This class represent a node in a binary tree.
    /// The binary tree is a tree in which each node has at most two children.
    /// This class offer one implementation of this strcture.
    public class BinaryTree<T>
    {
        /// <summary>
        /// The value of the node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The left of the tree.
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }

        /// <summary>
        /// The right of the tree.
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        /// <summary>
        /// Access the height of the tree.
        /// </summary>
        public int Height => GetHeight(this);

        /// <summary>
        /// The constructor of the class.
        /// </summary>
        /// <param name="value">The value of the node.</param>
        public BinaryTree(T value)
        {
            this.Value = value;
        }

        /// <summary>
        /// The constructor of the class.
        /// </summary>
        /// <param name="value">The value of the node.</param>
        /// <param name="left">The left of the tree.</param>
        /// <param name="right">The right of the tree.</param>
        public BinaryTree(T value, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        /// <summary>
        /// This method return the height of the tree.
        /// </summary>
        /// <returns>The height of the tree.</returns>
        public int GetHeight()
        {
            // calculate the height of the left and right subtrees
            int leftHeight = 0;

            if (this.Left != null)
            {
                leftHeight = this.Left.GetHeight();
            }

            int rightHeight = 0;

            if (this.Right != null)
            {
                rightHeight = this.Right.GetHeight();
            }

            // return the max between the left and right subtrees
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        /// <summary>
        /// This method return the depth of the tree.
        /// </summary>
        /// <returns>The depth of the tree.</returns>
        public int GetDepth()
        {
            int depth = 0;

            // call internal method to calculate the depth
            ComputeDepth(ref depth);

            return depth;
        }

        /// <summary>
        /// This method calculate the depth tree.
        /// </summary>
        /// <param name="currentDepth">The current depth counter.</param>
        /// <returns>The depth of the node in the tree.</returns>
        internal void ComputeDepth(ref int currentDepth)
        {
            currentDepth += 1;
            int leftDepth = 0;
            int rightDepth = 0;

            // if the left is not null, call the method recursively
            if (this.Left != null)
            {
                this.Left.GetDepth(ref leftDepth);
            }

            // if the right is not null, call the method recursively
            if (this.Right != null)
            {
                this.Right.GetDepth(ref rightDepth);
            }

            // if left is greater than right, sum to the current depth, otherwise sum to the right depth
            if (leftDepth > rightDepth)
            {
                currentDepth += leftDepth;
            }else{
                currentDepth += rightDepth;
            }
        }

        /// <summary>
        /// This override the ToString method.
        /// </summary>
        /// <returns>The string representation of the tree.</returns>
        public override string ToString()
        {
            // string with that show if value is set and subtrees
            string result = "";

            if (this.Value != null)
            {
                result += "value: is set;";
            }

            if (this.Left != null)
            {
                result += "left: is set;";
            }

            if (this.Right != null)
            {
                result += "right: is set;";
            }

            return result;
        }
    }
}
