using System;
using System.Collections.Generic;

namespace Clinica.Site.Negocio.Cadastro
{
    public class Especialidade
    {
        public Especialidade()
        {            
        }
        public Especialidade(int idEspecialidade, string nome, string descricao, bool ativo, TipoEspecialidade tipoEspecialidade, ItemEspecialidade itemEsp)
        {
            this.Id = idEspecialidade;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Ativo = ativo;
            this.TipoEspecialidade = tipoEspecialidade;
            this.ItemEspecialidade = itemEsp;            
        }
        public Especialidade(int idEspecialidade, string nome, string descricao, bool ativo, TipoEspecialidade tipoEspecialidade, ItemEspecialidade itemEsp, 
            TipoPublico tipoPublico)
        {
            this.Id = idEspecialidade;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Ativo = ativo;
            this.TipoEspecialidade = tipoEspecialidade;
			this.ItemEspecialidade = itemEsp;
            this.TipoPublico = tipoPublico;
		}        
        public int Id { get; private set; }
        public TipoEspecialidade TipoEspecialidade { get; set; }
        public string Nome { get; set; }        
        public string Descricao { get; set; }
        public bool Ativo { get; set; }        
		public ItemEspecialidade ItemEspecialidade { get; set; }
        public TipoPublico? TipoPublico { get; set; }    
        public override string ToString()
        {
            return Nome;
        }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}
