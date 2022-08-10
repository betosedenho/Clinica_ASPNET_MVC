using Clinica.Site.Negocio.Cadastro;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Site.Persistencia.Mapeamentos
{
    public class AgendamentoMap : EntityTypeConfiguration<Agendamento>
    {
        public AgendamentoMap()
        {
            ToTable("Agendamento");

            HasKey(a => a.Id);

            Property(a => a.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Nome)
                .IsRequired();

            Property(a => a.Cpf);

            Property(a => a.DataNascimento)
                .IsRequired();

            Property(a => a.Email)
                .IsOptional();

            Property(a => a.Telefone)
                .IsOptional();

            Property(a => a.Celular)
                .IsOptional();

            Property(a => a.EhCliente)
                .IsRequired();

            Property(a => a.DataPreferencial1)
                .IsOptional();

            Property(a => a.DataPreferencial2)
                .IsOptional();

            Property(a => a.DataPreferencial3)
                .IsOptional();

            Property(a => a.PeriodoPreferencial)
                .IsOptional();

            Property(a => a.ComoConheceu)
                .IsOptional();

            Property(a => a.Checkup)
                .IsRequired();

            Property(a => a.Ativo)
                .IsRequired();

            Property(a => a.Observacao)
                .IsOptional();

            Property(a => a.Data)
                .IsOptional();

            Property(a => a.Horario)
                .IsOptional();

            Property(a => a.DataInclusao)
                .IsOptional();
        }
    }
}
