﻿using SnackPros.DataAccess.Data.Repository.IRepository;
using SnackPros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnackPros.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            SnackType = new SnackTypeRepository(_db);
            MenuItem = new MenuItemRepository(_db);
        }

        public  ICategoryRepository Category { get; private set; } // DO NOT set outside of this 
        public ISnackTypeRepository SnackType { get; private set; } // DO NOT set outside of this 

        public IMenuItemRepository MenuItem { get; private set; } // DO NOT set outside of this 

        //Implement Save()
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
