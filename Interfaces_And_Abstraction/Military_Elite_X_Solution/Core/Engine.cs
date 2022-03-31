using System;
using System.Collections.Generic;
using System.Linq;
using Military_Elite.Contracts;
using Military_Elite.Factories;
using Military_Elite.IO;
using Military_Elite.IO.Contracts;

namespace Military_Elite.Core
{
    public class Engine
    {
        private const string STOP_WHILE = "End";
        private const string PRIVATE = "Private";
        private const string LEUTENANT = "LieutenantGeneral";
        private const string ENGINEER = "Engineer";
        private const string COMMANDO = "Commando";
        private const string SPY = "Spy";

        private IReader reader;
        private IWriter writer;
        private ICollection<ISoldier> soldiers;

        public Engine(IReader reader, IWriter writer)
        {
            this.soldiers = new HashSet<ISoldier>();
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input;

            while ((input = reader.ReadLine()) != STOP_WHILE)
            {
                string[] arg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string type = arg[0];
                arg = arg.Skip(1).ToArray();

                try
                {
                    switch (type)
                    {
                        case PRIVATE:
                            soldiers.Add(PrivateFactory.CreatePrivate(arg));
                            break;
                        case LEUTENANT:
                            soldiers.Add(LeutenantGeneralFactory.CreateLeutenantGeneral(arg, this.soldiers));
                            break;
                        case ENGINEER:
                            soldiers.Add(EngineerFactory.CreateEngineer(arg));
                            break;
                        case COMMANDO:
                            soldiers.Add(CommandoFactory.CreateCommando(arg));
                            break;
                        case SPY:
                            soldiers.Add(SpyFactory.CreateSpy(arg));
                            break;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }

            this.soldiers.ToList().ForEach(x => writer.WriteLine(x.ToString()));
        }
    }
}
