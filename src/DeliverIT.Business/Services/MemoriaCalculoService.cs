using DeliverIT.Business.Interfaces;
using DeliverIT.Business.Models;
using DeliverIT.Business.Models.Validations;
using System.Threading.Tasks;

namespace DeliverIT.Business.Services
{
	public class MemoriaCalculoService : BaseService, IMemoriaCalculoService
	{

		private readonly IMemoriaCalculoRepository _memoriaCalculoRepository;

		public MemoriaCalculoService(IMemoriaCalculoRepository memoriaCalculoRepository, INotificador notificador) : base(notificador)
		{
			_memoriaCalculoRepository = memoriaCalculoRepository;
		}
		public async Task Adicionar(MemoriaCalculo memoriaCalculo)
		{
			if (!ExecutarValidacao(new MemoriaCalculoValidation(), memoriaCalculo))
				return;

			await _memoriaCalculoRepository.Adicionar(memoriaCalculo);
		}

		public MemoriaCalculo GerarMemoriaCalculo(Conta conta)
		{
			return new MemoriaCalculo(conta);
		}

	}
}
