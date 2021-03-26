using System;
using System.Collections.Generic;
using System.Linq;
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
            this.heroRepo = new List<Character>();
            this.itemRepo = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string type = args[0];
            string name = args[1];

            Character hero;

            if (type == typeof(Warrior).Name)
            {
                hero = new Warrior(name);
            }
            else if (type == typeof(Priest).Name)
            {
                hero = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, type));
            }

            this.heroRepo.Add(hero);
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string type = args[0];

            Item item;

            if (type == typeof(FirePotion).Name)
            {
                item = new FirePotion();
            }
            else if (type == typeof(HealthPotion).Name)
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, type));
            }

            this.itemRepo.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, type);
        }

        public string PickUpItem(string[] args)
        {
            string name = args[0];

            Character hero = this.heroRepo.FirstOrDefault(x => x.Name == name);

            if (hero == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, name));
            }
            else if (this.itemRepo.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = itemRepo.ToList()[itemRepo.Count - 1];
            this.itemRepo.Remove(item);
            hero.Bag.AddItem(item);
            return string.Format(SuccessMessages.PickUpItem, hero.Name, item.GetType().Name);  
        }

        public string UseItem(string[] args)
        {
            string heroName = args[0];
            string itemName = args[1];

            Character hero = this.heroRepo.FirstOrDefault(x => x.Name == heroName);

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
            foreach (var hero in this.heroRepo.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string attackerHero = args[0];
            string attackedHero = args[1];

            Character attacker = this.heroRepo.FirstOrDefault(x => x.Name == attackerHero);
            Character attacked = this.heroRepo.FirstOrDefault(x => x.Name == attackedHero);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerHero));
            }
            else if (attacked == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackedHero));
            }
            else if (attacker is Priest)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerHero));
            }

            ((Warrior)attacker).Attack(attacked);

            result.AppendLine($"{attacker.Name} attacks {attacked.Name} for " +
                $"{attacker.AbilityPoints} hit points! {attacked.Name} has " +
                $"{attacked.Health}/{attacked.BaseHealth} HP and " +
                $"{attacked.Armor}/{attacked.BaseArmor} AP left!");

            if (!attacked.IsAlive)
            {
                result.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, attacked.Name));
            }

            return result.ToString().TrimEnd();

        }

        public string Heal(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string healerHero = args[0];
            string healedHero = args[1];

            Character healer = this.heroRepo.FirstOrDefault(x => x.Name == healerHero);
            Character healed = this.heroRepo.FirstOrDefault(x => x.Name == healedHero);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healer));
            }
            else if (healed == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healed));
            }
            else if (healer is Warrior)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer));
            }

            ((Priest)healer).Heal(healed);

            result.AppendLine($"{healer.Name} heals {healed.Name} " +
                $"for {healer.AbilityPoints}! {healed.Name} has {healed.Health} health now!");

            return result.ToString().TrimEnd();
        }
    }
}
