using Clinica.Site.Negocio.Cadastro;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Clinica.Site.Persistencia.Mapeamentos
{
    public class EstadoMap:EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            ToTable("Estados");

            HasKey(a => a.Id);

            Property(a => a.Id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(300);

            Property(a => a.UF)
                .IsRequired()
                .HasMaxLength(3);
        }
    }
}
