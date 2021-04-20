using System;
using System.Linq;
using System.Collections.Generic;

namespace Associative.Arrays.Dragon.Army
{
    class Program
    {
        static void Main(string[] args)
        {
            int dragonsCount = int.Parse(Console.ReadLine());

            List<Dragon> dragons = new List<Dragon>();
            List<Type> types = new List<Type>();

            for (int i = 0; i < dragonsCount; i++)
            {
                string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = info[0];
                string name = info[1];
                int damage = info[2] == "null" ? 45 : int.Parse(info[2]);
                int health = info[3] == "null" ? 250 : int.Parse(info[3]);
                int armor = info[4] == "null" ? 10 : int.Parse(info[4]);

                Dragon curDragon = new Dragon(type, name, damage, health, armor);

                if (dragons.Exists(x => x.Type == type && x.Name == name))
                {
                    Dragon dragon = dragons.FirstOrDefault(x => x.Type == type && x.Name == name);
                    dragon.Damage = damage;
                    dragon.Health = health;
                    dragon.Armor = armor;
                }
                else
                {
                    dragons.Add(curDragon);
                }

                if (types.Exists(x => x.TypeName == type) == false)
                {
                    Type curType = new Type(type, 0);
                    types.Add(curType);
                }
            }

            foreach (var dragon in dragons)
            {
                double damage = dragon.Damage;
                double health = dragon.Health;
                double armor = dragon.Armor;
                string type = dragon.Type;

                if (types.Exists(x => x.TypeName == type))
                {
                    Type curType = types.FirstOrDefault(x => x.TypeName == type);
                    curType.DamageAve += damage;
                    curType.HealthAve += health;
                    curType.ArmorAve += armor;
                    curType.Count += 1;
                }
            }

            foreach (var type in types)
            {
                string curType = type.TypeName;
                double damageAverage = type.DamageAve / type.Count;
                double healtAverage = type.HealthAve / type.Count;
                double armorAverage = type.ArmorAve / type.Count;
                Console.WriteLine($"{type.TypeName}::({damageAverage:f2}/{healtAverage:f2}/{armorAverage:f2})");

                foreach (var dragon in dragons.Where(x => x.Type == curType).OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor} ");
                }
            }
        }
    }

    public class Type
    {
        public string TypeName { get; set; }
        public double DamageAve { get; set; }
        public double HealthAve { get; set; }
        public double ArmorAve { get; set; }
        public int Count { get; set; }

        public Type(string type, int count)
        {
            this.TypeName = type;
            this.Count = count;
        }
    }

    public class Dragon
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }

        public Dragon(string type, string name, int damage, int health, int armor)
        {
            this.Type = type;
            this.Name = name;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }
    }
}