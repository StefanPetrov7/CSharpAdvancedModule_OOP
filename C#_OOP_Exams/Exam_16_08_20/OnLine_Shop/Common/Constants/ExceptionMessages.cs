namespace OnLine_Shop.Common.Constants
{
    public static class ExceptionMessages
    {
        public const string InvalidCommand = "Commmand is invalid.";

        public const string InvalidProductId = "Id can not be less or equal to 0.";

        public const string InvalidManufacturer = "Manufacturer can not be empty.";

        public const string InvalidModel = "Model can not be empty.";

        public const string InvalidPrice = "Price can not be less or equal than 0.";

        public const string InvalidOverallPerformance = "Overall Perforamce can not be less or equal than 0.";

        public const string ExistingComponent = "Component {0} already exist in {1} with Id {2}.";

        public const string ExistingPeripheral = "Peripheral {0} already exist in {1} with Id {2}.";

        public const string NoExistingComponent = "Component {0} does not exist in {1} with Id {2}.";

        public const string NoExistingPeripheral = "Peripheral {0} does not exist in {1} with Id {2}.";

        public const string NoExistingComputerId = "Computer with this Id does not exist.";

        public const string InvalidComputerType = "Computer type is invalid";

        public const string ComputerWithIdExists = "Computer with this Id already exists";

        public const string InvalidComponentType = "Component type is invalid";

        public const string PeripheralWithIdExists = "Peripheral with this Id already exists";

        public const string InvalidPeripheralType = "Peripheral type is invalid";

        public const string CantBuyComputer = "Can't buy a computer with a budget of ${0}";

    }
}
