using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class OrderDrink
    {
        public int OrderId { get; set; }
        public int DrinkId { get; set; }

        public virtual Drink Drink { get; set; }
        public virtual Order Order { get; set; }
    }
}
