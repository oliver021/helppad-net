using System;
using System.Collections.Generic;

namespace Helppad.Algorithms
{
    /// <summary>
    /// This class contains matrix algorithms.
    /// </summary>
    public class Matrix
    {
        /// <summary>
        /// This method returns the transpose of a matrix.
        /// </summary>
        /// <param name="matrix">The matrix to transpose.</param>
        /// <returns>The transpose of the matrix.</returns>
        public static int[,] Transpose(int[,] matrix)
        {
            int[,] transpose = new int[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    transpose[j, i] = matrix[i, j];
                }
            }
            
            return transpose;
        }

        /// <summary>
        /// This method returns the determinant of a matrix.
        /// </summary>
        /// <param name="matrix">The matrix to calculate the determinant of.</param>
        /// <returns>The determinant of the matrix.</returns>
        public static int Determinant(int[,] matrix)
        {
            int determinant = 0;

            // Check if the matrix is square.
            if (matrix.GetLength(0) == 2)
            {
                // Calculate the determinant.
                determinant = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

                return determinant;
            }

            // Calculate the determinant of the submatrix.
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[,] subMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];

                for (int j = 1; j < matrix.GetLength(0); j++)
                {
                    for (int k = 0; k < matrix.GetLength(0); k++)
                    {
                        /* If the current row is not the row to be removed*/
                        /* copy the values from the original matrix to the submatrix. */
                        if (k < i)
                        {
                            subMatrix[j - 1, k] = matrix[j, k];
                        }

                        if (k > i)
                        {
                            subMatrix[j - 1, k - 1] = matrix[j, k];
                        }
                    }
                }

                // Calculate the determinant of the submatrix.
                determinant += (int)System.Math.Pow(-1, i) * matrix[0, i] * Determinant(subMatrix);
            }

            return determinant;
        }

        /// <summary>
        /// This method returns the inverse of a matrix.
        /// </summary>
        /// <param name="matrix">The matrix to calculate the inverse of.</param>
        /// <returns>The inverse of the matrix.</returns>
        public static int[,] Inverse(int[,] matrix)
        {
            int[,] inverse = new int[matrix.GetLength(0), matrix.GetLength(1)];

            // Calculate the determinant of the matrix.
            int determinant = Determinant(matrix);

            // Check if the matrix is invertible.
            if (determinant == 0)
            {
                throw new Exception("The matrix is not invertible.");
            }

            // Calculate the inverse of the matrix.
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int[,] subMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];

                    for (int k = 1; k < matrix.GetLength(0); k++)
                    {
                        /* If the current row is not the row to be removed*/
                        /* copy the values from the original matrix to the submatrix. */
                        if (k < i)
                        {
                            subMatrix[j - 1, k - 1] = matrix[j, k];
                        }

                        if (k > i)
                        {
                            subMatrix[j - 1, k - 1] = matrix[j, k];
                        }

                        if (k == i)
                        {
                            subMatrix[j - 1, k - 1] = 0;
                        }
                    }

                    // Calculate the determinant of the submatrix.
                    int subDeterminant = Determinant(subMatrix);

                    // Calculate the inverse of the submatrix.
                    inverse[j, i] = (int)System.Math.Pow(-1, i + j) * subDeterminant;
                }
            }

            return inverse;
        }

        /// <summary>
        /// This method returns array of sums of rows of a matrix.
        /// </summary>
        /// <param name="matrix">The matrix to calculate the sums of rows of.</param>
        /// <returns>Dictionary<int,int> -> {index, sum}</returns>
        public static Dictionary<int, int> SumOfRows(int[,] matrix)
        {
            Dictionary<int, int> sums = new Dictionary<int, int>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }

                sums.Add(i, sum);
            }

            return sums;
        }

        /// <summary>
        /// This method returns array of sums of columns of a matrix.
        /// </summary>
        /// <param name="matrix">The matrix to calculate the sums of columns of.</param>
        /// <returns>Dictionary<int,int> -> {index, sum}</returns>
        public static Dictionary<int, int> SumOfColumns(int[,] matrix)  
        {
            Dictionary<int, int> sums = new Dictionary<int, int>();

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sum = 0;

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sum += matrix[j, i];

                }

                sums.Add(i, sum);
            }

            return sums;
        }

        /// <summary>
        /// Calculates the euclidean distance between 2 matrices.
        /// </summary>
        /// <param name="matrix1">The first matrix.</param>
        /// <param name="matrix2">The second matrix.</param>
        /// <returns>The euclidean distance between the two matrices.</returns>
        public static double EuclideanDistance(int[,] matrix1, int[,] matrix2)
        {
            double distance = 0;

            // Check if the matrices are of the same size.
            ShouldBeSameShape(matrix1, matrix2);

            // Calculate the euclidean distance.
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    distance += System.Math.Pow(matrix1[i, j] - matrix2[i, j], 2);
                }
            }

            return System.Math.Sqrt(distance);
        }


        /// <summary>
        /// This method validate if the matrices are of the same shape.
        /// </summary>
        /// <param name="matrix">The matrix to transpose.</param>
        /// <returns>The transpose of the matrix.</returns>
        /// <exception cref="Exception">Thrown when the matrix is not square.</exception>
        public static void ShouldBeSameShape(int[,] matrix1, int[,] matrix2)
        {
            // Check if the matrices are of the same size.
            if (matrix1.GetLength(0) != matrix2.GetLength(0) || matrix1.GetLength(1) != matrix2.GetLength(1))
            {
                throw new Exception("The matrices are not of the same size.");
            }
        }

        /// <summary>
        /// This method return true if the matrix is square.
        /// </summary>
        /// <param name="matrix">The matrix to check.</param>
        /// <returns>True if the matrix is square.</returns>
        public static bool IsSquare(int[,] matrix)
        {
            return matrix.GetLength(0) == matrix.GetLength(1);
        }

        /// <summary>
        /// This method return true if the matrix is symmetric.
        /// </summary>
        /// <param name="matrix">The matrix to check.</param>
        /// <returns>True if the matrix is symmetric.</returns>
        public static bool IsSymmetric(int[,] matrix)
        {
            // Check if the matrix is square.
            if (!IsSquare(matrix))
            {
                return false;
            }

            // Check if the matrix is symmetric.
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != matrix[j, i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// This method return true if the matrix is upper triangular.
        /// </summary>
        /// <param name="matrix">The matrix to check.</param>
        /// <returns>True if the matrix is upper triangular.</returns>
        public static bool IsUpperTriangular(int[,] matrix)
        {
            // Check if the matrix is square.
            if (!IsSquare(matrix))
            {
                return false;
            }

            // Check if the matrix is upper triangular.
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i > j && matrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// This method return true if the matrix is lower triangular.
        /// </summary>
        /// <param name="matrix">The matrix to check.</param>
        /// <returns>True if the matrix is lower triangular.</returns>
        public static bool IsLowerTriangular(int[,] matrix)
        {
            // Check if the matrix is square.
            if (!IsSquare(matrix))
            {
                return false;
            }

            // Check if the matrix is lower triangular.
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i < j && matrix[i, j] != 0){
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// This method return true if the matrix is diagonal.
        /// </summary>
        /// <param name="matrix">The matrix to check.</param>
        /// <returns>True if the matrix is diagonal.</returns>
        public static bool IsDiagonal(int[,] matrix)
        {
            // Check if the matrix is square.
            if (!IsSquare(matrix))
            {
                return false;
            }

            // Check if the matrix is diagonal.

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != j && matrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}