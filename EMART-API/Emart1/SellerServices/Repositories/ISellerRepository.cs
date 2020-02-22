using SellerServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerServices.Repositories
{
    public interface ISellerRepository
    {
        void EditProfile(Seller obj);
        Seller GetProfile(string sid);
    }
}
