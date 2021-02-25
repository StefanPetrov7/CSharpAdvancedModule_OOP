namespace Collection_Hierarchy.Contracts
{
    public interface IMyList : IAddRemoveCollection
    {
        // Add element at the start
        // Remove the first element
        // Prop USed return count;

        public int Used { get; }
    }
}
