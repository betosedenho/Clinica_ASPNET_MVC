using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Clinica.Site.Persistencia.Cadastro
{
    public class ExameRepositorio
    {
        private ClinicaDbContext contexto;
      
        public IEnumerable<Exame> ObterExame(TipoPublico tipoPublico)
        {
            using (contexto = new ClinicaDbContext())
            {
                return contexto.Exames.Where(e => e.TipoPublico == TipoPublico.Ambos || e.TipoPublico == tipoPublico)
                    .OrderBy(e => e.Nome)
                    .ToList();
            }
        }

        public IEnumerable<Exame> ObterTodosExame()
		{
			using (contexto = new ClinicaDbContext())
			{
				return contexto.Exames.OrderBy(e => e.Nome).ToList();
			}
		}

    }
}
