using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using LoginAndRegistration2.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAndRegistration2
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            this.Configuration = configuration;
               
        }
        		public IConfiguration Configuration {get;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSession();
            services.AddDbContext<DataContext>(options=>options.UseMySql(Configuration["DBInfo:ConnectionString"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			if(env.IsDevelopment())
			{
            	app.UseDeveloperExceptionPage();
			}
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
        }
    }
}
