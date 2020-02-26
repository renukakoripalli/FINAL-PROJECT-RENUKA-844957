using AdminServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminServices.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly EmartDBContext conn;
        public AdminRepository(EmartDBContext con)
        {
            conn = con;
        }
        public void AddCategories(Category cat)
        {
            conn.Category.Add(cat);
            conn.SaveChanges();
        }

        public void AddSubCategories(Subcategory scat)
        {
            conn.Subcategory.Add(scat);
            conn.SaveChanges();
        }
    }
}
