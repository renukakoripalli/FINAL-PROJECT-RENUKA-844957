using EMart.AccountService.Models;
namespace EMart.AccountService.Repositories
{
    public interface IAccountRepository
    {
        public bool BuyerLogin(string username, string password);
        public bool SellerLogin(string username,string password);
       public void SellerRegister(Seller obj);
       public void BuyerRegister(Buyer obj);
    }
}
