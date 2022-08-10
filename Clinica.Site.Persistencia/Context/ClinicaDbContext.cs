using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Negocio.Estrutura;
using Clinica.Site.Persistencia.Mapeamentos;
using Clinica.Site.Persistencia.Migrations;
using System.Data.Entity;

namespace Clinica.Site.Persistencia.Context
{
    public class ClinicaDbContext: DbContext
    {
        public ClinicaDbContext(): base("Name=DefaultConnection")
        {
            //Database.SetInitializer<ClinicaDbContext>(null); rsj
            Database.SetInitializer<ClinicaDbContext>(new CreateDatabaseIfNotExists<ClinicaDbContext>());
            Database.SetInitializer<ClinicaDbContext>(new MigrateDatabaseToLatestVersion<ClinicaDbContext, Configuration>());

            //Database.Initialize(true);
        }
      
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
		public DbSet<Carrossel> Carrossel { get; set; }
		public DbSet<Noticias> Noticias { get; set; }
		public DbSet<Emails> Emails { get; set; }
		public DbSet<ContaSmtp> ContaSmtp { get; set; }
		public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
		public DbSet<Preparo> Preparo { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.HasDefaultSchema("clinica");              
            modelBuilder.Configurations.Add(new TelefoneMap());
            modelBuilder.Configurations.Add(new ExameMap());
            modelBuilder.Configurations.Add(new EspecialidadeMap());
			modelBuilder.Configurations.Add(new CarrosselMap());
			modelBuilder.Configurations.Add(new NoticiasMap());
			modelBuilder.Configurations.Add(new EmailsMap());
			modelBuilder.Configurations.Add(new ContaSmtpMap());
			modelBuilder.Configurations.Add(new HorariosMap());
            modelBuilder.Configurations.Add(new AgendamentoMap());
			modelBuilder.Configurations.Add(new PreparoMap());
            modelBuilder.Configurations.Add(new PacienteMap());
            modelBuilder.Configurations.Add(new CidadeMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new EstadoMap());
        }
    }
}
