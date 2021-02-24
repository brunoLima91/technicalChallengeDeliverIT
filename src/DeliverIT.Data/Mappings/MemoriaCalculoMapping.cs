using DeliverIT.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverIT.Data.Mappings
{
	public class MemoriaCalculoMapping : IEntityTypeConfiguration<MemoriaCalculo>
	{
		public void Configure(EntityTypeBuilder<MemoriaCalculo> builder)
		{
			builder.HasKey(m => m.Id);

			builder.Property(m => m.QuantidadeDiasEmAtraso)
				.IsRequired();

			builder.Property(m => m.MultaPercentualAplicada)
				.IsRequired();

			builder.Property(m => m.JurosDiaPercentual)
				.IsRequired();

			builder.Property(m => m.ValorCorrigido)
				.IsRequired();

			builder.Ignore(m => m.Conta);

			builder.ToTable("MemoriaCalculo");

		}
	}
}
