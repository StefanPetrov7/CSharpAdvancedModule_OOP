using Collection_Hierarchy.Contracts;

namespace Collection_Hierarchy.Models
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public MyList() : base()
        {
        }

        public int Used => this.collection.Count;

        public override string Remove()
        {
            if (this.collection.Count != 0)
            {
                string removedItem = this.collection[index];
                this.collection.RemoveAt(index);
                return removedItem;
            }

            return null;
        }
    }
}
