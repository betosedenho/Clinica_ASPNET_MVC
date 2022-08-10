using Clinica.Site.Negocio.Estrutura;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Site.Persistencia.Mapeamentos
{
	public class CarrosselMap : EntityTypeConfiguration<Carrossel>
	{
		public CarrosselMap()
		{
			ToTable("Carrossel");

			HasKey(a => a.Id);

			Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(a => a.Imagem)
                .IsRequired()
                .HasMaxLength(1024);

			Property(a => a.Item)
                .IsRequired()
                .HasMaxLength(56);
		}
	}
}
