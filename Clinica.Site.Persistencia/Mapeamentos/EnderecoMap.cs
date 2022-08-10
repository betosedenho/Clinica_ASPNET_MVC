using Clinica.Site.Negocio.Cadastro;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Clinica.Site.Persistencia.Mapeamentos
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            HasKey(a => a.Id);

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Logradouro)
               .IsRequired()
               .HasMaxLength(300);

            Property(a => a.Numero)
               .IsRequired()
               .HasMaxLength(10);

            Property(a => a.Complemento)
               .IsRequired()
               .HasMaxLength(40);

            Property(a => a.Bairro)
               .IsRequired()
               .HasMaxLength(100);

            Property(a => a.NomeCidade)
               .IsRequired()
               .HasMaxLength(100);

            Property(a => a.Cep)
               .IsRequired()
               .HasMaxLength(10);

            HasRequired(a => a.Paciente)
                .WithMany()
                .HasForeignKey(a => a.Paciente_Id)
                .WillCascadeOnDelete(false);

            HasRequired(a => a.Cidade)
                .WithMany()
                .HasForeignKey(a => a.Cidade_Id)
                .WillCascadeOnDelete(false);
        }
    }
}