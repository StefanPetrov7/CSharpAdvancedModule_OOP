namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        private const decimal pricePP = 2.50M;

        public InsideTable(int tableNum, int capacity)
            : base(tableNum, capacity, pricePP)
        { }
    }
}
