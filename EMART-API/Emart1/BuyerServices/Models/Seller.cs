﻿using System;
using System.Collections.Generic;

namespace BuyerServices.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Items = new HashSet<Items>();
            Purchase = new HashSet<Purchase>();
        }

        public string Sid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Companyname { get; set; }
        public string Gstin { get; set; }
        public string Briefaboutcompany { get; set; }
        public string Postaladdress { get; set; }
        public string Website { get; set; }
        public string Emailid { get; set; }
        public string Contactnumber { get; set; }

        public virtual ICollection<Items> Items { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
