using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repositories.Abstract;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client.Extensibility;

namespace ECommernceWeb.Pages.Admin.CategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Category> CategoryList { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            CategoryList = _unitOfWork.Category.GetAll();
        }
    }
}
