using System;
using System.Linq;
using System.Collections.Generic;

using Military_Elite.Contracts;
using Military_Elite.Common;
using Military_Elite.Models;


namespace Military_Elite.Core
{
    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private HashSet<Soldier> soldiers;
        private HashSet<Private> privates;

        public Engine(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
            this.soldiers = new HashSet<Soldier>();
            this.privates = new HashSet<Private>();

        }

        public void Run()
        {
            string input;

            while ((input = reader.ReadLine()) != GlobalConstants.END_INPUT)
            {
                string[] args = input.Split(' ').ToArray();
                try
                {
                    switch (args[0])
                    {
                        case "Private":
                            Private @private = CreatePrivate(args);
                            this.privates.Add(@private);
                            soldiers.Add(@private);
                            break;
                        case "LieutenantGeneral":
                            LieutenantGeneral lieutenant = CreateLeutenant(args);
                            this.soldiers.Add(lieutenant);
                            break;
                        case "Engineer":
                            Engineer engineer = CreateEngineer(args);
                            this.soldiers.Add(engineer);
                            break;
                        case "Commando":
                            Commando commando = CreateCommando(args);
                            this.soldiers.Add(commando);
                            break;
                        case "Spy":
                            Spy spy = CreateSpy(args);
                            this.soldiers.Add(spy);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }

            }

            foreach (var soldier in soldiers)
            {
                writer.WriteLine(soldier.ToString());
            }

        }

        private Private CreatePrivate(string[] args)
            => new Private(int.Parse(args[1]), args[2], args[3], decimal.Parse(args[4]));

        private LieutenantGeneral CreateLeutenant(string[] args)
        {
            string[] iDs = args.Skip(5).ToArray();
            LieutenantGeneral leutenant = new LieutenantGeneral(int.Parse(args[1]), args[2], args[3], decimal.Parse(args[4]));
            leutenant.AddPrivates(this.privates, iDs);
            return leutenant;
        }

        private Engineer CreateEngineer(string[] args)
        {
            string[] repairs = args.Length > 6 ? args.Skip(6).ToArray() : null;
            return new Engineer(int.Parse(args[1]), args[2], args[3], decimal.Parse(args[4]), args[5], repairs);
        }

        private Commando CreateCommando(string[] args)
        {
            string[] missions = args.Length > 6 ? args.Skip(6).ToArray() : null;
            return new Commando(int.Parse(args[1]), args[2], args[3], decimal.Parse(args[4]), args[5], missions);
        }

        private Spy CreateSpy(string[] args)
         => new Spy(int.Parse(args[1]), args[2], args[3], int.Parse(args[4]));

    }
}
