using DeliverIT.Business.Interfaces;
using DeliverIT.Business.Models;
using DeliverIT.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Data.Repository
{
	public class ContaRepository : Repository<Conta>, IContaRepository
	{
		public ContaRepository(MeuDBContext context) : base(context)
		{

		}

		public async Task<Conta> ObterContaMemoriaCalculo(Guid id)
		{
			return await Db.Contas.AsNoTracking().Include(m => m.MemoriaCalculo)
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<IEnumerable<Conta>> ObterContaMemoriaCalculo()
		{
			return await Db.Contas.AsNoTracking().Include(m => m.MemoriaCalculo)
				.OrderBy(p => p.Nome).ToListAsync();
		}
	}
}
