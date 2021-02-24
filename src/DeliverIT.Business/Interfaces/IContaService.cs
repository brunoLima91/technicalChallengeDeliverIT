using DeliverIT.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Business.Interfaces
{
	public interface IContaService : IDisposable
	{
		Task<Conta> Adicionar(Conta conta);
		Task<IEnumerable<Conta>> ListarContas();
	}
}
