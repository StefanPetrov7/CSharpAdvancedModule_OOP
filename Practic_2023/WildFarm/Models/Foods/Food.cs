using System;
namespace WildFarm.Models.Foods
{
	public abstract class Food
	{
		protected Food(int qty)
		{
			this.Qty = qty;
		}

		public int Qty { get; private set; }
	}
}

