using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class SaucePromotion
    {
        public int PromotionId { get; set; }
        public int SauceId { get; set; }

        public virtual Promotion Promotion { get; set; }
        public virtual Sauce Sauce { get; set; }
    }
}
