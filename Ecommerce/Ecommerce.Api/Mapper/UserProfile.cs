using AutoMapper;
using Ecommerce.Api.Model;
using Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Api.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Client, ClientModel>();
            CreateMap<ClientModel, Client>();
            CreateMap<AddressModel, Address>();
            CreateMap<Address, AddressModel>();
        }
    }
}
