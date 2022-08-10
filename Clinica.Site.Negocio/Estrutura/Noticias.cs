using System;

namespace Clinica.Site.Negocio.Estrutura
{
    public class Noticias
	{
		public Noticias()
		{
		}
		public Noticias(int id, string texto, string item, string Link):this()
		{
			this.Id		= id;
			this.Texto	= texto;
			this.Item =	 item;
			this.Link = Link;

		}
		public int Id { get; set; }
		public string Texto { get; set; }
		public string Item { get; set; }
		public string Link { get; set; }

		public bool Validar()
		{
			if (string.IsNullOrEmpty(Texto))
				throw new ArgumentNullException("Campo texto está vazio");
			return true;
		}

	}
}