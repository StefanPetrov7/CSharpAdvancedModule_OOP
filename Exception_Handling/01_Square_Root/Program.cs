using System;

namespace _01_Square_Root
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());

                if (n < 0)
                {
                    throw new FormatException();
                }

                Console.WriteLine(Math.Sqrt(n));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalide number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
