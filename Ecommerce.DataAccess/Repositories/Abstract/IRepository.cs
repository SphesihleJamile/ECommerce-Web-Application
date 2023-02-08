using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
        //Get All, Get By Id Firt or Default, Add, Remove, RemoveRange

        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Add(IEnumerable<T> entities);
        IEnumerable<T> GetAll();
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);
    }
}
