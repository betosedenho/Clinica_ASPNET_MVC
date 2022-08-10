using System;
using System.ComponentModel.DataAnnotations;

namespace Clinica.Site.Negocio.Estrutura
{
    public class Carrossel
	{
		public Carrossel()
		{
		}

		public Carrossel(int id, string imagem, string texto, string item):this()
		{
			this.Id = id;
			this.Imagem = imagem;
			this.Texto	= texto;
			this.Item	= item;
		}

		public int Id { get; set; }
		public string Imagem { get; set; }

        [MaxLength(500)]
        public string Texto { get; set; }
		public string Item { get; set; }

        public string State { get; set; }

        public bool Validar()
		{
			if (string.IsNullOrEmpty(Imagem))
				throw new ArgumentNullException("Campo Imagem está vazio");
			return true;
		}
	}
}
