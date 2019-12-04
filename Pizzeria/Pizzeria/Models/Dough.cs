using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Dough
    {
        public Dough()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int DoughId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
