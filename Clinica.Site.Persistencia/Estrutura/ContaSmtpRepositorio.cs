using Clinica.Site.Negocio.Estrutura;
using Clinica.Site.Persistencia.Context;
using System;
using System.Linq;

namespace Clinica.Site.Persistencia.Cadastro
{
    public class ContaSmtpRepositorio
    {
        private ClinicaDbContext contexto;

        public ContaSmtp Obter()
        {
            using (contexto = new ClinicaDbContext())
            {
                return contexto.ContaSmtp.Where(c => c.Ativo == true).ToList().Last();
            }
        }

        public bool Salvar(ContaSmtp smtp)
        {
            using (contexto = new ClinicaDbContext())
            {
                using (var transacao = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        if (smtp.Id == 0)
                            contexto.ContaSmtp.Add(smtp);
                        else
                        {
                            var result = contexto.ContaSmtp.SingleOrDefault(s => s.Id == smtp.Id);
                            if (result != null)
                            {
                                result.Nome = smtp.Nome;
                                result.Servidor = smtp.Servidor;
                                result.Porta = smtp.Porta;
                                result.Seguranca = smtp.Seguranca;
                                result.Senha = smtp.Senha;
                                result.Endereco = smtp.Endereco;
                                result.Ativo = smtp.Ativo;
                                result.EmailFrom = smtp.EmailFrom;
                            }

                        }
                        contexto.SaveChanges();
                        transacao.Commit();
                    }
                    catch (Exception)
                    {
                        transacao.Rollback();
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
