using Dapper.Contrib.Extensions;
using Ecommerce.Domain.Entity.Interfaces;
using Ecommerce.Domain.Notifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.Entity.Base
{
    public class Entity : Notifiable, IEntity
    {
        [Key]
        [JsonIgnore]
        public long Id { get; set; }

        private Guid key;
        public Guid Key
        {
            get
            {
                if (key == null || key == Guid.Empty)
                {
                    key = Guid.NewGuid();
                }
                return key;
            }
            set
            {
                key = value;
            }
        }
    }
}
