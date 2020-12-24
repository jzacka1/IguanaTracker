using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IguanaTracker.BL.Services;
using IguanaTracker.BL.Services.Interfaces;
using IguanaTracker.Data.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IguanaTracker.Web.MVC
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			services.AddResponseCaching();

			if(isDevelopment)
				services.AddDbContext<FloridaIguanaTrackerDBContext>(options =>
					options.UseSqlServer(
						Configuration.GetConnectionString("DefaultLocalConnection")));
			else
				services.AddDbContext<FloridaIguanaTrackerDBContext>(options =>
					options.UseSqlServer(
						Configuration.GetConnectionString("DefaultConnection")));

			services.AddTransient<IIguanaTrackerService, IguanaTrackerService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseResponseCaching();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					defaults: new { controller = "Home"},
					pattern: "{action=Index}/{id?}");
			});
		}
	}
}
