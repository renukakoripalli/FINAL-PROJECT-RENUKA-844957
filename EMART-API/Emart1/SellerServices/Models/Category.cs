using System;
using System.Collections.Generic;

namespace SellerServices.Models
{
    public partial class Category
    {
        public Category()
        {
            Items = new HashSet<Items>();
            Subcategory = new HashSet<Subcategory>();
        }

        public string Categoryid { get; set; }
        public string Categoryname { get; set; }
        public string Briefdetails { get; set; }

        public virtual ICollection<Items> Items { get; set; }
        public virtual ICollection<Subcategory> Subcategory { get; set; }
    }
}
