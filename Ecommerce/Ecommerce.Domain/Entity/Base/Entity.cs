using Dapper.Contrib.Extensions;
using Ecommerce.Domain.Entity.Interfaces;
using Ecommerce.Domain.Notifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Entity.Base
{
    public class Entity : Notifiable, IEntity
    {
        [Key]
        [JsonIgnore]
        public long Id { get; set; }

        private Guid _key;
        public Guid Key
        {
            get
            {
                if (_key == null || _key == Guid.Empty)
                {
                    _key = Guid.NewGuid();
                }
                return _key;
            }
            set
            {
                _key = value;
            }
        }
    }
}
