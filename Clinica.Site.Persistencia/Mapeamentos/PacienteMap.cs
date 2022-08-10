using Clinica.Site.Negocio.Cadastro;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Clinica.Site.Persistencia.Mapeamentos
{
    public class PacienteMap : EntityTypeConfiguration<Paciente>
    {
        public PacienteMap()
        {
            ToTable("Paciente");

            HasKey(a => a.Id);

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(a => a.Cpf)
                .IsRequired()
                .HasMaxLength(40);

            Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(300);

            Property(a => a.DataNascimento)
                .IsRequired()
                .HasMaxLength(100);

            Property(a => a.TelefoneFixo)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.Celular)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.EhPaciente);
        }
    }
}