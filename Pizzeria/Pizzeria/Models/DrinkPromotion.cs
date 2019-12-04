using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class DrinkPromotion
    {
        public int DrinkId { get; set; }
        public int PromotionId { get; set; }

        public virtual Drink Drink { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
