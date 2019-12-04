using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Promotion
    {
        public Promotion()
        {
            DrinkPromotion = new HashSet<DrinkPromotion>();
            PizzaPromotion = new HashSet<PizzaPromotion>();
            SaucePromotion = new HashSet<SaucePromotion>();
        }

        public int PromotionId { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<DrinkPromotion> DrinkPromotion { get; set; }
        public virtual ICollection<PizzaPromotion> PizzaPromotion { get; set; }
        public virtual ICollection<SaucePromotion> SaucePromotion { get; set; }
    }
}
