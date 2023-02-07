using Ecommerce.DataAccess.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommernceWeb.Pages.CategoryPages
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task OnGet(int id)
        {
            Category = await dbContext.Categories.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = dbContext.Categories.Find(Category.Id);
            if (categoryFromDb != null)
            {
                dbContext.Categories.Remove(categoryFromDb);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Category Deleted Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
