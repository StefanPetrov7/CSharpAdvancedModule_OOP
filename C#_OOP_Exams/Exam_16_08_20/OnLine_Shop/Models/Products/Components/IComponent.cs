namespace OnLine_Shop.Models.Products.Components
{
    public interface IComponent : IProducts
    {
        int Generation { get; }
    }
}
