using Ecommerce.DataAccess.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.Pages.Admin.FoodTypePages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        public IEnumerable<FoodType> FoodType { get; set; }

        public IndexModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task OnGet()
        {
            FoodType = await dbContext.FoodTypes.ToListAsync();
        }
    }
}
