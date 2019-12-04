using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Order = new HashSet<Order>();
        }

        public int PaymentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
