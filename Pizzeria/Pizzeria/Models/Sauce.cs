using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Sauce
    {
        public Sauce()
        {
            OrderSauce = new HashSet<OrderSauce>();
            SaucePromotion = new HashSet<SaucePromotion>();
        }

        public int SauceId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderSauce> OrderSauce { get; set; }
        public virtual ICollection<SaucePromotion> SaucePromotion { get; set; }
    }
}
