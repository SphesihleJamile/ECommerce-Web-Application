using Ecommerce.DataAccess.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommernceWeb.Pages.Admin.CategoryPages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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
                await dbContext.Categories.AddAsync(Category);
                await dbContext.SaveChangesAsync();
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