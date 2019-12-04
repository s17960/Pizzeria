using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDrink = new HashSet<OrderDrink>();
            OrderPizza = new HashSet<OrderPizza>();
            OrderSauce = new HashSet<OrderSauce>();
        }

        public int OrderId { get; set; }
        public string Street { get; set; }
        public int HouseNumberer { get; set; }
        public int? FlatNumber { get; set; }
        public DateTime Date { get; set; }
        public int PaymentId { get; set; }
        public int DelivererId { get; set; }

        public virtual Deliverer Deliverer { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ICollection<OrderDrink> OrderDrink { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual ICollection<OrderSauce> OrderSauce { get; set; }
    }
}
