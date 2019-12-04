using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class OrderPizza
    {
        public int PizzaId { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
