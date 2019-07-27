using Dapper.Contrib.Extensions;
using Ecommerce.Domain.Entity.Interfaces;
using Ecommerce.Repository.Interface;
using Ecommerce.Repository.Util;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Text;

namespace Ecommerce.Repository.Base
{    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IConfiguration _config;

        public Repository(IConfiguration config)
        {
            _config = config;
        }

        public long Insert(T entity)
        { 
            using (var conn = new ConnectionFactory().GetConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return conn.Insert<T>(entity);
            }
        }

        public bool Update(T entity)
        {
            using (var conn = new ConnectionFactory().GetConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return conn.Update<T>(entity);
            }
        } 

        public T Get(int id)
        {
            using (var conn = new ConnectionFactory().GetConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return conn.Get<T>(id);
            }
        }

        public T Get(Guid key)
        {
            using (var conn = new ConnectionFactory().GetConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return conn.Get<T>(key);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var conn = new ConnectionFactory().GetConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return conn.GetAll<T>();
            }
        }

        public bool Delete(T entity)
        {
            using (var conn = new ConnectionFactory().GetConnection(_config.GetConnectionString("DefaultConnection")))
            {
                return conn.Delete<T>(entity);
            }
        }

    }
}
