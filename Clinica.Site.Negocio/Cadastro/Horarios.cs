namespace Clinica.Site.Negocio.Cadastro
{
    public class Horarios
	{
		public Horarios()
		{
		}

		public Horarios(int id, string dia, string abertura, string fechamento, bool ativo)
		{
			this.Id = id;
			this.Dia = dia;
			this.Abertura = abertura;
			this.Fechamento = fechamento;
			this.Ativo = ativo;
		}

		public int Id { get; set; }
		public string Dia { get; set; }
		public string Abertura { get; set; }
		public string Fechamento { get; set; }
		public bool Ativo { get; set; }
	}

}
