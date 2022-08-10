using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Site.Negocio.Cadastro
{
    public class Cidade
    {
        public Cidade()
        {
            this.Id = 0;
            this.Nome = string.Empty;
            this.UF = string.Empty;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public int? Estado_Id { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
