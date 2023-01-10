using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helppad.Linq
{
    /// <summary>
    /// TThe binary tree class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T>
    {
        /// <summary>
        /// basic value for this instance.
        /// </summary>
        public T Value { get; set; }
        
        /// <summary>
        /// The left node.
        /// </summary>
        public BinaryTree<T> Left { get; set; }

        /// <summary>
        /// The right node.
        /// </summary>
        public BinaryTree<T> Right { get; set; }
    }

    /// <summary>
    /// Extensions for tree using linq.
    /// </summary>
    public static partial class TreeExtensions
    {
        /// <summary>
        /// 
        /// This method uses a recursive approach to convert the input sequence
        /// into a binary tree structure. It selects the first element of the
        /// input sequence as the root node of the tree, and uses the predicate 
        /// function to split the remaining elements into two branches: the left 
        /// branch containing the elements that do not satisfy the predicate,
        /// and the right branch containing the elements that satisfy the predicate.
        /// It then recursively converts these branches into binary trees
        /// using the same approach, until the input sequence is exhausted.
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static BinaryTree<T> ToBinaryTree<T>(IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            // Check if the input sequence is empty
            if (!enumerable.Any())
            {
                return null;
            }

            // Select the first element of the input sequence as the root node
            T value = enumerable.First();
            BinaryTree<T> root = new BinaryTree<T>() { Value = value };

            // Recursively convert the left and right branches of the tree
            IEnumerable<T> leftBranch = enumerable.Skip(1).Where(x => !predicate(x));
            IEnumerable<T> rightBranch = enumerable.Skip(1).Where(predicate);
            root.Left = ToBinaryTree(leftBranch, predicate);
            root.Right = ToBinaryTree(rightBranch, predicate);

            return root;
        }
    }
}
