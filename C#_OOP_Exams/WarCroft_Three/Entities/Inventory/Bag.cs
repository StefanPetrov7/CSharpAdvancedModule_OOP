using System;
using System.Collections.Generic;
using System.Linq;

using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int defaultCapacity = 100;

        private int capacity;

        private ICollection<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity
        {
            get { return this.capacity; }

            set
            {
                if (value < 0)
                {
                    this.capacity = defaultCapacity;
                }

                this.capacity = value;
            }
        }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => (IReadOnlyCollection<Item>)items;

        public void AddItem(Item item)
        {
            int expectedLoad = this.Load + item.Weight;

            if (expectedLoad > this.Capacity)
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
            else if (!this.Items.Any(i => i.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            Item item = this.Items.FirstOrDefault(i => i.GetType().Name == name);
            this.items.Remove(item);
            return item;
        }
    }
}
