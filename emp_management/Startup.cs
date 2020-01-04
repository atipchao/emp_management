using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emp_management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace emp_management
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public int MyTestFunc()
        {
            return 0;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(opt => opt.UseSqlServer(_config.GetConnectionString("EmpDBConnection")));

            //Customize password requirement..
            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;

            });
            services.AddMvc( options => {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();
            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            // always use "AddScoped" when connecting to Database server - it pulls new data all the time.
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            services.AddScoped<ICustomerRepository, SQLCustomerRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env/*, ILogger<Startup> logger*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Errors");
                //app.UseStatusCodePagesWithRedirects("/Errors/{0}"); // this placeholder automatically get the non-success status code OR ..
                app.UseStatusCodePagesWithReExecute("/Errors/{0}"); // This one returns the correct behaviour as 404 - w/o redirecting page
            }



            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();

            //app.UseFileServer();

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

        }
    }
}
