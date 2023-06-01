using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBSportStore.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(100,ErrorMessage = "The minimum length is 100 characters")]
        [Required(ErrorMessage = "Inform the category name")]
        [Display(Name = "Name")]
        public string CategoryName { get; set; }
        [StringLength(200, ErrorMessage = "The minimum length is 200 characters")]
        [Required(ErrorMessage = "Inform the description name")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        public List<Product> Products { get; set;}
    }
}
