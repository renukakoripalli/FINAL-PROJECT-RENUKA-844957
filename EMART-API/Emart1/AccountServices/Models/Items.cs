using System;
using System.Collections.Generic;

namespace AccountServices.Models
{
    public partial class Items
    {
        public Items()
        {
            Purchase = new HashSet<Purchase>();
        }

        public string Iid { get; set; }
        public string CategoryId { get; set; }
        public string SubcategoryId { get; set; }
        public int Price { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int StockNumber { get; set; }
        public string Remarks { get; set; }
        public string Sid { get; set; }
        public byte[] Photo { get; set; }

        public virtual Category Category { get; set; }
        public virtual Seller S { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
