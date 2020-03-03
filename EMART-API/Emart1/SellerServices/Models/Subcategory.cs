using System;
using System.Collections.Generic;

namespace SellerServices.Models
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            Items = new HashSet<Items>();
        }

        public string Subcategoryid { get; set; }
        public string Subcategoryname { get; set; }
        public string Categoryid { get; set; }
        public string Briefdetails { get; set; }
        public int Gst { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Items> Items { get; set; }
    }
}
