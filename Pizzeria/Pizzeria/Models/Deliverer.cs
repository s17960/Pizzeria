using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Deliverer
    {
        public Deliverer()
        {
            Order = new HashSet<Order>();
        }

        public int DelivererId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
