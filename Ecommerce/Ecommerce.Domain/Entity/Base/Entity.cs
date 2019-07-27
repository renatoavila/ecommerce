using Dapper.Contrib.Extensions;
using Ecommerce.Domain.Entity.Interfaces;
using Flunt.Notifications;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
namespace Ecommerce.Domain.Entity.Base
{
    public class Entity : Notifiable, IEntity
    {
        public Entity()
        {
            //Key = Guid.NewGuid();
        }

        [Key]
        public long Id { get; set; }


        private Guid key;
        public Guid Key
        {
            get
            {
               if(key == null || key == Guid.Empty)
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


        // Write: Fazer o Dapper ignorar essa propriedade 
        [Write(false)]
        [JsonIgnore]
        public IReadOnlyCollection<Notification> Notifications
        {
            get
            {
                return base.Notifications;
            }
        }

        [Write(false)]
        [JsonIgnore]
        public bool Invalid
        {
            get
            {
                return base.Invalid;
            }
        }

        [Write(false)]
        [JsonIgnore]
        public bool Valid
        {
            get
            {
                return base.Valid;
            }
        }

    }
}
