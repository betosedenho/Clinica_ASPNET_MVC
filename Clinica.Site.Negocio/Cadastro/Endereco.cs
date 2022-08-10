using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Site.Negocio.Cadastro
{
    public class Endereco
    {
        public Endereco()
        {
        }

        public Endereco(int id, string logradouro, string numero, string complemento, string bairro, string nomecidade, string cep, Paciente paciente, Cidade cidade)
        {
            this.Id = 0;
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Complemento = complemento == null ? "" : complemento;
            this.Bairro = bairro;
            this.NomeCidade = nomecidade;
            this.Cep = cep;
            Paciente_Id = paciente.Id;
            Cidade_Id = cidade.Id;
        }

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string NomeCidade { get; set; }
        public string Cep { get; set; }
        public int? Paciente_Id { get; set; }
        public int? Cidade_Id { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Cidade Cidade { get; set; }
    }
}
