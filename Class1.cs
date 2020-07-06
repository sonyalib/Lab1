using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = ReadMatrixFromConsole();
            PrintMatrix(matrix);
            ComputeFloats(matrix);
        }

        static double[,] ReadMatrixFromConsole()
        {
            Console.WriteLine("Ввод матрицы. (конец = пустая строка)");
            uint m = ReadNaturalInt("Кол-во строк: "), n = ReadNaturalInt("Кол-во столбцов: ");
            var matrix = new double[n, m];
            Console.WriteLine("{0} {1}", matrix.GetLength(0), matrix.GetLength(1));

            for (int j = 0; j < m; j++)
            {
                Console.Write("[{0}]: ", j + 1);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) break;
                string[] nums = input.Split();
                for (int i = 0; i < Math.Min(n, nums.Length); i++) double.TryParse(nums[i], out matrix[i, j]);
            }

            return matrix;
        }

        static void ComputeFloats(double[,] matrix)
        {
            Console.WriteLine("Суммы по строкам с неотрицательными числами:");
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (MinInRow(matrix, i) >= 0)
                {
                    double rowsum = RowSum(matrix, i);
                    sum += rowsum;
                    Console.WriteLine("[{0}] Sum = {1}", i + 1, rowsum);
                }
            }
            Console.WriteLine("Итого: {0}", sum);

            double minSum = double.MaxValue;
            for (int i = 0; i < Math.Max(matrix.GetLength(0), matrix.GetLength(1)); i++)
            {
                var diags = new List<IEnumerable<double>>()
                {
                    GetDiagonal(matrix, i, 0),
                    GetDiagonal(matrix, 0, i),
                    GetDiagonal(matrix, i, 0, -1),
                    GetDiagonal(matrix, 0, i, -1),
                    GetDiagonal(matrix, matrix.GetUpperBound(0), i),
                    GetDiagonal(matrix, matrix.GetUpperBound(0), i, -1)
                };
                diags.ForEach((diag) => {
                    var list = diag.ToList();
                    double sum = list.Sum();
                    if (list.Count > 0 && sum < minSum) minSum = sum;
                });
            }
            Console.WriteLine("Минимальная сумма элементов диагонали: {0}", minSum);
        }

        static void PrintMatrix(double[,] matrix)
        {
            int len = MaxInMatrix(matrix).ToString().Length;

            Console.WriteLine();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("|");
                for (int i = 0; i < matrix.GetLength(0); i++) Console.Write(" {0, " + len + "} ", matrix[i, j]);
                Console.Write("|\n");
            }
            Console.WriteLine();
        }

        static double MaxInMatrix(double[,] matrix)
        {
            double max = double.MinValue;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    max = matrix[i, j] > max ? matrix[i, j] : max;
                }
            }
            return max;
        }
        /*
        static double MaxInRow(double[,] matrix, int m)
        {
            double max = double.MinValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                max = matrix[i, m] > max ? matrix[i, m] : max;
            }
            return max;
        }*/
        static double MinInRow(double[,] matrix, int m)
        {
            double min = double.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                min = matrix[i, m] < min ? matrix[i, m] : min;
            }
            return min;
        }

        static double RowSum(double[,] matrix, int m)
        {
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, m];
            }
            return sum;
        }

        static IEnumerable<double> GetDiagonal(double[,] matrix, int x, int y, int move = 1)
        {
            while (x < matrix.GetLength(0) && y < matrix.GetLength(1) && x >= 0 && y >= 0)
            {
                yield return matrix[x, y];
                x += move;
                y += 1;
            }
        }

        static uint ReadNaturalInt(string inputText)
        {
            bool flag = false;
            uint result;
            do
            {
                Console.Write(inputText);
                string line = Console.ReadLine();
                if (uint.TryParse(line, out result) && result != 0) flag = true;
                else Console.WriteLine("Ошибка: нужно ввести натуральное число.");
            } while (!flag);

            return result;
        }
    }
}