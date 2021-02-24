using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverIT.Business.Models.Validations
{
	public class ContaValidation : AbstractValidator<Conta>
	{
		public ContaValidation()
		{
			RuleFor(c => c.Nome)
				.NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornacido");

			RuleFor(c => c.ValorOriginal)
				.GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

			RuleFor(c => c.DataVencimento)
				.GreaterThan(DateTime.MinValue).WithMessage("O campo { PropertyName} precisa ser maior que { ComparisonValue}");
			RuleFor(c => c.DataPagamento)
				.GreaterThanOrEqualTo(c => c.DataVencimento).WithMessage("O campo { PropertyName} precisa ser maior que { ComparisonValue}");

		}
	}
}
