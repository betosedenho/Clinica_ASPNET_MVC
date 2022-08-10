using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinica.Site.Persistencia.Cadastro
{
	public class HorariosRepositorio
	{
		private ClinicaDbContext contexto;

		public IEnumerable<Horarios> Obter()
		{
			using (contexto = new ClinicaDbContext())
			{
				return contexto.Horarios.Where(a => a.Ativo == true).OrderBy(a => a.Id).ToList();
			}
		}

		public IEnumerable<Horarios> ObterTodos()
		{
			using (contexto = new ClinicaDbContext())
			{
				return contexto.Horarios.ToList();
			}
		}

		public bool Salvar(Horarios horarios)
		{
			bool bRet = true;
			using (contexto = new ClinicaDbContext())
			{
				using (var transacao = contexto.Database.BeginTransaction())
				{
					try
					{					
						var item = contexto.Horarios.SingleOrDefault(h => h.Dia == horarios.Dia);
						if (item != null)
						{
							item.Abertura = horarios.Abertura;
							item.Fechamento = horarios.Fechamento;
							item.Ativo = horarios.Ativo;
						}
						
						contexto.SaveChanges();
						transacao.Commit();
					}
					catch (Exception)
					{
						bRet = false;
						transacao.Rollback();
					}
				}
			}
			return bRet;
		}

	}
}
		
