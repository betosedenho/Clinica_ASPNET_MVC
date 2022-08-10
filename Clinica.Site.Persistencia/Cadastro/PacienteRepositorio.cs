using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Context;
using System.Data.Entity.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clinica.Site.Persistencia.Cadastro
{
    public class PacienteRepositorio
    {
        private ClinicaDbContext contexto;

        public Paciente ObterPaciente(string cpf)
        {
            using (contexto = new ClinicaDbContext())
            {
                return contexto.Paciente.SingleOrDefault(p => p.Cpf == cpf); 
            }
        }

        public Paciente ObterPaciente(int id)
        {
            using (contexto = new ClinicaDbContext())
            {
                return contexto.Paciente.SingleOrDefault(p => p.Id == id);
            }
        }

        public bool Salvar(Paciente paciente)
        {
            using (contexto = new ClinicaDbContext())
            {
                using (var transacao = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        contexto.Paciente.AddOrUpdate(paciente);
                        contexto.SaveChanges();
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro ao salvar o Paciente {0}", e);
                        transacao.Rollback();
                        return false;
                    }
                    return true;
                }
            }
        }
    }
}
