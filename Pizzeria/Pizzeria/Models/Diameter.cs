using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Diameter
    {
        public Diameter()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int DiameterId { get; set; }
        public int Number { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
