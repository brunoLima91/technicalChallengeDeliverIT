﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliverIT.API.Configuration
{
	public static class ApiConfig
	{
		public static IServiceCollection WebApiConfig(this IServiceCollection services)
		{
			services.AddControllers();
					

			services.Configure<ApiBehaviorOptions>(options => {
				options.SuppressModelStateInvalidFilter = true;
			});

			services.AddCors(options =>
			{
				options.AddPolicy("Development",
					builder => builder
					.AllowAnyOrigin()
					//.WithOrigins("https://localhost")
					//.SetIsOriginAllowedToAllowWildcardSubdomains()
					.AllowAnyMethod()
					.AllowAnyHeader()
					//.AllowCredentials()
					);
			});

			return services;
		}

		public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
		{

			app.UseHttpsRedirection();

			app.UseCors();
			//app.UseAuthentication();
			app.UseRouting();
			//app.UseAuthorization();



			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			return app;
		}
	}
}
