using System;
using System.Collections.Generic;
using Practice.Contracts;
using Practice.Factories;
using Practice.IOManagment.Contracts;
using Practice.Models;

namespace Practice.Core
{
    public class Engine : IEngine
    {
        private const string END_INPUT = "End";
        private IReader reader;
        private IWriter writer;
        private PrivateFactory privateFactory;
        private GeneralFacatory generalFactory;
        private EngineerFactory engineerFactory;
        private CommandoFactory commandoFactory;
        private SpyFactory spyFactory;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            privateFactory = new PrivateFactory();
            generalFactory = new GeneralFacatory();
            engineerFactory = new EngineerFactory();
            commandoFactory = new CommandoFactory();
            spyFactory = new SpyFactory();
        }

        public void Run()
        {
            string input;
            HashSet<ISoldier> soldiers = new HashSet<ISoldier>();

            while ((input = reader.ReadLine()) != END_INPUT)
            {
                string[] args = input.Split();
                string type = args[0];

                Soldier soldier = null;
                try
                {
                    if (type == typeof(Private).Name)
                    {
                        soldier = (Soldier)privateFactory.CreatePrivate(args);
                    }
                    else if (type == typeof(LieutenantGeneral).Name)
                    {
                        soldier = (Soldier)generalFactory.CreateLieutenantGeneral(args, soldiers);
                    }
                    else if (type == typeof(Engineer).Name)
                    {
                        soldier = (Soldier)engineerFactory.CreateEngineer(args);
                    }
                    else if (type == typeof(Commando).Name)
                    {
                        soldier = (Soldier)commandoFactory.CreateCommando(args);
                    }
                    else if (type == typeof(Spy).Name)
                    {
                        soldier = (Soldier)spyFactory.CreateSpy(args);
                    }
                    soldiers.Add(soldier);
                }
                catch (Exception)
                {
                    
                }

               
            }

            foreach (var soldier in soldiers)
            {
                writer.WriteLine(soldier.ToString());
            }
        }
    }
}
