using System;
using System.Linq;
using System.Collections.Generic;
using WarCroft.Entities.Items;
using WarCroft.Constants;

namespace WarCroft.Entities.Inventory.Models
{
    public abstract class Bag : IBag
    {
        private int defaultCapacity = 100;
        private ICollection<Item> items;
        private int load;

        public Bag() 
        {
            this.Capacity = defaultCapacity;
            this.items = new HashSet<Item>();
        }

        public virtual int Capacity { get; set; }

        public int Load
        {
            get { return this.load; }
            set
            {
                this.load = this.Items.Sum(x => x.Weight);
            }
        }

        public IReadOnlyCollection<Item> Items => (IReadOnlyCollection<Item>)this.items;

        public void AddItem(Item item)
        {
            if ((this.Load + item.Weight) > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);

        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = this.Items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(item);
            return item;

        }
    }
}
