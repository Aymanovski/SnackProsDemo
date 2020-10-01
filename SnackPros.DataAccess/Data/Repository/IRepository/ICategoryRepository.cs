using Microsoft.AspNetCore.Mvc.Rendering;
using SnackPros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnackPros.DataAccess.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(Category category);
    }
}
