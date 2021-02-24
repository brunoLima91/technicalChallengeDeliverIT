using DeliverIT.Business.Interfaces;
using DeliverIT.Business.Models;
using DeliverIT.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliverIT.Data.Repository
{
	public class MemoriaCalculoRepository : Repository<MemoriaCalculo>, IMemoriaCalculoRepository
	{
		public MemoriaCalculoRepository(MeuDBContext context): base(context)
		{

		}
	}
}
