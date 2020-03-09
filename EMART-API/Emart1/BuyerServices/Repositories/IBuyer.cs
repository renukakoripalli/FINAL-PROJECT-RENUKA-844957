using BuyerServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyerServices.Repositories
{
    public interface IBuyer
    {
        List<Items> search(string items);
        void BuyItem(Purchase purchase);
        void Editprofile(Buyer buyer);
        Buyer GetProfile(string bid);
        List<Items> SearchByCategoryId(string categoryid);
        List<Subcategory> GetSubCategories(string categories);
        List<Buyer> Getall();
        List<Purchase> PurchaseHistory(string bid);
        List<Items> GetAllItems();
        List<Category> GetCategories();
        void AddToCart(Cart cart);
        List<Cart> GetCartItems();
        void DeleteCartItem(string Cartid);
        Cart Getcartitembyid(string Cartid);



    }
}