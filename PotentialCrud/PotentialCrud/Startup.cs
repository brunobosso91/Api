using PotentialCrud.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PotentialCrud.Model.Developers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotentialCrud.Business;
using PotentialCrud.Business.Developers;
using PotentialCrud.Repository.Developers;
using PotentialCrud.Repository;

namespace PotentialCrud
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
            //services.AddDbContext<ContextoAplicacao>(options =>
            //options.UseInMemoryDatabase("produtosDB")
            //);

            services.AddDbContext<ContextoAplicacao>(opcoes => opcoes.UseSqlServer(Configuration.GetConnectionString("Conexao")));

            services.AddControllers();

            services.AddScoped<IDeveloperBusiness, DeveloperBusiness>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
