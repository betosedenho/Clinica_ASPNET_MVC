using Clinica.Site.Negocio.Cadastro;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Site.Persistencia.Mapeamentos
{
	public class HorariosMap : EntityTypeConfiguration<Horarios>
	{
		public HorariosMap()
		{
			ToTable("Horarios");

			HasKey(a => a.Id);

			Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

			Property(a => a.Dia)
                .IsRequired();

			Property(a => a.Abertura)
                .IsRequired();

			Property(a => a.Fechamento)
                .IsRequired();

			Property(a => a.Ativo)
                .IsRequired();
		}
	}
}
