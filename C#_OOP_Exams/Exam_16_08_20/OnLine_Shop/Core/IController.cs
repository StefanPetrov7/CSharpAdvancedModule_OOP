namespace OnLine_Shop.Core
{
    public interface IController
    {
        string AddComputer(string computerType, int id, string manufacturer, string model, decimal price);

        string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model,
            decimal price, double overallPerformance, string connectionType);

        string RemovePeripheral(string peripheralType, int computerId);

        string AddComponent(int computerId, int id, string computerType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation);

        string RemoveComponent(string componentType, int computerId);

        string BuyComputer(int id);

        string BuyBestComputer(decimal price);

        string GetComputerData(int id);

    }
}
