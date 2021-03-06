﻿using AdminServices.Models;
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
        public List<Category> GetCategories()
        {
            return conn.Category.ToList();
        }

        public void AddSubCategories(Subcategory scat)
        {
            conn.Subcategory.Add(scat);
            conn.SaveChanges();
        }

        public void DeleteCategory(string categoryid)
        {
            Category c = conn.Category.Find(categoryid);
           conn.Remove(c);
            conn.SaveChanges();
        }

        public void DeleteSubCategory(string subcategoryid)
        {
            Subcategory sub = conn.Subcategory.Find(subcategoryid);
            conn.Remove(sub);
           conn.SaveChanges();
        }

        public List<Category> ViewCategory()
        {
            return conn.Category.ToList();
        }

        public List<Subcategory> ViewSubCategory()
        {
            return conn.Subcategory.ToList();
        }

        public Category Getbycatid(string categoryid)
        {
            Category c = conn.Category.SingleOrDefault(e => e.Categoryid == categoryid);
            return c;
        }
        public Subcategory Getbyscatid(string subcategoryid)
        {
            Subcategory r = conn.Subcategory.SingleOrDefault(e => e.Subcategoryid == subcategoryid);
            return r;
        }

        public void EditCategory(Category category)
        {
            conn.Category.Update(category);
            conn.SaveChanges();
        }

        public void EditSubcategory(Subcategory subcategory)
        {
            conn.Subcategory.Update(subcategory);
            conn.SaveChanges();
        }
    }
}
