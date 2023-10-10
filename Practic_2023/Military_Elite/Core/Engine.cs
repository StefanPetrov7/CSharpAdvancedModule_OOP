using Military_Elite.Contracts;
using Military_Elite.Exeptions;
using Military_Elite.Models;
namespace Military_Elite.Core
{
    public class Engine : IEngine
    {
        private const string END_PROGRAM = "End";
        private IReader reader;
        private IWriter writer;
        private ICollection<ISoldier> soldiers;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.soldiers = new HashSet<ISoldier>();
        }

        public void Run()
        {
            string input;

            while ((input = reader.ReadLine()) != END_PROGRAM)
            {
                string[] cmd = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string soldierType = cmd[0];
                ISoldier soldier;

                if (soldierType == nameof(Private))
                {
                    soldier = new Private(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4]));
                    this.soldiers.Add(soldier);
                }
                else if (soldierType == nameof(LieutenantGeneral))
                {
                    soldier = new LieutenantGeneral(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4]), cmd.Skip(5).ToArray());
                    LieutenantGeneral general = (LieutenantGeneral)soldier;
                    general.GetPrivates(this.soldiers);
                    this.soldiers.Add(general);
                }
                else if (soldierType == nameof(Engineer))
                {
                    try
                    {
                        soldier = new Engineer(cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4]), cmd[5], cmd.Skip(6).ToArray());
                        this.soldiers.Add(soldier);
                    }
                    catch (InvalidCorpsExeption)
                    {
                       
                    }
                }
                else if (soldierType == nameof(Commando))
                {
                    soldier = new Commando (cmd[1], cmd[2], cmd[3], decimal.Parse(cmd[4]), cmd[5], cmd.Skip(6).ToArray());
                    this.soldiers.Add(soldier);
                }
                else if(soldierType == nameof(Spy))
                {
                    soldier = new Spy(cmd[1], cmd[2], cmd[3], int.Parse(cmd[4]));
                    this.soldiers.Add(soldier);
                }
            }

            foreach (Soldier @soldier in this.soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}

