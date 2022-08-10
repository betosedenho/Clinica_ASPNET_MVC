using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Clinica.Site.Negocio.Cadastro
{
    public class Agendamento
    {
        public Agendamento()
        {
        }

        public Agendamento(string Nome, string Cpf, string DataNascimento, string Email, string Telefone,
                            string Celular, bool EhCliente, string DataPreferencial1, string DataPreferencial2, string DataPreferencial3,
                            string PeriodoPreferencial, string ComoConheceu, string Consulta, string Exames, string Checkup, bool Ativo,
                            List<Paciente> pacientes, List<Exame> exames, List<Especialidade> especialidades)
        {
            this.Id = 0;
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.DataNascimento = DataNascimento;
            this.Email = Email;
            this.Telefone = Telefone;
            this.Celular = Celular;
            this.EhCliente = EhCliente;
            this.DataPreferencial1 = DataPreferencial1;
            this.DataPreferencial2 = DataPreferencial2;
            this.DataPreferencial3 = DataPreferencial3;
            this.PeriodoPreferencial = PeriodoPreferencial;
            this.ComoConheceu = ComoConheceu;
            this.Checkup = Checkup;
            this.Ativo = Ativo;
            this.Observacao = string.Empty;
            this.DataInclusao = DateTime.Now;
            //this.Pacientes = pacientes;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public bool EhCliente { get; set; }
        public string DataPreferencial1 { get; set; }
        public string DataPreferencial2 { get; set; }
        public string DataPreferencial3 { get; set; }
        public string PeriodoPreferencial { get; set; }
        public string ComoConheceu { get; set; }
        public string Checkup { get; set; }
        public bool Ativo { get; set; }
        public string Observacao { get; set; }
        public string Data { get; set; }
        public string Horario { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataInclusao { get; set; }
        
        public virtual ICollection<Exame> Exames { get; set; }
        public virtual ICollection<Especialidade> Especialidades { get; set; }
        public virtual Paciente Paciente { get; set; }  

    }
}
