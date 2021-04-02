using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private ICollection<Character> heroRepo;
        private ICollection<Item> itemRepo;

        public WarController()
        {
            heroRepo = new List<Character>();
            itemRepo = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string heroType = args[0];
            string heroName = args[1];

            Character hero;

            //Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == heroType); // => Reflection works, judge take 30p.?
            //hero = (Character)Activator.CreateInstance(type, new object[] { heroName });

            //if (hero == null )
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, heroType));
            //}

            if (heroType == typeof(Warrior).Name)
            {
                hero = new Warrior(heroName);
            }
            else if (heroType == typeof(Priest).Name)
            {
                hero = new Priest(heroName);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, heroType));
            }

            this.heroRepo.Add(hero);

            return string.Format(SuccessMessages.JoinParty, heroName);
        }

        public string AddItemToPool(string[] args)
        {
            string itemType = args[0];

            //Type typeItem = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(i => i.Name == itemType);  // => Judge take 12points.

            //if (typeItem == null)
            //{
            //    throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemType));
            //}

            //Item item = (Item)Activator.CreateInstance(typeItem, null);

            Item item = itemType switch
            {
                nameof(FirePotion) => new FirePotion(),
                nameof(HealthPotion) => new HealthPotion(),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemType))
            };

            this.itemRepo.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, itemType);
        }

        public string PickUpItem(string[] args)
        {
            string name = args[0];

            Character hero = this.heroRepo.FirstOrDefault(h => h.Name == name);

            if (hero == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
            }

            if (this.itemRepo.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
            }

            Item item = this.itemRepo.Last();   // To check if item need to be removed. 
            hero.Bag.AddItem(item);
            this.itemRepo.Remove(item);

            return string.Format(SuccessMessages.PickUpItem, name, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string heroName = args[0];
            string itemName = args[1];

            Character hero = this.heroRepo.FirstOrDefault(h => h.Name == heroName);

            if (hero == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, heroName));
            }

            hero.Bag.GetItem(itemName).AffectCharacter(hero);

            return string.Format(SuccessMessages.UsedItem, hero.Name, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in this.heroRepo.OrderByDescending(h => h.IsAlive).ThenByDescending(h => h.Health))
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().TrimEnd();

        }

        public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string attackerName = args[0];
            string attackedName = args[1];

            Character attacker = this.heroRepo.FirstOrDefault(h => h.Name == attackerName);
            Character attacked = this.heroRepo.FirstOrDefault(h => h.Name == attackedName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            else if (attacked == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackedName));
            }

            if (!(attacker is Warrior))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            ((Warrior)attacker).Attack(attacked);

            sb.AppendLine($"{attackerName} attacks {attackedName} for {attacker.AbilityPoints} hit points! " +
                $"{attacked.Name} has {attacked.Health}/{attacked.BaseHealth} HP and" +
                $" {attacked.Armor}/{attacked.BaseArmor} AP left!");

            if (!attacked.IsAlive)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, attackedName));
            }

            return sb.ToString().TrimEnd();

        }

        public string Heal(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string healerName = args[0];
            string receaverName = args[1];

            Character healer = this.heroRepo.FirstOrDefault(h => h.Name == healerName);
            Character receiver = this.heroRepo.FirstOrDefault(h => h.Name == receaverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            else if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receaverName));
            }

            if (!(healer is Priest))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            ((Priest)healer).Heal(receiver);

            sb.AppendLine($"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

            return sb.ToString().TrimEnd();
        }
    }
}
