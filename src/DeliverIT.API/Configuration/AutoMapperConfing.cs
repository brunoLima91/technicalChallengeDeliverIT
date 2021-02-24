using AutoMapper;
using DeliverIT.API.ViewModels;
using DeliverIT.Business.Models;

namespace DeliverIT.API.Configuration
{
	public class AutoMapperConfing : Profile
	{
		public AutoMapperConfing()
		{
			CreateMap<Conta, ContaRequest>().ReverseMap();
			CreateMap<Conta, ContaResponse>()
				.ForMember(dest => dest.ValorCorrigido, m => m.MapFrom(src => src.MemoriaCalculo.ValorCorrigido))
				.ForMember(dest => dest.QuantidadeDiasEmAtraso, m => m.MapFrom(src => src.MemoriaCalculo.QuantidadeDiasEmAtraso));
		}

	}
}
