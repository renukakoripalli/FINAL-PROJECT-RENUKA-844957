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

        public string loginb(string name, string pass)
        {
            var s = _context.Buyer.SingleOrDefault(e => e.Username == name && e.Password == pass);
            if (s != null)
            {
                return "exists";
            }
            else
            {
                return "false";
            }
        }

        public string logins(string name, string pass)
        {
            var s = _context.Seller.Where(e => e.Username == name && e.Password == pass).ToList();
            if (s.Count != 0)
            {
                return "exists";
            }
            else
            {
                return "false";
            }
        }
    }
}
