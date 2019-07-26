using Ecommerce.Domain.Entity.Interfaces;
using System;

namespace Ecommerce.Domain.Interface
{
    public abstract class Entity : IEntity
    {
        public Entity()
        {
            Key = Guid.NewGuid();
        }
        public int Id { get; set; }
        public Guid Key { get; set; }

    }
}
