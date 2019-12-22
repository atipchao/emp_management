using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emp_management.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace emp_management
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration aa)
        {
            _config = aa;
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
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env/*, ILogger<Startup> logger*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();

            //app.UseFileServer();

            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes => {
            //    routes.MapRoute("default", "company/{controller=Home}/{action=Index}/{id?}" );
            //});


            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=index}/{id=1}");
            });

            //app.UseMvc();



        }
    }
}
