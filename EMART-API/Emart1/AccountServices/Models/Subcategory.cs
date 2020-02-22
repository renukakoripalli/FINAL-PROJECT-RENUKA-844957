using System;
using System.Collections.Generic;

namespace AccountServices.Models
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            Items = new HashSet<Items>();
        }

        public string SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryId { get; set; }
        public string Briefdetails { get; set; }
        public double Gst { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
