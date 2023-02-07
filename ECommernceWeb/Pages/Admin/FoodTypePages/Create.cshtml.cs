using Ecommerce.DataAccess.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages.Admin.FoodTypePages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        [BindProperty]
        public FoodType FoodType { get; set; }

        public CreateModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await dbContext.FoodTypes.AddAsync(FoodType);
                await dbContext.SaveChangesAsync();
                TempData["success"] = "Food Type Added Successfuly";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
