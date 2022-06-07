using System;

namespace Helppad.Algorithms
{
    /// <summary>
    /// This class contains sorting algorithms.
    /// </summary>
    public class Sorts
    {
        /// <summary>
        /// This method sorts an array using the bubble sort algorithm.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }

                }
            }
        }

        /// <summary>
        /// This method sorts an array using the selection sort algorithm.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                int temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
        }

        /// <summary>
        /// This method sorts an array using the insertion sort algorithm.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j] < array[j - 1])
                {
                    int temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                    j--;
                }
            }
        }
    }
}
