using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private ICollection<IBakedFood> bakedFoods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private decimal totalIncome = 0M;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
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

            this.bakedFoods.Add(food);
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

            return sb.ToString().TrimEnd();

        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, this.totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {table.TableNumber}");
            sb.AppendLine($"Bill: {table.GetBill():f2}");
            this.totalIncome += table.GetBill();
            table.Clear();
            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return string.Format(OutputMessages.DrinkOrderSuccessful, tableNumber, drinkName, drinkBrand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood food = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (food == null)
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

            table.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}

