using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliverIT.API.ViewModels
{
	public class ContaRequest
	{
		[Key]
		public Guid Id { get; set; }
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public string Nome { get; set; }
		public decimal ValorOriginal { get; set; }
		public DateTime DataVencimento { get; set; }
		public DateTime DataPagamento { get; set; }
	}
}
