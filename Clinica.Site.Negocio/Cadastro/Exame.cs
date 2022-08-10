using System;
using System.Collections.Generic;

namespace Clinica.Site.Negocio.Cadastro
{
    public class Exame
    {
        public Exame()
        {            
        }
        public Exame(int idExame, string nome, string descricao, string orientacao, bool ativo, TipoPublico tipoPublico, string observacao):this()
        {
            this.Id = idExame;
            this.Nome = nome;
            this.Descricao = descricao;
            this.TipoPublico = tipoPublico;
        }        
        public int Id { get; set; }        
        public string Nome { get; set; }        
        public string Descricao { get; set; }        
        public TipoPublico? TipoPublico { get; set; }
        public override string ToString()
        {
            return Nome;
        }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
