using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.ViewModels {
    public class CategoryViewModel {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MinLength(2, ErrorMessage = "Category Name must be at least 2 characters long")]
        public string CategoryName { get; set; }
    }
}