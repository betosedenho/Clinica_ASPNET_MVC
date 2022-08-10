namespace Clinica.Site.Negocio.Cadastro
{
    public class Preparo
	{
		public Preparo()
		{
		}

		public Preparo(int Id, string Nome, string Descricao, bool ativo)
		{
			this.Id = Id;
			this.Nome = Nome;
			this.Descricao = Descricao;
		}

		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
        public virtual Exame Exame { get; set; }
	}
}
