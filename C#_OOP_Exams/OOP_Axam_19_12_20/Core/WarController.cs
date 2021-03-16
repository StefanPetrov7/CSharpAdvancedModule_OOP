using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private ICollection<Character> characters;
        private ICollection<Item> itemsPool;

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
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type itemType = assembly.GetTypes().FirstOrDefault(x => x.Name == itemName);
                Item item = (Item)Activator.CreateInstance(itemType, null);
                character.UseItem(item);
            }
            catch (InvalidOperationException)
            {

            }

            return string.Format(SuccessMessages.UsedItem, charachterName, itemName);
        }

        public string GetStats()
        {
            throw new NotImplementedException();
        }

        public string Attack(string[] args)
        {
            throw new NotImplementedException();
        }

        public string Heal(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
