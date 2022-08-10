using Clinica.Site.Negocio.Cadastro;
using System.Collections.Generic;

namespace Clinica.Site.MVC.Models
{
    public class AtendimentosIntantisViewModel
    {
        public IEnumerable<Especialidade> Especialidades { get; set; }
        public IEnumerable<Exame> Exames { get; set; }
    }
}