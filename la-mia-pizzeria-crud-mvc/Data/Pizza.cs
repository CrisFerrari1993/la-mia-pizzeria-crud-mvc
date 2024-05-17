using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crud_mvc.Data
{
    public class Pizza
    {
        [Key] public int PizzaId { get; set; }
        [StringLength(50, ErrorMessage = "Il nome della pizza non può superare i 50 caratteri")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Name { get; set; }
        [MinLength(5, ErrorMessage = "Il campo descrizione deve contenere più di 5 caratteri")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]

        public string Description { get; set; }
        [Range(0.01 ,100, ErrorMessage = "Il prezzo deve essere positivo e non superiore a €100")]
        [Required(ErrorMessage = "Il campo è obbligatorio")]

        public float Price { get; set; }
        public string? ImgPath { get; set; }

        public Pizza(){}

        public Pizza(string name, string description, float price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
