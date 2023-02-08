using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repositories.Abstract;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommernceWeb.Pages.Admin.CategoryPages
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unityOfWork;

        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            this._unityOfWork = unitOfWork;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Category Name and Display Order cannot have the exact same value");
            }
            if(ModelState.IsValid)
            {
                _unityOfWork.Category.Add(Category);
                _unityOfWork.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
