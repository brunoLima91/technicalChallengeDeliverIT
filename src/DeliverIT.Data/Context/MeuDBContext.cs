using DeliverIT.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DeliverIT.Data.Context
{
	public class MeuDBContext : DbContext
	{
		public MeuDBContext(DbContextOptions<MeuDBContext> options) : base(options)
		{

		}

		public DbSet<Conta>	Contas { get; set; }
		public DbSet<MemoriaCalculo> MemoriaCalculos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var proprety in modelBuilder.Model.GetEntityTypes()
				.SelectMany(e => e.GetProperties()
				.Where(p => p.ClrType == typeof(string))))
				proprety.SetColumnType("varchar(100)");

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDBContext).Assembly);

			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

			base.OnModelCreating(modelBuilder);
		}
	}
}
