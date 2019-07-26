using Ecommerce.Domain.Entity;
using Ecommerce.Repository.Base;
using Ecommerce.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IConfiguration config) : base(config)
        {
        }
    }
}
