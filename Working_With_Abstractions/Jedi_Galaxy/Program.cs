using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            int[,] matrix = FillMatrix(size);
            string input;
            string END_COMMAND = "Let the Force be with you";
            long sum = 0;

            while ((input = Console.ReadLine()) != END_COMMAND)
            {
                int[] ivoCordinates = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                int[] enemyCoordinates = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

                int ivoR = ivoCordinates[0];
                int ivoC = ivoCordinates[1];
                int enemyR = enemyCoordinates[0];
                int enemyC = enemyCoordinates[1];

                while (enemyR >= 0 && enemyC >= 0)
                {

                    if (enemyR >= 0 && enemyR < matrix.GetLength(0) && enemyC >= 0 && enemyC < matrix.GetLength(1))
                    {
                        matrix[enemyR, enemyC] = 0;
                    }
                    enemyR--;
                    enemyC--;
                }

                while (ivoR >= 0 && ivoC < matrix.GetLength(1))
                {
                    if (ivoR >= 0 && ivoR < matrix.GetLength(0) && ivoC >= 0 && ivoC < matrix.GetLength(1))
                    {
                        sum += matrix[ivoR, ivoC];
                    }
                    ivoR--;
                    ivoC++;
                }
            }

            Console.WriteLine(sum);
        }

        private static int[,] FillMatrix(int[] size)
        {
            int counter = 0;

            int[,] matrix = new int[size[0], size[1]];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = counter;
                    counter++;
                }
            }
            return matrix;
        }
    }
}
