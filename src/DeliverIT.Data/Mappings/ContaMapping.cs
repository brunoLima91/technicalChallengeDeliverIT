using DeliverIT.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverIT.Data.Mappings
{
	public class ContaMapping : IEntityTypeConfiguration<Conta>
	{
		public void Configure(EntityTypeBuilder<Conta> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Nome)
				.IsRequired()
				.HasColumnType("varchar(200)");


			builder.Ignore(c => c.isPagamentoEmAtraso);

			builder.Property(c => c.DataPagamento)
				.IsRequired();

			builder.Property(c => c.DataVencimento)
				.IsRequired();

			builder.Property(c => c.ValorOriginal)
				.IsRequired();

			builder.HasOne(c => c.MemoriaCalculo)
				.WithOne(m => m.Conta)
				.OnDelete(DeleteBehavior.Cascade);

			builder.ToTable("Conta");
				
		}
	}
}
