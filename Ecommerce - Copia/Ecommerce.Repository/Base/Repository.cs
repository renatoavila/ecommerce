using Ecommerce.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
    {

        public Repository()
        {
        }

        public object Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public object Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TEntity> Select()
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
