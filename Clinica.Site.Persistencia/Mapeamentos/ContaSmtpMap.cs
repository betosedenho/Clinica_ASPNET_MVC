using Clinica.Site.Negocio.Estrutura;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Site.Persistencia.Mapeamentos
{
	public class ContaSmtpMap : EntityTypeConfiguration<ContaSmtp>
	{
		public ContaSmtpMap()
		{
			ToTable("ContaSmtp");

			HasKey(a => a.Id);

			Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(a => a.Nome)
                .IsRequired();

			Property(a => a.Endereco)
                .IsRequired();

			Property(a => a.Servidor)
                .IsRequired();

			Property(a => a.Senha)
                .IsRequired();

			Property(a => a.Seguranca)
                .IsRequired();

			Property(a => a.Porta)
                .IsRequired();

			Property(a => a.Ativo)
                .IsRequired();

            Property(a => a.EmailFrom)
                .IsOptional();
		}
	}
}

