using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverIT.Business.Models.Validations
{
	public class MemoriaCalculoValidation : AbstractValidator<MemoriaCalculo>
	{
		public MemoriaCalculoValidation()
		{
			RuleFor(c => c.JurosDiaPercentual)
				.GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

			RuleFor(c => c.QuantidadeDiasEmAtraso)
				.GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

			RuleFor(c => c.ValorCorrigido)
				.GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

			RuleFor(c => c.MultaPercentualAplicada)
	.GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
		}
	}
}
