using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SingalPageCrud.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Product Name")]
        public string? Name { get; set; }

        public string? Description { get; set; }
        public string? color { get; set; }

        public int price { get; set; }

        public string? image { get; set; }


    }
}
