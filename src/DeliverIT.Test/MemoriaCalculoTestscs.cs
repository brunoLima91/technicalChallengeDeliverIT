using DeliverIT.Business.Models;
using Moq;
using System;
using Xunit;

namespace DeliverIT.Test
{
	public class MemoriaCalculoTestscs
	{
		[Fact]
		public void CalculaDiasEmAtraso_RetornaQuantidadeDiasEmAtraso()
		{
			//Arrange
			
			var Conta = new Conta() { DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now.AddDays(2) } ;
			var mock = new Mock<MemoriaCalculo>(Conta);

			//Act
			var result =  mock.Object.CalculaDiasEmAtraso();
			//Assert
			Assert.Equal(4, result);
		}

		[Fact]
		public void CalcularMultaPercentualAplicada_QuandoQuantidadDiasAtrasoAte3Dias()
		{
			//Arrange

			var Conta = new Conta() { DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now.AddDays(1) };
			var mock = new Mock<MemoriaCalculo>(Conta);

			//Act
			var result = mock.Object.CalcularMultaPercentualAplicada();
			//Assert
			Assert.Equal(2, result);
		}

		[Fact]
		public void CalcularMultaPercentualAplicada_QuandoQuantidadDiasAtrasoAteEntre4e5Dias()
		{
			//Arrange

			var Conta = new Conta() { DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now.AddDays(3) };
			var mock = new Mock<MemoriaCalculo>(Conta);

			//Act
			var result = mock.Object.CalcularMultaPercentualAplicada();
			//Assert
			Assert.Equal(3, result);
		}

		[Fact]
		public void CalcularMultaPercentualAplicada_QuandoQuantidadDiasAtrasoAteSuperior5Dias()
		{
			//Arrange

			var Conta = new Conta() { DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now.AddDays(5) };
			var mock = new Mock<MemoriaCalculo>(Conta);

			//Act
			var result = mock.Object.CalcularMultaPercentualAplicada();
			//Assert
			Assert.Equal(5, result);
		}


		[Fact]
		public void CalcularJurosDiaPercentual_QuandoQuantidadDiasAtrasoAte3Dias()
		{
			//Arrange

			var Conta = new Conta() { DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now.AddDays(1) };
			var mock = new Mock<MemoriaCalculo>(Conta);

			//Act
			var result = mock.Object.CalcularJurosDiaPercentual();
			//Assert
			Assert.Equal(0.1m, result);
		}


		[Fact]
		public void CalcularJurosDiaPercentual_QuandoQuantidadDiasAtrasoAteEntre4e5Dias()
		{
			//Arrange

			var Conta = new Conta() { DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now.AddDays(3) };
			var mock = new Mock<MemoriaCalculo>(Conta);

			//Act
			var result = mock.Object.CalcularJurosDiaPercentual();
			//Assert
			Assert.Equal(0.2m, result);
		}

		[Fact]
		public void CalcularJurosDiaPercentual_QuandoQuantidadDiasAtrasoAteSuperior5Dias()
		{
			//Arrange

			var Conta = new Conta() { DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now.AddDays(5) };
			var mock = new Mock<MemoriaCalculo>(Conta);

			//Act
			var result = mock.Object.CalcularJurosDiaPercentual();
			//Assert
			Assert.Equal(0.3m, result);
		}

		[Fact]
		public void CalculaValorCorrigido_QuandoQuantidadDiasAtrasoAteSuperior5DiasValorOriginal100()
		{
			//Arrange

			var Conta = new Conta() { DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now.AddDays(5),ValorOriginal= 100 };
			var mock = new Mock<MemoriaCalculo>(Conta);

			//Act
			var result = mock.Object.CalculaValorCorrigido();
			//Assert
			Assert.Equal(107.100M, result);
		}

		[Fact]
		public void CalculaValorCorrigido_QuandoQuantidadDiasAtrasoAteEntre4e5DiasValorOriginal100()
		{
			//Arrange

			var Conta = new Conta() { DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now.AddDays(2), ValorOriginal = 100 };
			var mock = new Mock<MemoriaCalculo>(Conta);

			//Act
			var result = mock.Object.CalculaValorCorrigido();
			//Assert
			Assert.Equal(103.800M, result);
		}


		[Fact]
		public void CalculaValorCorrigido_QuandoQuantidadDiasAtrasoAte3Dias_ValorOriginal100()
		{
			//Arrange

			var Conta = new Conta() { DataVencimento = DateTime.Now.AddDays(-2), DataPagamento = DateTime.Now.AddDays(1), ValorOriginal = 100 };
			var mock = new Mock<MemoriaCalculo>(Conta);

			//Act
			var result = mock.Object.CalculaValorCorrigido();
			//Assert
			Assert.Equal(102.300M, result);
		}


	}
}
