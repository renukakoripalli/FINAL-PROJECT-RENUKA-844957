using BuyerServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyerServices.Repositories
{
    public class BuyerRep : IBuyer
    {
        private readonly EmartDBContext conn;
        public BuyerRep(EmartDBContext con)
        {
            conn = con;
        }

        public void BuyItem(Purchase purchase)
        {
            conn.Add(purchase);
            conn.SaveChanges();
        }

        public void Editprofile(Buyer buyer)
        {
            conn.Buyer.Update(buyer);
            conn.SaveChanges();
        }

        public List<Buyer> Getall()
        {
            return conn.Buyer.ToList();
        }

        public List<Category> GetCategories()
        {
            return conn.Category.ToList();
        }

        public Buyer GetProfile(string bid)
        {
            Buyer b = conn.Buyer.SingleOrDefault(e => e.Bid== bid);
            return b;
        }

      
        public List<Subcategory> GetSubCategories(string categories)
        {
            var subCategory = conn.Subcategory.Where(e => e.Categoryid ==categories).ToList();
            return subCategory;
        }

        public List<Purchase> PurchaseHistory(string bid)
        {
            var b = conn.Purchase.Where(e => e.BuyerId == bid).ToList();
            return b;
        }

        

        public List<Items> search(string items)
        {
            var e = conn.Items.Where(e => e.Itemname == items).ToList();
            return e;
        }
    }
}
       
