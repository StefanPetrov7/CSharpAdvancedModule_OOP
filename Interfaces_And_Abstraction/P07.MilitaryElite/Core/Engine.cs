using System;
using System.Collections.Generic;
using System.Linq;

using P07.MilitaryElite.Contracts;
using P07.MilitaryElite.Models;
using P07.MilitaryElite.Exceptions;

namespace P07.MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private const string END_INPUT = "End";

        private IReader reader;
        private IWriter writer;
        private ICollection<ISoldier> soldiers;

        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string cmd;

            while ((cmd = this.reader.ReadLine()) != END_INPUT)
            {
                string[] args = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string soldierType = args[0];
                int iD = int.Parse(args[1]);
                string firstName = args[2];
                string lastName = args[3];

                ISoldier soldier = null;

                switch (soldierType)
                {
                    case "Private":
                        decimal salary = decimal.Parse(args[4]);
                        soldier = CreatePrivate(iD, firstName, lastName, salary);
                        break;

                    case "LieutenantGeneral":
                        salary = decimal.Parse(args[4]);
                        ILieutenantGeneral general = CreateLieutenant(args, iD, firstName, lastName, salary);
                        soldier = general;
                        break;

                    case "Engineer":
                        salary = decimal.Parse(args[4]);
                        string corps = args[5];

                        try
                        {
                            IEngineer engineer = CreateEngineer(args, iD, firstName, lastName, salary, corps);
                            soldier = engineer;
                        }
                        catch (InvalideCorpsException)
                        {
                            continue;
                        }

                        break;
                    case "Commando":
                        salary = decimal.Parse(args[4]);
                        corps = args[5];
                        try
                        {
                            ICommando commando = CreateCommando(args, iD, firstName, lastName, salary, corps);
                            soldier = commando;

                        }
                        catch (InvalideCorpsException)
                        {
                            continue;
                        }

                        break;
                    case "Spy":
                        int codeNumber = int.Parse(args[4]);
                        soldier = new Spy(iD, firstName, lastName, codeNumber);
                        break;
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }

            }

            foreach (var soldier in this.soldiers)
            {
                this.writer.Writeline(soldier.ToString());
            }
        }

        private ICommando CreateCommando(string[] args, int iD, string firstName, string lastName, decimal salary, string corps)
        {
            ICommando commando = new Commando(iD, firstName, lastName, salary, corps);
            string[] missionArgs = args.Skip(6).ToArray();
            for (int i = 0; i < missionArgs.Length; i += 2)
            {
                try
                {
                    IMission mission = new Mission(missionArgs[i], missionArgs[i + 1]);
                    commando.AddMission(mission);
                }
                catch (InvalidStatusException)
                {
                    continue;
                }

            }

            return commando;
        }

        private ISoldier CreatePrivate(int iD, string firstName, string lastName, decimal salary)
        {
            return new Private(iD, firstName, lastName, salary);
        }

        private LieutenantGeneral CreateLieutenant(string[] args, int iD, string firstName, string lastName, decimal salary)
        {
            LieutenantGeneral general = new LieutenantGeneral(iD, firstName, lastName, salary);
            foreach (var pid in args.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers.FirstOrDefault(pr => pr.Id == int.Parse(pid));
                general.AddPrivate(privateToAdd);
            }

            return general;
        }

        private IEngineer CreateEngineer(string[] args, int iD, string firstName, string lastName, decimal salary, string corps)
        {
            IEngineer engineer = new Engineer(iD, firstName, lastName, salary, corps);
            string[] repairArg = args.Skip(6).ToArray();
            for (int i = 0; i < repairArg.Length; i += 2)
            {
                IRepair repair = new Repair(repairArg[i], int.Parse(repairArg[i + 1]));
                engineer.AddRepair(repair);
            }

            return engineer;
        }
    }
}
