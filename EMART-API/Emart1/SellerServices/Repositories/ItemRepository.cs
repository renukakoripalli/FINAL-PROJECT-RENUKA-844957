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

        public void DeleteItem(string sid)
        {
            Items item = _context.Items.Find(sid);
            _context.Remove(item);
            _context.SaveChanges();
        }

        public Items GetItems(string Iid)
        {
            return _context.Items.Find(Iid);
        }

        public void UpdateItem(Items obj)
        {
            _context.Items.Update(obj);
            _context.SaveChanges();
        }

        public List<Items> ViewItems(string id)
        {
            var s = _context.Items.Where(s => s.Sid == id).ToList();

            return s;
        }
    }
}
