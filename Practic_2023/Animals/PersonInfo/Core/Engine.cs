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
        private IList<IBirthable> bdList;

        public Engine()
        {
            this.idList = new List<IIdentifiable>();
            this.detainedList = new List<IIdentifiable>();
            this.bdList = new List<IBirthable>();
        }

        public void RunTelephonyControl()
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

        public void RunBirthdays()
        {
            string input;

            while ((input = Console.ReadLine()) != GlobConst.END_PROGRAM)
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = data[1];
                string bd = data[data.Length - 1];

                if (data[0] == "Citizen")
                {
                    IBirthable citizen = new Citizen(name, int.Parse(data[2]), data[3], bd);
                    this.bdList.Add(citizen);
                }
                else if (data[0] == "Pet")
                {
                    IBirthable pet = new Pet(name, bd);
                    this.bdList.Add(pet);
                }
            }

            string date = Console.ReadLine();
            this.bdList = bdList.Where(x => x.Birthdate.Substring(x.Birthdate.Length - date.Length, date.Length) == date).ToList();

            if (this.bdList.Count > 0)
            {
                foreach (var item in this.bdList)
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}

