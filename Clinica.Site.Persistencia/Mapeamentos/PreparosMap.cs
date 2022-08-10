using Clinica.Site.Negocio.Cadastro;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Site.Persistencia.Mapeamentos
{
	public class PreparoMap : EntityTypeConfiguration<Preparo>
	{
		public PreparoMap()
		{
			ToTable("Preparos");

			HasKey(p => p.Id);

			Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(a => a.Nome).IsRequired();

			Property(a => a.Descricao).IsRequired();
		}
	}
}
