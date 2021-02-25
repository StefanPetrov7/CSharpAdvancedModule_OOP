using System.Collections.Generic;
using Collection_Hierarchy.Contracts;

namespace Collection_Hierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        protected IList<string> collection;

        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public virtual int Add(string item)
        {
            this.collection.Add(item);
            return this.collection.Count - 1;
        }
    }
}
