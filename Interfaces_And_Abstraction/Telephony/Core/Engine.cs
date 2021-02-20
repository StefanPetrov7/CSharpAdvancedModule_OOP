using System;
using System.Linq;

using Telephony.Contracts;
using Telephony.Exeptions;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private StationaryPhone stationaryPhone;
        private Smartphone smartPhone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartPhone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] numbers = reader.ReadLine().Split(' ').ToArray();
            string[] url = reader.ReadLine().Split(' ').ToArray();

            CallNumbers(numbers);
            BrowseWeb(url);

        }

        private void BrowseWeb(string[] url)
        {
            foreach (var addres in url)
            {
                try
                {
                    writer.WriteLine(smartPhone.BrowsingWeb(addres));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        private void CallNumbers(string[] numbers)
        {
            foreach (var num in numbers)
            {
                try
                {
                    if (num.Length == 7)
                    {
                        writer.WriteLine(stationaryPhone.CallingPhones(num));
                    }
                    else if (num.Length == 10)
                    {
                        writer.WriteLine(smartPhone.CallingPhones(num));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
