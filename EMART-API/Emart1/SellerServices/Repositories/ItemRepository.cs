using SellerServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerServices.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly EmartDBContext _context;
        public ItemRepository(EmartDBContext context)
        {
            _context = context;
        }
        public void AddItem(Items obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteItem(string Iid)
        {
            Items item = _context.Items.Find(Iid);
            _context.Remove(item);
            _context.SaveChanges();
        }

        public List<Category> GetCategory()
        {
            return _context.Category.ToList();
        }

        public Items GetItems(string Iid)
        {
            return _context.Items.Find(Iid);
        }

        public List<Subcategory> GetSubCagegory(string categoryid)
        {
            return _context.Subcategory.Where(c => c.Categoryid == categoryid).ToList();
        }

        public void UpdateItem(Items obj)
        {
            _context.Items.Update(obj);
            _context.SaveChanges();
        }

        public List<Items> Viewitems(string id)
        {
            return _context.Items.Where(e=>e.Sid==id).ToList();
        }
    }
}
