﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountServices
{
    public class Token
    {
        public string msg { get; set; }
        public string username { get; set; }
        public string token { get; set; }
       
        public string SellerId { get; set; }
        public string Bid { get; set; }
    }
}