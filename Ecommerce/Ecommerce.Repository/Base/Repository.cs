using Dapper.Contrib.Extensions;
using Ecommerce.Domain.Entity.Interfaces;
using Ecommerce.Repository.Interface;
using Ecommerce.Repository.Util;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Data;

namespace Ecommerce.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly IConfiguration _config;
        public Repository(IConfiguration config)
        {
            _config = config;
        }

        public virtual long Insert(T entity)
        {
            using (var conn = new ConnectionFactory().GetConnection(_config.GetConnectionString("DefaultConnection")))
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var id = conn.Insert<T>(entity);
                        transaction.Commit();
                        return id;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

            }
        }

        public virtual bool Update(T entity)
        {
            using (var conn = new ConnectionFactory().GetConnection(_config.GetConnectionString("DefaultConnection")))
            {
                if (entity.Id == 0)
                {
                    entity.Id = Get(entity.Key)?.Id ?? 0;
                }
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        bool ret = conn.Update<T>(entity);
                        transaction.Commit();
                        return ret;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public virtual T Get(long id)
        {
            using (var conn = new ConnectionFactory().GetConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return conn.Get<T>(id);
            }
        }

        public virtual T Get(Guid key)
        {
            return this.GetAll().FirstOrDefault(x => x.Key == key);
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var conn = new ConnectionFactory().GetConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return conn.GetAll<T>();
            }
        }

        public virtual bool Delete(T entity)
        {
            using (var conn = new ConnectionFactory().GetConnection(_config.GetConnectionString("DefaultConnection")))
            {
                if (entity.Id == 0)
                {
                    entity.Id = Get(entity.Key)?.Id ?? 0;
                }
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        bool ret = conn.Delete<T>(entity);
                        transaction.Commit();
                        return ret;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }

                }
            }
        }

    }
}
