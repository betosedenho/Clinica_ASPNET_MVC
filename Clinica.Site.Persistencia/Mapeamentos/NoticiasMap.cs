using Clinica.Site.Negocio.Estrutura;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Site.Persistencia.Mapeamentos
{
	public class NoticiasMap : EntityTypeConfiguration<Noticias>
	{
		public NoticiasMap()
		{
			ToTable("Noticias");

			HasKey(a => a.Id);

			Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(a => a.Texto)
                .IsRequired().HasMaxLength(1024);

			Property(a => a.Item)
                .IsRequired().HasMaxLength(56);

			Property(a => a.Link)
                .IsOptional();
		}
	}
}
