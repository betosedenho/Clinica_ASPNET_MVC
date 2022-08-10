using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinica.Site.Persistencia.Cadastro
{
	public class PreparoRepositorio
	{
		private ClinicaDbContext contexto;

		public IEnumerable<Preparo> ObterTodos()
		{
			using (contexto = new ClinicaDbContext())
			{
				return contexto.Preparo.OrderBy(c => c.Nome).ToList();
			}
		}
	}
}
