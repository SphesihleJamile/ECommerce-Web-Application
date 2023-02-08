using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repositories.Abstract;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceWeb.Pages.Admin.Upsert
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            this._unitOfWork = unitOfWork;
            MenuItem = new MenuItem();
            _hostEnvironment = hostEnvironment;
        }

        public void OnGet()
        {
            CategoryList = _unitOfWork.Category.GetAll().Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString()
            });
            FoodTypeList = _unitOfWork.FoodType.GetAll().Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString()
            });
        }

        public async Task<IActionResult> OnPost()
        {
            string webRootPath = _hostEnvironment.WebRootPath; //this is the wwwroot folder path
            var files = HttpContext.Request.Form.Files; //capture all the uploaded files
            if(MenuItem.Id == 0)
            {
                //this is a create request
                string filename_new = Guid.NewGuid().ToString();
                var uploadPath = Path.Combine(webRootPath, @"Images\menuItems");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploadPath, filename_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                MenuItem.ImagePath = @"Images\menuItems\" + filename_new + extension;
                _unitOfWork.MenuItem.Add(MenuItem);
                _unitOfWork.Save();
            }
            else
            {
                //this is an edit request
            }
            return Page();
        }
    }
}
