using DeliverIT.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverIT.Business.Interfaces
{
	public interface INotificador
	{
		bool TemNotificacao();
		List<Notificacao> ObterNotificacoes();
		void Handle(Notificacao notificacao);
	}
}
