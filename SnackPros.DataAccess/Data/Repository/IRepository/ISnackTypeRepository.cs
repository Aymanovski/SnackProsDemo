using Microsoft.AspNetCore.Mvc.Rendering;
using SnackPros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnackPros.DataAccess.Data.Repository.IRepository
{
    public interface ISnackTypeRepository : IRepository<SnackType>
    {
        IEnumerable<SelectListItem> GetSnackTypeListForDropDown();

        void Update(SnackType snackType);
    }
}
