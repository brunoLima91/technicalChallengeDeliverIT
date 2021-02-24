using DeliverIT.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Business.Interfaces
{
	public interface IContaRepository: IRepository<Conta>
	{
		Task<Conta> ObterContaMemoriaCalculo(Guid id);
		Task<IEnumerable<Conta>> ObterContaMemoriaCalculo();
	}
}
