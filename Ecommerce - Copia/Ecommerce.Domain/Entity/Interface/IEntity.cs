using System;

namespace Ecommerce.D.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        Guid Key { get; set; }
    }
}
