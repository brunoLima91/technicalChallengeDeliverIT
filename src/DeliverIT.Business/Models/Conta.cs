using System;

namespace DeliverIT.Business.Models
{
	public class Conta : Entity
	{
		public string Nome { get; set; }
		public decimal ValorOriginal { get; set; }
		public DateTime DataVencimento { get; set; }
		public DateTime DataPagamento { get; set; }
		
		public bool isPagamentoEmAtraso { get { return DataPagamento.Date > DataVencimento.Date; } }

		public MemoriaCalculo MemoriaCalculo { get; set; }

	}
}
