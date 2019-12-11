using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Nazwa jest wymagana!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Grubość ciasta jest wymagana!")]
        public int DoughId { get; set; }
        [Required(ErrorMessage = "Rozmiar jest wymagany!")]
        public int DiameterId { get; set; }
        [Required(ErrorMessage = "Informacja, czy pizza jest w Menu jest wymagana!")]
        public bool InMenu { get; set; }

        public virtual Diameter Diameter { get; set; }
        public virtual Dough Dough { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual ICollection<PizzaComponents> PizzaComponents { get; set; }
        public virtual ICollection<PizzaPromotion> PizzaPromotion { get; set; }
    }
}
