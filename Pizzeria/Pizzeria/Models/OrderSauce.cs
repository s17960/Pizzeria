using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class OrderSauce
    {
        public int OrderId { get; set; }
        public int SauceId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Sauce Sauce { get; set; }
    }
}
