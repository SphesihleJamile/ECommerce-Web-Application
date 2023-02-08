using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repositories.Abstract;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repositories.Concrete
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext dbContext;

        public MenuItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Update(MenuItem menuItem)
        {
            var objFromDB = dbContext.MenuItem.FirstOrDefault(U => U.Id == menuItem.Id);
            objFromDB.Name = menuItem.Name;
            objFromDB.Decription = menuItem.Decription;
            objFromDB.ImagePath = menuItem.ImagePath;
            objFromDB.Price = menuItem.Price;
            objFromDB.CategoryId = menuItem.CategoryId;
            objFromDB.FoodTypeId = menuItem.FoodTypeId;
            if(objFromDB.ImagePath != null)
            {
                objFromDB.ImagePath = menuItem.ImagePath;
            }
        }
    }
}
