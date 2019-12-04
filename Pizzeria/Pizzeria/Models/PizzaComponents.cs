using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class PizzaComponents
    {
        public int ComponentsId { get; set; }
        public int PizzaId { get; set; }

        public virtual Components Components { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
