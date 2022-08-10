using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinica.Site.Persistencia.Cadastro
{
    public class EnderecoRepositorio
    {
        private ClinicaDbContext contexto;

        public EnderecoRepositorio()
        {
        }

        public Endereco ObterEnderecoPaciente(int id)
        {
            using (contexto = new ClinicaDbContext())
            {
                return contexto.Enderecos.Where(m => m.Paciente_Id == id).SingleOrDefault();
            }
        }

        public bool Salvar(Endereco endereco)
        {
            using (contexto = new ClinicaDbContext())
            {
                using (var transacao = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        contexto.Enderecos.Add(endereco);
                        contexto.SaveChanges();
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro ao salvar o Endereco {0}", e);
                        transacao.Rollback();
                        return false;
                    }
                    return true;
                }
            }
        }

    }
}
