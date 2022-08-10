using Clinica.Site.Negocio.Cadastro;
using System.Collections.Generic;

namespace Clinica.Site.MVC.Models
{
    public class EspecialidadesMedicasViewModel
    {
        public IEnumerable<Especialidade> Medicas { get; set; }
        public IEnumerable<Especialidade> Apoio { get; set; }
    }
}