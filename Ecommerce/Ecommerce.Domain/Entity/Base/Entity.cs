using Ecommerce.Domain.Entity.Interfaces;
using Flunt.Notifications;
using System;

namespace Ecommerce.Domain.Entity.Base
{
    public class Entity : Notifiable, IEntity
    {
        public Entity()
        {
            Key = Guid.NewGuid();
        }
        public long Id { get; set; }
        public Guid Key { get; set; }

    }
}
