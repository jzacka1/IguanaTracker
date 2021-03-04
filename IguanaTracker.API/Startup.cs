using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using IguanaTracker.API.Interfaces;
using IguanaTracker.API.Services;
using IguanaTracker.BL.Services;
using IguanaTracker.BL.Services.Interfaces;
using IguanaTracker.Data.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace IguanaTracker.API
{
	/// <summary>
	/// 
	/// </summary>
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// 
		/// </summary>
		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		/// <summary>
		/// 
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddDbContext<FloridaIguanaTrackerDBContext>(options => 
				options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection")));

			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v3", new OpenApiInfo
				{
					Title = "Florida Iguana Tracker",
					Version = "v3",
					Description = "This is an API for Iguana Tracker"
				});

				var file = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xpath = Path.Combine(AppContext.BaseDirectory, file);
				c.IncludeXmlComments(xpath);
			});

			//services.AddTransient<Iguana>();

			services.AddTransient<IIguanaTrackerService, IguanaTrackerService>();
			services.AddSingleton<ILoggerService, LoggerService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v3/swagger.json", "Iguana Tracker API");
				c.RoutePrefix = "";
			});

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
