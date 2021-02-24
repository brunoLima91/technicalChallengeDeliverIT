using DeliverIT.Business.Interfaces;
using DeliverIT.Business.Notificacoes;
using DeliverIT.Business.Services;
using DeliverIT.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DeliverIT.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static IServiceCollection ResolveDependecies(this IServiceCollection services)
		{
			services.AddScoped<IContaRepository, ContaRepository>();
			services.AddScoped<IMemoriaCalculoRepository, MemoriaCalculoRepository>();


			services.AddScoped<INotificador, Notificador>();
			services.AddScoped<IContaService, ContaService>();
			services.AddScoped<IMemoriaCalculoService, MemoriaCalculoService>();



			return services;
		}
	}
}
