namespace OnLine_Shop.Models.Products
{
    public interface IProducts
    {
        int Id { get; }

        string Manufacturer { get; }

        string Model { get; }

        decimal Price { get; }

        double OverallPerformace { get; }
    }
}
