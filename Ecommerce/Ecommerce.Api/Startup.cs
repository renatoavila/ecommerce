using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Api.Model;
using Ecommerce.Business;
using Ecommerce.Business.Interface;
using Ecommerce.Domain.Entity;
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
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            DependencyInjection(services);
            Configuration.GetSection("DefaultConnection");

            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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

       

        public void DependencyInjection(IServiceCollection services)
        {

            services.AddSingleton<IAddressRepository, AddressRepository>();

            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddTransient<IClientBusiness, ClientBusiness>();
            services.AddTransient<IClientServices, ClientServices>();

            services.AddSingleton<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IProdutoBusiness, ProdutoBusiness>();
            services.AddTransient<IProdutoServices, ProdutoServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
