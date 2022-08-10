using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Site.Negocio.Cadastro
{
    public class Estado
    {
        public Estado()
        {
            this.Id = 0;
            this.Nome = string.Empty;
            this.UF = string.Empty;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
    }
}
