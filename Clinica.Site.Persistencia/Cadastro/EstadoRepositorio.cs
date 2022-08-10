using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinica.Site.Persistencia.Cadastro
{     
    public class EstadoRepositorio
    {
        private ClinicaDbContext contexto;

        public List<Estado> ObterEstados()
        {
            using (contexto = new ClinicaDbContext())
            {
                using (contexto = new ClinicaDbContext())
                {
                    return contexto.Estados.ToList();
                }
            }
        }

        public Estado ObterEstado(int id)
        {
            using (contexto = new ClinicaDbContext())
            {
                using (contexto = new ClinicaDbContext())
                {
                    return contexto.Estados.SingleOrDefault();
                }
            }
        }

        public bool Salvar(Estado estado)
        {
            using (contexto = new ClinicaDbContext())
            {
                using (var transacao = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        contexto.Estados.Add(estado);
                        contexto.SaveChanges();
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro ao salvar o Estado {0}", e);
                        transacao.Rollback();
                        return false;
                    }
                    return true;
                }
            }
        }
    }
}
