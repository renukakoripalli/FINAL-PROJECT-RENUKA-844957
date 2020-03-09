using System;
using System.Collections.Generic;

namespace SellerServices.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            Cart = new HashSet<Cart>();
            Purchase = new HashSet<Purchase>();
        }

        public string Bid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Emailid { get; set; }
        public string Mobilenumber { get; set; }
        public DateTime Createddatetime { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
