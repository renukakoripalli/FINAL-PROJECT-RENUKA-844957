using System;
using System.Collections.Generic;

namespace EMart.AccountService.Models
{
    public partial class Purchase
    {
        public string PId { get; set; }
        public string BuyerId { get; set; }
        public string SellerId { get; set; }
        public string ItemId { get; set; }
        public string TransactionType { get; set; }
        public int NumberOfItems { get; set; }
        public DateTime DateTime { get; set; }
        public string Remarks { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Items Item { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
