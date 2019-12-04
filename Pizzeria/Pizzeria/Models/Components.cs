using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Components
    {
        public Components()
        {
            PizzaComponents = new HashSet<PizzaComponents>();
        }

        public int ComponentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PizzaComponents> PizzaComponents { get; set; }
    }
}
