using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emp_management.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("foo.html");


            //app.UseDefaultFiles(defaultFilesOptions);

            //app.UseFileServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            

            //app.Run(async (context) =>
            //{
            //    // throw new Exception("Some error occured");
            //    //await context.Response.WriteAsync("MW3: Outgoing request");
            //    //await context.Response
            //    //.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName + "\n") ;
            //    //await context.Response
            //    //.WriteAsync(_config["MyKey"].ToString() + "\n");
            //    //await context.Response
            //    //.WriteAsync(_config["YourKey"].ToString());
            //    //logger.LogInformation("MW3: Outgoing request");
            //    await context.Response.WriteAsync("Hosting Evn: " + env.EnvironmentName.ToUpper());

            //});

          

        }
    }
}
