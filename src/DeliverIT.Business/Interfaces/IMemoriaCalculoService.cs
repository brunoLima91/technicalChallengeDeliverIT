using DeliverIT.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Business.Interfaces
{
	public interface IMemoriaCalculoService
	{
		MemoriaCalculo GerarMemoriaCalculo(Conta conta);

		Task Adicionar(MemoriaCalculo memoriaCalculo);

	}
}
