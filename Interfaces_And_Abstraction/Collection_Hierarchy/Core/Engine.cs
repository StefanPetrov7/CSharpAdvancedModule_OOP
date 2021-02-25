using System.Linq;
using Collection_Hierarchy.Contracts;
using Collection_Hierarchy.Models;

namespace Collection_Hierarchy.Core
{
    public class Engine : IEngine
    {
        IReader reader;
        IWriter writer;
        IAddCollection addCollection;
        IAddRemoveCollection addRemoveCollection;
        IMyList myListCollection;

        public Engine()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myListCollection = new MyList();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] input = reader.ReadLine().Split(' ').ToArray();
            int cmd = int.Parse(reader.ReadLine());

            PrintForEachCollection(input, this.addCollection);
            PrintForEachCollection(input, this.addRemoveCollection);
            PrintForEachCollection(input, this.myListCollection);
            PrintRemovedElements(cmd, this.addRemoveCollection);
            PrintRemovedElements(cmd, this.myListCollection);
        }

        private void PrintForEachCollection(string[] input, IAddCollection collection)
        {
            for (int i = 0; i < input.Length; i++)
            {
                writer.Write($"{collection.Add(input[i])} ");
            }
            writer.WriteLine(" ");
        }

        private void PrintRemovedElements(int cmd, IAddRemoveCollection collection)
        {
            for (int i = 0; i < cmd; i++)
            {
                writer.Write($"{collection.Remove()} ");
            }
            writer.WriteLine(" ");
        }
    }
}
