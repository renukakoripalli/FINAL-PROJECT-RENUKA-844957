using System;
using System.Collections.Generic;

namespace AdminServices.Models
{
    public partial class Items
    {
        public Items()
        {
            Purchase = new HashSet<Purchase>();
        }

        public string Iid { get; set; }
        public string Categoryid { get; set; }
        public string Subcategoryid { get; set; }
        public int Price { get; set; }
        public string Itemname { get; set; }
        public string Description { get; set; }
        public int Stocknumber { get; set; }
        public string Remarks { get; set; }
        public byte[] Photo { get; set; }
        public string Sid { get; set; }

        public virtual Category Category { get; set; }
        public virtual Seller S { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
