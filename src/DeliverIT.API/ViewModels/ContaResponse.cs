using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliverIT.API.ViewModels
{
	public class ContaResponse
	{
		public Guid Id { get; set; }		
		public string Nome { get; set; }
		public decimal ValorOriginal { get; set; }
		public DateTime DataVencimento { get; set; }
		public DateTime DataPagamento { get; set; }
		public int QuantidadeDiasEmAtraso { get; set; }
		public decimal ValorCorrigido { get;  set; }
	}
}
