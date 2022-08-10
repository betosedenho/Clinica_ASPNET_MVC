using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Site.Comum
{
    public sealed class Idade
    {
        public static string CalcularIdade(string dataNascimento)
        {
            DateTime DtNascimento = DateTime.ParseExact(dataNascimento.Replace("/", ""), "ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime Hoje = DateTime.Now;
            int Anos = new DateTime(DateTime.Now.Subtract(DtNascimento).Ticks).Year - 1;
            int Meses = 0;
            DateTime AnosTranscorridos = DtNascimento.AddYears(Anos);

            for (int i = 1; i <= 12; i++)
            {
                if (AnosTranscorridos.AddMonths(i) == Hoje)
                {
                    Meses = i;
                    break;
                }
                else if (AnosTranscorridos.AddMonths(i) >= Hoje)
                {
                    Meses = i - 1;
                    break;
                }
            }

            int Dias = Hoje.Subtract(AnosTranscorridos.AddMonths(Meses)).Days;
            string idade = Anos + " anos" + ", " + Meses + " mes(es)" + " e " + Dias + " dia(s)";
            return idade;
        }
    }
}
