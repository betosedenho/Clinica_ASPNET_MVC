using System.Collections.Generic;

namespace Clinica.Site.Negocio.Cadastro
{
	public class Emails
	{
		public Emails()
		{
		}

		public Emails(int id, string nome, string endereco, bool ativo)
		{
			this.Id = id;
			this.Nome = nome;
			this.Endereco = endereco;
			this.Ativo = ativo;
	}

		public int Id { get; set; }
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public bool Ativo { get; set; }
	}

}
