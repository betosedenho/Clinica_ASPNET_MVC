using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinica.Site.Persistencia.Cadastro
{
    public class CidadeRepositorio
    {
        private ClinicaDbContext contexto;

        public Cidade ObterCidade(int id, int idEstado)
        {
            using (contexto = new ClinicaDbContext())
            {
                return contexto.Cidades.Where(m => m.Id == id && m.Estado_Id == idEstado).SingleOrDefault();
            }   
        }

        public List<Cidade> ObterCidades()
        {
            using (contexto = new ClinicaDbContext())
            {
                using (contexto = new ClinicaDbContext())
                {
                    return contexto.Cidades.ToList();
                }
            }
        }

        public List<Cidade> ObterCidadesPorEstado(int idEstado)
        {
            using (contexto = new ClinicaDbContext())
            {
                contexto.Configuration.LazyLoadingEnabled = false;
                return contexto.Cidades.Where(m => m. Estado_Id == idEstado).ToList();
            }
        }
    }
}
