using AccountServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountServices.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EmartDBContext _context;
        public AccountRepository(EmartDBContext con)
        {
            _context = con;
        }
        public void addb(Buyer item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void adds(Seller items)
        {
            _context.Add(items);
            _context.SaveChanges();
        }

      

        public Seller logins(string username, string pass)
        {
            var y = _context.Seller.SingleOrDefault(e => e.Username == username && e.Password == pass);
            if (y != null)
            {
                return y;
            }
            else
            {
                return null;
            }
        }

        public Buyer BuyerLogin(string username, string pass)
        {
            var x = _context.Buyer.SingleOrDefault(e => e.Username == username && e.Password == pass);
            if (x != null)
            {
                
                return x;
            }
            else
            {
                return null;
            }

        }

        

    
}
}
