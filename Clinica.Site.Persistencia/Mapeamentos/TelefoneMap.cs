using Clinica.Site.Negocio.Cadastro;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Clinica.Site.Persistencia.Mapeamentos
{
    public class TelefoneMap: EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            ToTable("Telefone");

            HasKey(a => a.Id);

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Ddd)
                .IsRequired()
                .HasMaxLength(3)
                .IsFixedLength();

            Property(a => a.Numero)
                .IsRequired()
                .HasMaxLength(10);

            Property(a => a.TipoTelefone)
                .IsRequired();

		}
    }
}
