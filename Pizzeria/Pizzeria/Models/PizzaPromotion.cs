using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class PizzaPromotion
    {
        public int PromotionId { get; set; }
        public int PizzaId { get; set; }

        public virtual Pizza Pizza { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
