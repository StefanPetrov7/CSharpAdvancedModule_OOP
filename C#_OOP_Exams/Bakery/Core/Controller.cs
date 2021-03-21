using System.Collections.Generic;
using System.Linq;
using System.Text;

using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private ICollection<ITable> tables;
        private ICollection<IBakedFood> foods;
        private ICollection<IDrink> drinks;
        private decimal totalIncome;

        public Controller()
        {
            this.tables = new List<ITable>();
            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == typeof(Tea).Name)
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == typeof(Water).Name)
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == typeof(Bread).Name)
            {
                food = new Bread(name, price);
            }
            else if (type == typeof(Cake).Name)
            {
                food = new Cake(name, price);
            }

            this.foods.Add(food);
            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == typeof(OutsideTable).Name)
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            else if (type == typeof(InsideTable).Name)
            {
                table = new InsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in this.tables.Where(t => t.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            string tablesInfo = sb.ToString().TrimEnd();
            return tablesInfo;
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {

            StringBuilder sb = new StringBuilder();
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            this.totalIncome += table.GetBill();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {table.GetBill():f2}");
            table.Clear();
            string bill = sb.ToString().TrimEnd();
            return bill;
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            else if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return string.Format(OutputMessages.DrinkOrderSuccessful, tableNumber, drinkName, drinkBrand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood food = this.foods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            else if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                table.Reserve(numberOfPeople);
                return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }
        }
    }
}
