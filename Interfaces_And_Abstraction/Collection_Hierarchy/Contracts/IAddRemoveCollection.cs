namespace Collection_Hierarchy.Contracts
{
    public interface IAddRemoveCollection : IAddCollection
    {
        // Inherited Add method shoud Add element at the start of the collection;
        // Remove the last item and return the item;

        string Remove();
    }
}
