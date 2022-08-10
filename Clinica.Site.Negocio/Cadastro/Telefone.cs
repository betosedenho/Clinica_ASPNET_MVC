using System.Collections.Generic;
using System;

namespace Clinica.Site.Negocio.Cadastro
{
    public class Telefone
	{
		public Telefone()
		{
		}
        public Telefone(int Id, string ddd, string numero, TipoTelefone tipoTelefone)
        {
			if (string.IsNullOrWhiteSpace(ddd))
				throw new ArgumentNullException("ddd");
			if (string.IsNullOrWhiteSpace(numero))
				throw new ArgumentNullException("numero");

			this.Id = Id;
			this.Ddd = ddd;
			this.Numero = numero;
            this.TipoTelefone = TipoTelefone;
		}
		public int Id { get; set; }
		public string Ddd { get; set; }
		public string Numero { get; set; }
		public TipoTelefone TipoTelefone { get; set; }
        public virtual Paciente Paciente { get; set; } 
    }
}
