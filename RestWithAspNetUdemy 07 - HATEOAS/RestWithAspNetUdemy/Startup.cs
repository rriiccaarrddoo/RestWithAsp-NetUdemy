using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using RestWithAspNetUdemy.HyperMedia;
using RestWithAspNetUdemy.Models.Context;
using RestWithAspNetUdemy.Repository;
using RestWithAspNetUdemy.Repository.Generic;
using RestWithAspNetUdemy.Repository.Implementations;
using RestWithAspNetUdemy.Services;
using RestWithAspNetUdemy.Services.Implementations;
using Tapioca.HATEOAS;

namespace RestWithAspNetUdemy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<MySQLContext>();

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
            .AddXmlSerializerFormatters();

            //Depency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();

            //Dependency Injection of GenericRepository
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddApiVersioning(option => option.ReportApiVersions = true);

            //Define as opções do filtro HATEOAS
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());

            //Injeta o serviço
            services.AddSingleton(filterOptions);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Necessário para o links HATEOAS
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller=Values}/{id?}");
            });

            SeedData.EnsurePopulated();


        }
    }
}
