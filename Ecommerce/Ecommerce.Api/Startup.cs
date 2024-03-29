﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Business;
using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
using Ecommerce.Integration;
using Ecommerce.Integration.Inferface;
using Ecommerce.Repository;
using Ecommerce.Repository.Interface;
using Ecommerce.Service;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger; 

namespace Ecommerce.Api
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Startup'
    public class Startup
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Startup'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Startup.Startup(IConfiguration)'
        public Startup(IConfiguration configuration)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Startup.Startup(IConfiguration)'
        {
            Configuration = configuration;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Startup.Configuration'
        public IConfiguration Configuration { get; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Startup.Configuration'

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Startup.ConfigureServices(IServiceCollection)'
        public void ConfigureServices(IServiceCollection services)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Startup.ConfigureServices(IServiceCollection)'
        {
            DependencyInjection(services);
            Configuration.GetSection("DefaultConnection");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //HTTP Client
            services.AddHttpClient();

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Ecommercer - Coffee with Milk",
                        Version = "v1",
                        Description = "Ecommercer usado para estudos",
                        Contact = new Contact
                        {
                            Name = "Coffee with Milk",
                            Url = "https://github.com/renatoavila/ecommerce"
                        }
                    });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }

       

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Startup.DependencyInjection(IServiceCollection)'
        public void DependencyInjection(IServiceCollection services)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Startup.DependencyInjection(IServiceCollection)'
        {

            services.AddSingleton<IAddressRepository, AddressRepository>();

            services.AddSingleton<IShopCartRepository, ShopCartRepository>();
            services.AddTransient<IShopCartBusiness, ShopCartBusiness>();
            services.AddTransient<IShopCartServices, ShopCartServices>();

            services.AddTransient<IItemCartRepository, ItemCartRepository>();

            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddTransient<IClientBusiness, ClientBusiness>();
            services.AddTransient<IClientServices, ClientServices>();

            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddTransient<IProductBusiness, ProductBusiness>();
            services.AddTransient<IProductServices, ProductServices>();

            services.AddSingleton<IStockRepository, StockRepository>();
            services.AddTransient<IStockBusiness, StockBusiness>();
            services.AddTransient<IStockServices, StockService>();

            services.AddSingleton<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IOrdersBusiness, OrdersBusiness>();
            services.AddTransient<IOrdersServices, OrdersService>();

            services.AddSingleton<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPaymentBusiness, PaymentBusiness>();
            services.AddTransient<IPaymentServices, PaymentService>();

            services.AddTransient<IBilletIntegration, BilletIntegration>();
            services.AddTransient<ICredCardIntegration, CredCardIntegration>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Startup.Configure(IApplicationBuilder, IHostingEnvironment)'
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Startup.Configure(IApplicationBuilder, IHostingEnvironment)'
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            app.UseMvc();

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Ecommercer");
            });
        }
    }
}
