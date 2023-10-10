using Collection_Hierarchy.Contracts;
namespace Collection_Hierarchy.Models
{
    public class MyList : AddRemoveCollection, IUsed
    {
        public MyList() : base()
        { }

        public override int Add(string element)
        {
            return base.Add(element);
        }

        public override string Remove()
        {
            string element = this.Collection[0];
            this.Collection.RemoveAt(0);
            return element;
        }

        public int Used() => this.Collection.Count;

    }
}

