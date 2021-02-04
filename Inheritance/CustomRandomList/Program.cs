using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Ivan1");
            list.Add("Ivan2");
            list.Add("Ivan4");
            string element = list.RandomString();
            Console.WriteLine(element);
        }
    }
}
