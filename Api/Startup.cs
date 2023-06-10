using Api.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProjekatASP.Application;
using ProjekatASP.Application.Commands;
using ProjekatASP.Application.DataTransfer;
using ProjekatASP.DataAccess.Configuration;
using ProjekatASP.Implementation;
using ProjekatASP.Implementation.Validators;
using ProjekatASP.Implementation.Validators.ArticleValidators;
using ProjekatASP.Implementation.Validators.BlogValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
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
			services.AddUsesCases();
			services.AddApplicationActor();
			services.AddControllers();
			services.AddJwt();


			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjekatASPApi", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme
						  {
							Reference = new OpenApiReference
							  {
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							  },
							  Scheme = "oauth2",
							  Name = "Bearer",
							  In = ParameterLocation.Header,

							},
							new List<string>()
						  }
					});
			});
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
			});


			app.UseRouting();
			app.UseStaticFiles();
			app.UseMiddleware<GlobalExceptionHandler>();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

