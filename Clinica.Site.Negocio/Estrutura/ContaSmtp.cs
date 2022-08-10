namespace Clinica.Site.Negocio.Estrutura
{
    public class ContaSmtp
	{
		public ContaSmtp()
		{
		}

		public ContaSmtp(int id, string nome, string endereco, string servidor, string senha, bool seguranca, int porta, bool ativo, string emailFrom): this()
		{
			this.Id			= id;
			this.Nome		= nome;
			this.Endereco	= endereco;
            this.Servidor   = servidor;
			this.Senha		= senha;
			this.Seguranca	= seguranca;
			this.Porta		= porta;
			this.Ativo		= ativo;
            this.EmailFrom  = emailFrom;
		}

		public int Id { get; set; }
		public string Nome { get; set; }
		public string Endereco { get; set; }
		public string Servidor { get; set; }
		public string Senha { get; set; }
		public bool Seguranca { get; set; }
		public int Porta { get; set; }
        public string EmailFrom { get; set; }
        public bool Ativo { get; set; }
	}
}
