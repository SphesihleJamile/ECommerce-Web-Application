using Ecommerce.DataAccess.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages.Admin.FoodTypePages
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        [BindProperty]
        public FoodType FoodType { get; set; }

        public DeleteModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task OnGet(int id)
        {
            FoodType = await dbContext.FoodTypes.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var foodTypeFromDb = await dbContext.FoodTypes.FindAsync(FoodType.Id);
            if (foodTypeFromDb != null)
            {
                dbContext.FoodTypes.Remove(foodTypeFromDb);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Food Item Deleted Successfully";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
