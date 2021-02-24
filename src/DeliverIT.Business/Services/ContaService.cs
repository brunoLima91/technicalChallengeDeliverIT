using DeliverIT.Business.Interfaces;
using DeliverIT.Business.Models;
using DeliverIT.Business.Models.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliverIT.Business.Services
{
	public class ContaService : BaseService, IContaService
	{
		private readonly IContaRepository _contaRepository;
		private readonly IMemoriaCalculoService _memoriaCalculoService;
		public ContaService(IContaRepository contaRepository, IMemoriaCalculoService memoriaCalculoService, INotificador notificador) : base(notificador)
		{
			_contaRepository = contaRepository;
			_memoriaCalculoService = memoriaCalculoService;
		}

		public async Task<Conta> Adicionar(Conta conta)
		{
			if (!ExecutarValidacao(new ContaValidation(), conta))
				return null;

			if (conta.isPagamentoEmAtraso)
			{
				await AdicionaContaEmAtraso(conta);
			}
			else
			{
				await _contaRepository.Adicionar(conta);
			}

			return conta;

		}

		public void Dispose()
		{
			_contaRepository?.Dispose();
		}

		public async Task<IEnumerable<Conta>> ListarContas()
		{
			return await _contaRepository.ObterContaMemoriaCalculo();
		}

		private async Task AdicionaContaEmAtraso(Conta conta)
		{
			conta.MemoriaCalculo = _memoriaCalculoService.GerarMemoriaCalculo(conta);
			await _contaRepository.Adicionar(conta);
		}
	}
}
