using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.ViewModels {
    public class ProductViewModel {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MinLength(2, ErrorMessage = "Product Name must be at least 2 characters long")]
        public string ProductName { get; set; }


        [Required(ErrorMessage = "Required Field")]
        [MinLength(2, ErrorMessage = "Description must be at least 2 characters long")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Required Field")]
        public int Price { get; set; }

    }
}