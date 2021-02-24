using System;
using System.Security.Authentication;

namespace DeliverIT.Business.Models
{
	public class MemoriaCalculo : Entity
	{

		public MemoriaCalculo(Conta _conta)
		{
			Id = new Guid();
			Conta = _conta;
			AtualizaValoresCalculados();
		}

		//Construtor para EF
		public MemoriaCalculo()
		{

		}

		#region Propriedades

		public Guid ContaId { get; set; }
		public int QuantidadeDiasEmAtraso { get; protected set; }
		public decimal MultaPercentualAplicada { get; protected set; }
		public decimal JurosDiaPercentual { get; protected set; }

		public decimal ValorCorrigido { get; protected set; }
		/* EF */
		public Conta Conta { get; set; }

		#endregion

		#region MetodosPublicos
		public int CalculaDiasEmAtraso()
		{
			return QuantidadeDiasEmAtraso = Conta != null ? Conta.DataPagamento.Subtract(Conta.DataVencimento).Days : 0;
		}

		public decimal CalcularMultaPercentualAplicada()
		{
			if (QuantidadeDiasEmAtraso <= 3)
			{
				MultaPercentualAplicada = 2;
			}
			else if (QuantidadeDiasEmAtraso <= 5)
			{
				MultaPercentualAplicada = 3;
			}
			else
			{
				MultaPercentualAplicada = 5;
			}

			return MultaPercentualAplicada;
		}

		public decimal CalcularJurosDiaPercentual()
		{
			if (QuantidadeDiasEmAtraso <= 3)
			{
				JurosDiaPercentual = 0.1m;
			}
			else if (QuantidadeDiasEmAtraso <= 5)
			{
				JurosDiaPercentual = 0.2m;
			}
			else
			{
				JurosDiaPercentual = 0.3m;
			}

			return JurosDiaPercentual;
		}
		public decimal CalculaValorCorrigido()
		{
			return ValorCorrigido = Conta.ValorOriginal + CalcularValorMulta() + CalcularValorJuros();
		}
		#endregion

		#region MetodosPrivados
		private decimal CalcularValorMulta()
		{
			return Conta.ValorOriginal * (MultaPercentualAplicada / 100);
		}

		private decimal CalcularValorJuros()
		{

			decimal valorJuros = 0;


			for (int i = 0; i < QuantidadeDiasEmAtraso; i++)
			{
				valorJuros += Conta.ValorOriginal * (JurosDiaPercentual / 100);
			}

			return valorJuros;
		}
		private void AtualizaValoresCalculados()
		{
			CalculaDiasEmAtraso();
			CalcularMultaPercentualAplicada();
			CalcularJurosDiaPercentual();
			CalculaValorCorrigido();
		}

		#endregion

	}
}
