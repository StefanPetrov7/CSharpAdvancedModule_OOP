using System.Collections.Generic;
using System.Linq;
using Border_Control.Common;
using Border_Control.Contracts;
using Border_Control.Models;

namespace Border_Control.Core
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private List<IIdNumerable> iDNumbers;
        //private List<IBirthdays> birhdays;

        public Engine(IWriter writer, IReader reader)
        {
            this.reader = reader;
            this.writer = writer;
            this.iDNumbers = new List<IIdNumerable>();
            //this.birhdays = new List<IBirthdays>();
        }

        public void Run()
        {
            string input;

            while ((input = reader.ReadLine()) != GlobalConstants.END_INPUT)
            {
                string[] info = input.Split(' ').ToArray();

                if (info.Length == 3)
                {
                    IIdNumerable human = new Citizen(info[0], int.Parse(info[1]), long.Parse(info[2]));
                    iDNumbers.Add(human);
                }
                //else if (info[0] == "Pet")
                //{
                //    IBirthdays pet = new Pet(info[1], info[2]);
                //    birhdays.Add(pet);
                //}
                else if (info.Length == 2)
                {
                    IIdNumerable robot = new Robot(info[0], long.Parse(info[1]));
                    iDNumbers.Add(robot);
                }
            }

            string num = reader.ReadLine();

            foreach (var unit in iDNumbers.Where(x => x.ID.ToString().EndsWith(num)))  // => can print by ID.
            {
                writer.WriteLine(unit.ID.ToString().TrimEnd());
            }

            //birhdays = birhdays.Where(x => x.Birthday.EndsWith(num)).ToList();
            //birhdays.ForEach(x => writer.WriteLine(x.Birthday));
        }
    }
}
