using System;
using System.Collections.Generic;

namespace ProductsAndCategories.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime  CreatedAt { get; set; }
        public DateTime  UpdatedAt { get; set; }
        public List<Association> ProductedCategories{ get; set; }
    }

}