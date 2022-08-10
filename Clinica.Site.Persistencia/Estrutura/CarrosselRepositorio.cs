using Clinica.Site.Negocio.Estrutura;
using Clinica.Site.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Clinica.Site.Persistencia.Estrutura
{
	public class CarrosselRepositorio
	{
		private ClinicaDbContext contexto;
		
		public IEnumerable<Carrossel> Obter()
		{
			using (contexto = new ClinicaDbContext())
			{
                return contexto.Carrossel.OrderBy(c => c.Id).ToList(); 
			}
		}
    }
}
