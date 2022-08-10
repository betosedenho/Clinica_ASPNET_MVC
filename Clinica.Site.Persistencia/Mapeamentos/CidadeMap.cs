using Clinica.Site.Negocio.Cadastro;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Clinica.Site.Persistencia.Mapeamentos
{
    public class CidadeMap:EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            ToTable("Cidades");

            HasKey(a => a.Id);

            Property(a => a.Id)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(300);

            Property(a => a.UF)
                .IsRequired()
                .HasMaxLength(3);

            HasRequired(a => a.Estado)
                .WithMany()
                .HasForeignKey(a => a.Estado_Id)
                .WillCascadeOnDelete(false);
        }
    }
}