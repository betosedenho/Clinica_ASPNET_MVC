using Clinica.Site.Negocio.Cadastro;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Clinica.Site.Persistencia.Mapeamentos
{
    public class EspecialidadeMap: EntityTypeConfiguration<Especialidade>
    {
        public EspecialidadeMap()
        {
            ToTable("Especialidades");

            HasKey(a => a.Id);

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(a => a.Descricao)
                .HasMaxLength(2000);            

            Property(a => a.Ativo)
                .IsRequired();

            Property(a => a.TipoEspecialidade)
                .IsOptional();

			Property(a => a.ItemEspecialidade)
                .IsOptional();

            Property(a => a.TipoPublico)
                .IsOptional();
        }
    }
}
