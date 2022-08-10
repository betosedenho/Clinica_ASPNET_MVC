using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinica.Site.Persistencia.Cadastro
{
	public class EmailsRepositorio
	{
		private ClinicaDbContext contexto;

		public IEnumerable<Emails> Obter()
		{
			using (contexto = new ClinicaDbContext())
			{
				return contexto.Emails.Where(c => c.Ativo==true).OrderBy(c => c.Nome).ToList();
			}
		}

		public bool Salvar(Emails emails)
		{
			bool bRet = true;
			using (contexto = new ClinicaDbContext())
			{
				using (var transacao = contexto.Database.BeginTransaction())
				{
					try
					{
						if (emails.Id == 0)
						{
							contexto.Emails.Add(emails);
						}
						else
						{
							var item = contexto.Emails.SingleOrDefault(e => e.Id == emails.Id);
							if (item != null)
							{
								item.Nome = emails.Nome;
								item.Endereco = emails.Endereco;
								item.Ativo = emails.Ativo;
							}
						}
						contexto.SaveChanges();
						transacao.Commit();
					}
					catch (Exception)
					{
						transacao.Rollback();
						bRet = false;
					}
				}
			}
			return bRet;
		}

	}
}
