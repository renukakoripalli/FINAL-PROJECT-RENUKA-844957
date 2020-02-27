using System;
using System.Collections.Generic;

namespace BuyerServices.Models
{
    public partial class Category
    {
        public Category()
        {
            Items = new HashSet<Items>();
            Subcategory = new HashSet<Subcategory>();
        }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BriefDetails { get; set; }

        public virtual ICollection<Items> Items { get; set; }
        public virtual ICollection<Subcategory> Subcategory { get; set; }
    }
}
