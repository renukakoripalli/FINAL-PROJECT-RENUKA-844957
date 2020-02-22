﻿using SellerServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerServices.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly EmartDBContext _context;
        public SellerRepository(EmartDBContext context)
        {
            _context = context;
        }
        public void EditProfile(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller GetProfile(string sid)
        {
            return _context.Seller.Find(sid);
        }
    }
}
    
        