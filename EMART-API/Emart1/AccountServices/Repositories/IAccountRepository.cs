using AccountServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountServices.Repositories
{
    public interface IAccountRepository
    {
        public void addb(Buyer item);
        public void adds(Seller items);

        public string loginb(string name, string pass);
        public string logins(string name, string pass);
    }
}
