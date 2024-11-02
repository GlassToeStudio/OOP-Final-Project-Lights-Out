namespace LightsOut
{
    internal class Solver
    {
        internal static int[] GetSolutionMatrix(LevelData levelData)
        {
            var kernal = CreateMatrix(levelData);
            return SolveMatrix(kernal);
        }

        private static int[,] CreateMatrix(LevelData levelData)
        {
            int squaredSize = levelData.Size * levelData.Size;
            int[,] sMatrix = new int[squaredSize, squaredSize + 1];

            for (int col = 0; col < levelData.Size; col++)
            {
                for (int row = 0; row < levelData.Size; row++)
                {
                    for (int k = 0; k < squaredSize; k++)
                    {
                        int boardIndex = row + (col * levelData.Size);
                        int isNeighbor =
                           (k + 1 == boardIndex && boardIndex % levelData.Size != 0) || (k + 1 == boardIndex && k == 0) ||
                           (k - 1 == boardIndex && k % levelData.Size != 0) ||
                           k == boardIndex ||
                           k - levelData.Size == boardIndex ||
                           k + levelData.Size == boardIndex
                            ? 1 : 0;

                        sMatrix[k, boardIndex] = isNeighbor;
                    }
                }
            }

            for (int i = 0; i < levelData.Size * levelData.Size; i++)
            {
                sMatrix[i, levelData.Size * levelData.Size] = levelData.Board[i];
            }

            //PrintMatrix(sMatrix);

            return sMatrix;
        }

        private static int[] SolveMatrix(int[,] matrix)
        {
            for (int currentRow = 0; currentRow < matrix.GetLength(0); currentRow++)
            {
                for (int nextRow = currentRow + 1; nextRow < matrix.GetLength(0); nextRow++)
                {
                    // Our diagonal value is a 1, we can add this row to any row that has a 1 in the same spot
                    if (matrix[currentRow, currentRow] == 1)
                    {
                        if (matrix[nextRow, currentRow] == 1)
                        {
                            for (int column = 0; column < matrix.GetLength(1); column++)
                            {
                                matrix[nextRow, column] = Add(matrix[currentRow, column], matrix[nextRow, column]);
                            }
                        }
                    }
                    else
                    {
                        for (int row = nextRow + 1; row < matrix.GetLength(0); row++)
                        {
                            if (matrix[row, currentRow] == 1)
                            {
                                for (int column = currentRow; column < matrix.GetLength(1); column++)
                                {
                                    matrix[currentRow, column] = Add(matrix[currentRow, column], matrix[row, column]);
                                }
                                nextRow--;
                                break;
                            }
                        }
                    }
                }
            }

            for (int currentRow = matrix.GetLength(0) - 1; currentRow >= 0; currentRow--)
            {
                for (int nextRow = currentRow - 1; nextRow >= 0; nextRow--)
                {
                    // Out diagonal value is a 1, we can add this row to any row that has a 1 in the same spot
                    if (matrix[currentRow, currentRow] == 1)
                    {
                        if (matrix[nextRow, currentRow] == 1)
                        {
                            for (int column = 0; column < matrix.GetLength(1); column++)
                            {
                                matrix[nextRow, column] = Add(matrix[currentRow, column], matrix[nextRow, column]);
                            }
                        }
                    }
                    else
                    {
                        for (int row = nextRow - 1; row > 0; row--)
                        {
                            if (matrix[row, currentRow] == 1)
                            {
                                for (int column = currentRow; column < matrix.GetLength(1); column++)
                                {
                                    matrix[currentRow, column] = Add(matrix[currentRow, column], matrix[row, column]);
                                }
                                nextRow++;
                                break;
                            }
                        }
                    }
                }
            }

            //PrintMatrix(matrix);

            int[] solution = new int[matrix.GetLength(0)];
            for (int i = 0; i < solution.Length; i++)
            {
                solution[i] = matrix[i, matrix.GetLength(0)];
                //Debug.Log(solution[i] + ", ");
            }

            return solution;
        }

        private static int Add(int a, int b)
        {
            return (a + b) % 2;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            //Debug.Log("\n");
            string output = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    output += matrix[i, j] + ", ";
                }
                output += "\n";
            }
            //Debug.Log(output);
        }
    }
}
