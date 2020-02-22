using System.Linq;
using EMart.AccountService.Models;

namespace EMart.AccountService.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EmartDBContext _context;
        public AccountRepository(EmartDBContext context)
        {
            _context = context;
        }
        public bool BuyerLogin(string username, string password)
        {
            Buyer b = _context.Buyer.SingleOrDefault(bu => bu.Username == username && bu.Password == password);
            if (b != null)
            {
                return true;
            }
            else
                return false;
        }

        public void BuyerRegister(Buyer obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public bool SellerLogin(string username, string password)
        {
            Seller s = _context.Seller.SingleOrDefault(se => se.Username == username && se.Password == password);
            if (s != null)
            {
                return true;
            }
            else
                return false;

        }

        public void SellerRegister(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}


