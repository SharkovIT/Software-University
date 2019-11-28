using System;
using System.Collections.Generic;
using System.Text;

namespace P03_WildFarm.Food
{
    public abstract class Food
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
