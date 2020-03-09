using System;
using System.Collections.Generic;

namespace AccountServices.Models
{
    public partial class Purchase
    {
        public string Pid { get; set; }
        public string Sid { get; set; }
        public string Bid { get; set; }
        public string Iid { get; set; }
        public string Transactiontype { get; set; }
        public int Noofitems { get; set; }
        public DateTime Datetime { get; set; }
        public string Remarks { get; set; }
        public string Transactionstatus { get; set; }

        public virtual Buyer B { get; set; }
        public virtual Items I { get; set; }
        public virtual Seller S { get; set; }
    }
}
