using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WarCroft.Constants;
using WarCroft.Core.IO;
using WarCroft.Core.IO.Contracts;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;


namespace WarCroft.Core
{
    public class WarController
    {
        private ICollection<Character> characters;
        private ICollection<Item> itemsPool;
        private StringBuilder sb;

        public WarController()
        {
            this.characters = new HashSet<Character>();
            this.itemsPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            try
            {
                string playerName = args[1];
                string type = args[0];
                Type charachterType = assembly.GetTypes().FirstOrDefault(hero => hero.Name == type);
                object[] charachterCtor = new object[] { playerName };
                Character hero = (Character)Activator.CreateInstance(charachterType, charachterCtor);
                this.characters.Add(hero);
                return string.Format(SuccessMessages.JoinParty, playerName);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, args[0].ToString()));
            }
            catch (Exception)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNameInvalid));
            }
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Assembly assembly = Assembly.GetExecutingAssembly();

            try
            {
                Type itemType = assembly.GetTypes().FirstOrDefault(type => type.Name == itemName);
                Item item = (Item)Activator.CreateInstance(itemType, null);
                this.itemsPool.Add(item);
                return string.Format(SuccessMessages.AddItemToPool, itemName);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = characters.FirstOrDefault(player => player.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (itemsPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = this.itemsPool.ToList()[this.itemsPool.Count - 1];
            this.itemsPool.Remove(item);
            character.Bag.AddItem(item);

            return string.Format(string.Format(SuccessMessages.PickUpItem, character.Name, item.GetType().Name));
        }

        public string UseItem(string[] args)
        {
            string charachterName = args[0];
            string itemName = args[1];

            Character character = this.characters.FirstOrDefault(player => player.Name == charachterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, charachterName));
            }

            try
            {
                character.Bag.GetItem(itemName);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return string.Format(SuccessMessages.UsedItem, charachterName, itemName);
        }

        public string GetStats()
        {
            this.sb = new StringBuilder();

            foreach (Character character in this.characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine(character.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            this.sb = new StringBuilder();
            string attackerName = args[0];
            string defenderName = args[1];

            Character attacker = this.characters.FirstOrDefault(player => player.Name == attackerName);
            Character defender = this.characters.FirstOrDefault(player => player.Name == defenderName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (defender == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, defenderName));
            }

            try
            {
                ((Warrior)attacker).Attack(defender);
                sb.AppendLine($"{attacker.Name} attacks {defender.Name} for {attacker.AbilityPoints} hit points! {defender.Name} has {defender.Health}/{defender.BaseHealth} HP and {defender.Armor}/{defender.BaseArmor} AP left!");
                if (defender.IsAlive==false)
                {
                    sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, defender.Name));
                }
                return sb.ToString().TrimEnd();
            }
            catch (Exception)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
        }

        public string Heal(string[] args)
        {
            this.sb = new StringBuilder();
            string healerName = args[0];
            string healedName = args[1];

            Character healer = this.characters.FirstOrDefault(player => player.Name == healerName);
            Character healed = this.characters.FirstOrDefault(player => player.Name == healedName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (healed == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healedName));
            }

            try
            {
                ((Priest)healer).Heal(healed);
                sb.AppendLine($"{healer.Name} heals {healed.Name} for {healer.AbilityPoints}! {healed.Name} has {healed.Health} health now!");
                if (healed.IsAlive == false)
                {
                    sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, healed.Name));
                }
                return sb.ToString().TrimEnd();
            }
            catch (Exception)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
        }
    }
}
