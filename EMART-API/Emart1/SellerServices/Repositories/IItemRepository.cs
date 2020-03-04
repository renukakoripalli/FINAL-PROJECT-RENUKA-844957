using SellerServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerServices.Repositories
{
    public interface IItemRepository
    {
        void AddItem(Items obj);
        List<Items> Viewitems(string id);
        void DeleteItem(string Iid);
        void UpdateItem(Items obj);
        Items GetItems(string Iid);
        List<Category> GetCategory();
        List<Subcategory> GetSubCagegory(string categoryid);

    }
}
