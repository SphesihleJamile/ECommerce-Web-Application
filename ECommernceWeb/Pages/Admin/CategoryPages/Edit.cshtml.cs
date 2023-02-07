using Ecommerce.DataAccess.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommernceWeb.Pages.Admin.CategoryPages
{
    public class EditCategoryModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        [BindProperty]
        public Category Category { get; set; }

        public EditCategoryModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task OnGet(int id)
        {
            Category = await dbContext.Categories.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Category Name and Display Order cannot have the exact same value");
            }
            if(ModelState.IsValid)
            {
                dbContext.Categories.Update(Category);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
