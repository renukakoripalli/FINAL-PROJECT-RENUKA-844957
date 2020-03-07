﻿using System;
using System.Collections.Generic;

namespace AdminServices.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            Purchase = new HashSet<Purchase>();
        }

        public string Bid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Emailid { get; set; }
        public string Mobilenumber { get; set; }
        public DateTime Createddatetime { get; set; }

        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}