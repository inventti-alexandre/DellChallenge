﻿using DellChallange.Repository.Repositories;
using DellChallenge.Domain.Interfaces;
using DellChallenge.Domain.Services;
using DellChallenge.Domain.Interfaces;
using DellChallenge.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace DellChallenge.Web2
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
            services.AddAuthentication("Cookies")
            .AddCookie("Cookies", options =>
            {
                options.AccessDeniedPath = "/Home/StatusCode/400";
                options.LoginPath = "/Home/StatusCode/400";
            });

            services.AddSession();
            services.AddMvc();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<IClassificationRepository, ClassificationRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            services.AddTransient<ICityRepository, CityRepository>();

            services.AddTransient<AuthenticationService, AuthenticationService>();
            services.AddTransient<ClientService, ClientService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseSession();

            app.UseStatusCodePages(new StatusCodePagesOptions()
            {
                HandleAsync = (ctx) =>
                {
                    var code = ctx.HttpContext.Response.StatusCode;
                    
                    
                    ctx.HttpContext.Response.Redirect("/Home/StatusCode/"+ code);
                    return Task.FromResult(0);
                }
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
