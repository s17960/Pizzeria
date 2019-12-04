using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderPizza = new HashSet<OrderPizza>();
            PizzaComponents = new HashSet<PizzaComponents>();
            PizzaPromotion = new HashSet<PizzaPromotion>();
        }

        public int PizzaId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DoughId { get; set; }
        public int DiameterId { get; set; }
        public bool InMenu { get; set; }

        public virtual Diameter Diameter { get; set; }
        public virtual Dough Dough { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual ICollection<PizzaComponents> PizzaComponents { get; set; }
        public virtual ICollection<PizzaPromotion> PizzaPromotion { get; set; }
    }
}
