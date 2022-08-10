using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Context;
using System;
using System.Linq;

namespace Clinica.Site.Persistencia.Cadastro
{
    public class AgendamentoRepositorio
    {
        private ClinicaDbContext contexto;

        public bool Salvar(Agendamento agendamento)
        {
            bool bRet = true;
            using (contexto = new ClinicaDbContext())
            {
                using (var transacao = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        contexto.Agendamento.Add(agendamento);
                        contexto.SaveChanges();
                        transacao.Commit();
                    }
                    catch (Exception)
                    {
                        transacao.Rollback();
                        bRet = false;
                    }
                }
            }
            return bRet;
        }

        public bool AlterarAgendamento(int Id, bool Ativo, string Observacao, string Data, string Horario)
        {
            bool bRet = true;
            using (contexto = new ClinicaDbContext())
            {
                using (var transacao = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        var item = contexto.Agendamento.SingleOrDefault(a => a.Id == Id);
                        if (item != null)
                        {
                            item.Ativo = Ativo;
                            item.Observacao = Observacao;
                            item.Data = Data;
                            item.Horario = Horario;
                            contexto.SaveChanges();
                            transacao.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transacao.Rollback();
                        bRet = false;
                    }
                }
            }
            return bRet;
        }
    }
}
