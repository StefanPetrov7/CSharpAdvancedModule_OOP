﻿using System.Collections.Generic;
using System.Linq;
using HAD.Contracts;

namespace HAD.Core
{
    public class Engine
    {
        private bool isRunning = true;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor commandProcessor;

        public Engine(IReader reader, IWriter writer, ICommandProcessor commandProcessor)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandProcessor = commandProcessor;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                string line = this.reader.ReadLine();
                List<string> arguments = line.Split(" ", System.StringSplitOptions.RemoveEmptyEntries).ToList();

                string output = this.commandProcessor.Process(arguments);
                this.writer.WriteLine(output);

                this.isRunning = this.ShouldContinue(line);
            }


        }

        private bool ShouldContinue(string line)
        {
            return line != "Quit";
        }
    }
}