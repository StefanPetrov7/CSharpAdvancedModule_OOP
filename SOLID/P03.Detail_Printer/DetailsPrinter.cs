using System;
using System.Collections.Generic;

using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (var employee in this.employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
