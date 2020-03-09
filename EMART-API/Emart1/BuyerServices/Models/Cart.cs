using System;
using System.Collections.Generic;

namespace BuyerServices.Models
{
    public partial class Cart
    {
        public string Cartid { get; set; }
        public string Iid { get; set; }
        public string Bid { get; set; }
        public string Categoryid { get; set; }
        public string Subcategoryid { get; set; }
        public int Price { get; set; }
        public string Itemname { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string Remarks { get; set; }
        public string Photo { get; set; }

        public virtual Buyer B { get; set; }
        public virtual Category Category { get; set; }
        public virtual Items I { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
}
