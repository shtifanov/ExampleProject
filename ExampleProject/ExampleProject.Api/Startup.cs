﻿using ExampleProject.Api.Infrastructure.Extensions;
using ExampleProject.Core.Infrastructure.Mappings;
using ExampleProject.DataAccess;
using ExampleProject.DataAccess.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.Api
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
            services.AddDbContext<ExampleDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            Core.IoC.DependencyInjector.Inject(services);
            DataAccess.IoC.DependencyInjector.Inject(services);
            services.AddMvc(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDb db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                db.SeedExampleData();
            }
            else
            {
                app.UseExceptionHandler(appBuilder => appBuilder.AddExceptionHandler());
                app.UseHsts();
            }

            MappingsActivator.Configure();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
