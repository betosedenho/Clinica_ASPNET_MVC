using Clinica.Site.Negocio.Cadastro;
using System.Collections.Generic;

namespace Clinica.Site.MVC.Models
{
	public class EspecialidadesViewModels
	{
		public IEnumerable<Especialidade> Consultas { get; set; }
		public IEnumerable<Exame> Exames { get; set; }
	}
}