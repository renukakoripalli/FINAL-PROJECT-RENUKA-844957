﻿using AdminServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminServices.Repositories;

namespace AdminServices.Repositories
{
    public interface IAdminRepository
    {
        public void AddCategories(Category cat);
        public void AddSubCategories(Subcategory scat);
        public void DeleteCategory(string categoryid);
        public void DeleteSubCategory(string subcategoryid);
        List<Category> ViewCategory();
        
        List<Subcategory> ViewSubCategory();
        public List<Category> GetCategories();
    }
}