using Collection_Hierarchy.Models;


namespace Collection_Hierarchy.Core
{
    public class Engine
    {
        public Engine()
        { }

        public void RunCollectios()
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveColection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int n = int.Parse(Console.ReadLine());

            PrintAddCollections(input, addCollection);
            PrintAddCollections(input, addRemoveColection);
            PrintAddCollections(input, myList);
            PrintRemoveCollections(input, addRemoveColection);
            PrintRemoveCollections(input, myList);
        }

        private void PrintAddCollections(string[] input, AddCollection collection)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(collection.Add(input[i]) + " ");
            }

            Console.WriteLine();
        }

        private void PrintRemoveCollections(string[] input, AddRemoveCollection collection)
        {
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(collection.Remove() + " ");
            }

            Console.WriteLine();
        }
    }
}

