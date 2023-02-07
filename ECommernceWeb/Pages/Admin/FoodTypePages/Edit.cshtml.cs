using Ecommerce.DataAccess.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages.Admin.FoodTypePages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        [BindProperty]
        public FoodType FoodType { get; set; }

        public EditModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task OnGet(int id)
        {
            FoodType = await dbContext.FoodTypes.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                dbContext.FoodTypes.Update(FoodType);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Food Type Updated Successfully";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
