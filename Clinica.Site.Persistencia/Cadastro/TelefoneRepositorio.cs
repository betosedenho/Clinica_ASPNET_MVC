using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Clinica.Site.Persistencia.Cadastro
{
    public class TelefoneRepositorio
    {
        private ClinicaDbContext contexto;
        public bool Salvar(Telefone telefone)
        {
			bool bRet = true;
            using (contexto = new ClinicaDbContext())
            {
                using (var transacao = contexto.Database.BeginTransaction())
                {
                    try
                    {
						if (telefone.Id == 0)
							contexto.Telefone.Add(telefone);
						else
						{
							var item = contexto.Telefone.SingleOrDefault(t => t.Id == telefone.Id);
							if (item != null)
							{
								item.Ddd = telefone.Ddd;
								item.Numero =  telefone.Numero;
								item.TipoTelefone = telefone.TipoTelefone;
							}
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

		public Telefone ObterTelefone(Telefone telefone)
        {
            using (contexto = new ClinicaDbContext())
            {
                return contexto.Telefone.Find(telefone);
            }
        }

		public IEnumerable<Telefone> ObterTelefone()
		{
			using (contexto = new ClinicaDbContext())
			{
                return contexto.Telefone.ToList();
			}
		}     
	}
}
