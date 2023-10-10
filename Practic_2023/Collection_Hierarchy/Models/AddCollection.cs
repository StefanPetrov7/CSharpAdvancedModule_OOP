using Collection_Hierarchy.Contracts;
namespace Collection_Hierarchy.Models
{
    public class AddCollection : IAddElement
    {

        public AddCollection()
        {
            this.Collection = new List<string>();
        }

        protected List<string> Collection { get; }

        public virtual int Add(string element)
        {
            this.Collection.Add(element);
            return this.Collection.Count - 1;
        }
    }
}

