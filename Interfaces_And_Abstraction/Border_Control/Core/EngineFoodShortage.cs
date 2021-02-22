using System.Collections.Generic;
using System.Linq;
using Border_Control.Common;
using Border_Control.Contracts;
using Border_Control.Models;

namespace Border_Control.Core
{
    public class EngineFoodShortage
    {
        private IReader reader;
        private IWriter writer;
        private List<IBuyer> people;


        public EngineFoodShortage(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
            this.people = new List<IBuyer>();
        }

        public void Run()
        {
            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = reader.ReadLine().Split(' ').ToArray();

                if (info.Length == 4)
                {
                    IBuyer citizen = new Human(info[0], int.Parse(info[1]), long.Parse(info[2]), info[3]);
                    people.Add(citizen);
                }
                else
                {
                    IBuyer rabel = new Rabel(info[0], int.Parse(info[1]), info[2]);
                    people.Add(rabel);
                }
            }

            string input;

            while ((input = reader.ReadLine()) != GlobalConstants.END_INPUT)
            {
                string name = input;
                var person = people.FirstOrDefault(x => x.Name == name);
                if (person != null)
                {
                    person.BuyFood();
                }
            }

            writer.WriteLine(people.Sum(x => x.Food).ToString());
        }
    }
}
