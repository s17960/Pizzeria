using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Drink
    {
        public Drink()
        {
            DrinkPromotion = new HashSet<DrinkPromotion>();
            OrderDrink = new HashSet<OrderDrink>();
        }

        public int DrinkId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<DrinkPromotion> DrinkPromotion { get; set; }
        public virtual ICollection<OrderDrink> OrderDrink { get; set; }
    }
}
