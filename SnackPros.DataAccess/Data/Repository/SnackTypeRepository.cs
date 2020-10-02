using Microsoft.AspNetCore.Mvc.Rendering;
using SnackPros.DataAccess.Data.Repository.IRepository;
using SnackPros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnackPros.DataAccess.Data.Repository
{
    public class SnackTypeRepository : Repository<SnackType>, ISnackTypeRepository
    {

        private readonly ApplicationDbContext _db;
        public SnackTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetSnackTypeListForDropDown()
        {
            return _db.SnackType.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(SnackType snackType)
        {
            var objFromDb = _db.SnackType.FirstOrDefault(s => s.Id == snackType.Id);

            objFromDb.Name = snackType.Name;
            _db.SaveChanges();
        }
    }
}
