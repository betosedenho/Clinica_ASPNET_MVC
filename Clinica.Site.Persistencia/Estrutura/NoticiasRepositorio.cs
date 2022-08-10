using Clinica.Site.Negocio.Estrutura;
using Clinica.Site.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Clinica.Site.Persistencia.Estrutura
{
	public class NoticiasRepositorio
	{
		private ClinicaDbContext contexto;

		public IEnumerable<Noticias> Obter()
		{
			using (contexto = new ClinicaDbContext())
			{
                return contexto.Noticias.Where(n => n.Item == "item active").ToList();
			}
		}

        public IEnumerable<Noticias> ObterTodas()
        {
            using (contexto = new ClinicaDbContext())
            {
                return contexto.Noticias.ToList();
            }
        }

        public bool SalvarNoticia(Noticias noticia)
		{
			bool bRet = true;
			using (contexto = new ClinicaDbContext())
			{
				using (var transacao = contexto.Database.BeginTransaction())
				{
					try
					{
						if (noticia.Id == 0)
						{
							contexto.Noticias.Add(noticia);
							contexto.SaveChanges();
						}
						else
						{
							var item = contexto.Noticias.SingleOrDefault(c => c.Id == noticia.Id);
							if (item != null)
							{
								item.Texto = noticia.Texto;
								item.Item = noticia.Item;
								item.Link = noticia.Link;
								contexto.SaveChanges();
							}
						}
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
