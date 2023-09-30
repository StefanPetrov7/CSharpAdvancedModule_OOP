using System.Linq;
using PersonInfo.Common;
using PersonInfo.Contracts;
using PersonInfo.Models;

namespace PersonInfo.Core
{
    public class Engine
    {
        private IList<IIdentifiable> idList;
        private IList<IIdentifiable> detainedList;

        public Engine()
        {
            this.idList = new List<IIdentifiable>();
            this.detainedList = new List<IIdentifiable>();
        }

        public void Run()
        {
            string input;

            while ((input = Console.ReadLine()) != GlobConst.END_PROGRAM)
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (data.Length == 3)
                {
                    IIdentifiable person = new Human(data[0], int.Parse(data[1]), data[2]);
                    this.idList.Add(person);
                }
                else
                {
                    IIdentifiable robot = new Robot(data[0], data[1]);
                    this.idList.Add(robot);
                }
            }

            string validation = Console.ReadLine();

            foreach (var item in this.idList)
            {
                string symbols = item.Id.Substring(item.Id.Length - validation.Length, validation.Length);

                if (validation == symbols)
                {
                    this.detainedList.Add(item);
                }
            }

            foreach (var item in this.detainedList)
            {
                Console.WriteLine(item.Id);
            }



        }
    }
}

