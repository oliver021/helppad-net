using System;
using System.Collections.Generic;

namespace Helppad.Tree
{
    /// <summary>
    /// Contains the methods to manipulate a the trees structure.
    /// </summary>
    public static class TreeExplorer {

        /// <summary>
        /// This method allow explore the tree.
        /// Specify this recieve a tree and a function that will be executed on each node.
        /// </summary>
        /// <param name="tree">The tree to explore.</param>
        /// <param name="func">The function to execute on each node.</param>
        public static void Explore<T>(BinaryTree<T> tree, Func<BinaryTreeNode<T>, BinaryTreeNode<T>, BinaryTreeNode<T>> func)
        {
            // validate if the tree is null
            if (tree == null)
            {
                throw new ArgumentNullException(nameof(tree));
            }

            // validate if the function is null
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }

            do {
                // call
                tree = func.Invoke(tree.Left, tree.Right);

                // condition to continue the loop
            } while(tree.Left != null && tree.Right != null);
        }
    }
}