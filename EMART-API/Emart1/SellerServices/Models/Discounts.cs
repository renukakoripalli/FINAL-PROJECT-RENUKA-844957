using System;
using System.Collections.Generic;

namespace SellerServices.Models
{
    public partial class Discounts
    {
        public string Did { get; set; }
        public string DiscountCode { get; set; }
        public double Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
