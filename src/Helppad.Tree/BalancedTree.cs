using System;
using System.Collections.Generic;

namespace Helppad.Tree
{
    /// <summary>
    /// Contains the methods to manipulate a balanced tree.
    /// </summary>
    public static class BalancedTree
    {
        /// <summary>
        /// This method validate if the tree is balanced.
        /// </summary>
        /// <param name="tree">The tree to validate.</param>
        /// <returns>True if the tree is balanced, false otherwise.</returns>
        public static bool IsBalanced<T>(BinaryTree<T> tree)
        {
            // validate if the tree is null
            if (tree == null)
            {
                throw new ArgumentNullException(nameof(tree));
            }

            // validate if the tree is empty
            if (tree.Left == null && tree.Right == null)
            {
                return true;
            }

            // calculate the height of the left and right subtrees
            int leftHeight = GetHeight(tree.Left);
            int rightHeight = GetHeight(tree.Right);

            // validate if the difference between the left and right subtrees is less than or equal to 1
            return Math.Abs(leftHeight - rightHeight) <= 1;
        }
    }

    /// <summary>
    /// This class represent a node in a balanced binary tree.
    /// A balanced binary tree is a binary tree in which the depth
    /// of the two subtrees of every node never differ by more than one.
    /// This class offer one implementation of this strcture.
    /// </summary>
    public class BalancedTree<T> : BinaryTree<T>
    {
        /// <summary>
        /// The constructor of the class.
        /// </summary>
        /// <param name="value">The value of the node.</param>
        public BalancedTree(T value) : base(value)
        {}

        /// <summary>
        /// The constructor of the class.
        /// </summary>
        /// <param name="value">The value of the node.</param>
        /// <param name="left">The left of the tree.</param>
        /// <param name="right">The right of the tree.</param>
        public BalancedTree(T value, BinaryTreeNode<T> left, BinaryTreeNode<T> right) : base(value, left, right)
        {}
    }
}