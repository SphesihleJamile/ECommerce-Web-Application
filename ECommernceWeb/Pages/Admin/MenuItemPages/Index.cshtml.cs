using Ecommerce.DataAccess.Repositories.Abstract;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWeb.Pages.Admin.MenuItemPages
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<MenuItem> MenuItems { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            MenuItems = _unitOfWork.MenuItem.GetAll();
        }
    }
}
