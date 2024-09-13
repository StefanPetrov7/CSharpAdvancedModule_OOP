using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Models
{
    public abstract class Food
    {
        protected Food(int qty)
        {
            this.Quantity = qty;    
        }

        public int Quantity { get; set; }

    }
}
