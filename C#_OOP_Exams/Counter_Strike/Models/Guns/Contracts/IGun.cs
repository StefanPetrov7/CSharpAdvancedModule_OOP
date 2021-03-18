namespace Counter_Strike.Models.Guns.Contracts
{
    public interface IGun
    {
        string Name { get; }  // => it will have only private setter; No public setter!!!??????

        int BulletsCount { get; } // => it will have only private setter;

        int Fire();
    }
}
