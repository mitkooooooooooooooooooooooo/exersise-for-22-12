

    

    namespace MultidimentionalArrays_5
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                int[] size = Console.WriteLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int[,] matrix = new int[size[0], size[1]];
                int[,] tempMatrix = new int[2, 2];
                int matrixSum = 0;
                int temp = 0;
                int startRow = 0;
                int startCol = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    int[] elements = Console.ReadLine()
                        .Split(', ')
                        .Select(int.Parse)
                        .ToArray();

                    for (int col = 0; col < elements.Length; col++)
                    {
                        matrix[row, col] = elements[col];
                    }
                }
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        temp += matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];
                        if (temp > matrixSum)
                        {
                            matrixSum = temp;
                            startRow = row;
                            startCol = col;
                        }
                    }
                }
                Console.WriteLine($"{matrix[startRow, startCol]} {matrix[startRow, startCol + 1]}" +
                $"\n  {matrix[startRow + 1, startCol]} {matrix[startRow + 1, startCol + 1]} " +
                $"\n {matrixSum}");

            }
            bool IsInRange(int[,] matrix, int row, int col)
            {
                return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
            }
        }
    }
