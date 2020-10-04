using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SnackPros.DataAccess.Data.Repository.IRepository;
using SnackPros.Models;

namespace SnackPros.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Define MenuItem & Category properties here isntead of the view model approach. 
        public IEnumerable<MenuItem> MenuItemList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }

        public void OnGet()
        {
            MenuItemList = _unitOfWork.MenuItem.GetAll(null, null, "Category,SnackType");
            // ordered definition here for Category items by ascending order
            CategoryList = _unitOfWork.Category.GetAll(null, q => q.OrderBy(c => c.DisplayOrder), null);
        }
    }
}
