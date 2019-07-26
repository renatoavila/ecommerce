using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Interface
{
    public interface IRepository<T>
    {
        long Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
    }
}
