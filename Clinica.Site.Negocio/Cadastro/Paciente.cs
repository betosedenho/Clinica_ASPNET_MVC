using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Site.Negocio.Cadastro
{
    public class Paciente
    {
        public Paciente()
        {

        }
        public Paciente(string nome, string cpf, string email, string dataNascimento, string celular, string telFixo, bool paciente)
        {
            this.Id = 0;
            this.Cpf = cpf.Replace(".", "").Replace("-", "");
            this.Nome = nome;
            this.Email = email;
            this.DataNascimento = dataNascimento;
            this.Celular = celular;
            this.TelefoneFixo = telFixo == null ? "" : telFixo;
            this.EhPaciente = paciente;

            DateTime DtNascimento = DateTime.ParseExact(dataNascimento.Replace("/", ""), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime Hoje = DateTime.Now;
            int Anos = new DateTime(DateTime.Now.Subtract(DtNascimento).Ticks).Year-1;
            int Meses = 0;
            DateTime AnosTranscorridos = DtNascimento.AddYears(Anos);

            for(int i = 1; i <= 12; i++)
            {
                if(AnosTranscorridos.AddMonths(i) == Hoje)
                {
                    Meses = i;
                    break;
                }
                else if(AnosTranscorridos.AddMonths(i) >= Hoje)
                {
                    Meses = i - 1;
                    break;
                }
            }

            int Dias = Hoje.Subtract(AnosTranscorridos.AddMonths(Meses)).Days;
            string idade = Anos + " anos" + ", " + Meses + " mes(es)" + " e " + Dias + " dia(s)";

            this.FaixaEtaria = idade;
        }
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Celular { get; set; }
        public string TelefoneFixo { get; set; }
        public string FaixaEtaria { get; set; }
        public bool EhPaciente { get; set; }
    }
}
