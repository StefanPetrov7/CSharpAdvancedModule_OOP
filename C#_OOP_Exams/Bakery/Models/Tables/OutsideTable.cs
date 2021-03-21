namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal pricePP = 3.50M;

        public OutsideTable(int tableNum, int capacity)
            : base(tableNum, capacity, pricePP)
        { }
    }
}
