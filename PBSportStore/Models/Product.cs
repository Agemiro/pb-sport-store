using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBSportStore.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Inform the product name")]
        [Display(Name = "Product name")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "The {0} must be at least {1} and at most {2}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Inform the description")]
        [Display(Name = "Description")]
        [MinLength(20, ErrorMessage = "The description must have at least {1} characters")]
        [MaxLength(200, ErrorMessage = "The description must have at most {1} characters")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Inform the description")]
        [Display(Name = "Description")]
        [MinLength(20, ErrorMessage = "The detailed description must have at least {1} characters")]
        [MaxLength(200, ErrorMessage = "The detailed description must have at most {1} characters")]
        public string DetailedDescription { get; set; }

        [Required(ErrorMessage = "Inform the price")]
        [Display(Name = "Price")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99, ErrorMessage = "The price must be between 1 and 999,99")]
        public decimal Price { get; set; }

        [Display(Name = "Normal image path")]
        [StringLength(200, ErrorMessage = "The {0} must be at most {1} characters")]
        public string ImageUrl { get; set; }

        [Display(Name = "Thumbnail image path")]
        [StringLength(200, ErrorMessage = "The {0} must be at most {1} characters")]
        public string ImageThumbnailUrl { get; set; }

        [Display(Name = "Favorite")]
        public bool IsFavoriteProduct { get; set; }

        [Display(Name = "Stock")]
        public bool InStock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
