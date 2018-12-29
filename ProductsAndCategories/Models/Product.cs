using System;
using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime  CreatedAt { get; set; }
        public DateTime  UpdatedAt { get; set; }
        public List<Association> CategorizedProducts { get; set; }
    }

}