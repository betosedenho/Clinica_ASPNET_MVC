using Clinica.Site.Negocio.Cadastro;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Site.Persistencia.Mapeamentos
{
	public class EmailsMap : EntityTypeConfiguration<Emails>
	{
		public EmailsMap()
		{
			ToTable("Emails");

			HasKey(a => a.Id);

			Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(a => a.Nome)
                .IsRequired();

			Property(a => a.Endereco)
                .IsRequired();

			Property(a => a.Ativo)
                .IsRequired();
		}
	}
}
