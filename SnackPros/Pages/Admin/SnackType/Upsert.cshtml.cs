using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SnackPros.DataAccess.Data.Repository.IRepository;

namespace SnackPros.Pages.Admin.SnackType
{
    public class UpsertModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.SnackType SnackTypeObj { get; set; }


        public IActionResult OnGet(int? id)
        {
            SnackTypeObj = new Models.SnackType();
            if (id != null)
            {
                SnackTypeObj = _unitOfWork.SnackType.GetFirstOrDefault(u => u.Id == id);
                if (SnackTypeObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (SnackTypeObj.Id == 0)
            {
                _unitOfWork.SnackType.Add(SnackTypeObj);
            }
            else
            {
                _unitOfWork.SnackType.Update(SnackTypeObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }



    }
}
