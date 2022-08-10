using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinica.Site.Persistencia.Cadastro
{
    public class EspecialidadeRepositorio
    {
        private ClinicaDbContext contexto;

        public Especialidade ObterEspecialidade(int? codigo)
        {
            using (contexto = new ClinicaDbContext())
            {
                return contexto.Especialidades.Find(codigo);
            }
        }
        
        public IEnumerable<Especialidade> ObterEspecialidade(ItemEspecialidade itemEspecialidade)
		{
			using (contexto = new ClinicaDbContext())
			{
				return contexto.Especialidades.Where(e => e.Ativo.Equals(true) && e.ItemEspecialidade == itemEspecialidade).OrderBy(e => e.Nome)
					.ToList();
			}
		}
    }
}
