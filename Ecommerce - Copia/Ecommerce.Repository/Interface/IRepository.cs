using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Interface
{
    public interface IRepository<TEntity>
    {
        object Insert(TEntity entity);
        object Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
    }
}
