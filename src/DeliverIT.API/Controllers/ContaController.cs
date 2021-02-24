using AutoMapper;
using DeliverIT.API.ViewModels;
using DeliverIT.Business.Interfaces;
using DeliverIT.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliverIT.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ContaController : MainController
	{
		private readonly IContaService _contaService;
		private readonly IMapper _mapper;

		public ContaController(IContaService contaService, IMapper mapper, INotificador notificador) : base(notificador)
		{
			_contaService = contaService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IEnumerable<ContaResponse>> ListarTodos()
		{
			return _mapper.Map<IEnumerable<ContaResponse>>(await _contaService.ListarContas());
		}

		public async Task<ActionResult<ContaResponse>> Adicionar(ContaRequest conta)
		{
			if (!ModelState.IsValid) return CustomResponse(ModelState);
			
			return CustomResponse(_mapper.Map<ContaResponse>(await _contaService.Adicionar(_mapper.Map<Conta>(conta))));
			
		}


	}
}
