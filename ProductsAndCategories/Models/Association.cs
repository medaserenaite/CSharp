using System;
namespace ProductsAndCategories.Models
{
    public class Association
    {
        public int AssociationID { get; set; }
        public int ProductID { get; set; }
        public Product ProductToJoin { get; set; }
        public int CategoryID { get; set; }
        public Category CategoryToJoin { get; set; }
        public DateTime  CreatedAt { get; set; }
        public DateTime  UpdatedAt { get; set; }
    }

}