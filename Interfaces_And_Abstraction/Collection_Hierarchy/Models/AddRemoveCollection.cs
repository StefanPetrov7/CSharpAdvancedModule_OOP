using Collection_Hierarchy.Contracts;

namespace Collection_Hierarchy.Models
{
    public class AddRemoveCollection :AddCollection, IAddRemoveCollection
    {
        protected const int index = 0;

        public AddRemoveCollection() : base()
        {
        }

        public override int Add(string item)
        {
            this.collection.Insert(index, item);
            return index;
        }

        public virtual string Remove()
        {
            if (this.collection.Count != 0)
            {
                string removedItem = this.collection[this.collection.Count - 1];
                this.collection.RemoveAt(this.collection.Count - 1);
                return removedItem;
            }

            return null;
        }
    }
}
