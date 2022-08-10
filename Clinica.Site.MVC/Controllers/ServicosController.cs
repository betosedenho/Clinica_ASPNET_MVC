using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Cadastro;
using Clinica.Site.Persistencia.Estrutura;
using Clinica.Site.Negocio.Estrutura;
using Clinica.Site.Comum;
using Clinica.Site.Persistencia.Context;
using Clinica.Site.MVC.Models;

namespace Clinica.Site.MVC.Views.Servicos
{
    public class ServicosController : Controller
    {
        private ClinicaDbContext db = new ClinicaDbContext();
        
        // GET: Servicos
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Agendamento.OrderByDescending(a => a.Id).ToList());
        }
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamentos = db.Agendamento.Find(id);
            if (agendamentos == null)
            {
                return HttpNotFound();
            }
            return View(agendamentos);
        }

        // POST: Emails/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agendamento agendamento = db.Agendamento.Find(id);
            db.Agendamento.Remove(agendamento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Agendamentos()
        {
            System.Web.HttpCookie cookie = Request.Cookies["cpfPaciente"];
            if (cookie == null)
                return RedirectToAction("../Paciente/Create");

            EspecialidadeRepositorio _especialidade = new EspecialidadeRepositorio();
			IEnumerable<Especialidade> especialidadeConsulta = _especialidade.ObterEspecialidade(ItemEspecialidade.Todas);

			ExameRepositorio _exames = new ExameRepositorio();
			IEnumerable<Exame> exames = _exames.ObterTodosExame();

			var model = new EspecialidadesViewModels
			{
				Consultas = especialidadeConsulta,
				Exames = exames
			};

			return View(model);
        }

		public ActionResult Consultas()
		{
			var _repTelefones = new TelefoneRepositorio();
			IEnumerable<Telefone> telefonesColecao = _repTelefones.ObterTelefone();
			ViewData["telefones"] = telefonesColecao;

            EspecialidadeRepositorio _especialidade = new EspecialidadeRepositorio();
			IEnumerable<Especialidade> especialidadeMedicaColecao = _especialidade.ObterEspecialidade(ItemEspecialidade.Todas);
			return View(especialidadeMedicaColecao);
		}
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agendamento agendamento = db.Agendamento.Find(id);
            if (agendamento == null)
            {
                return HttpNotFound();
            }
            return View(agendamento);
        }

		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Agendamento agendamento = db.Agendamento.Find(id);
			if (agendamento == null)
			{
				return HttpNotFound();
			}
			return View(agendamento);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Ativo")] Agendamento agendamento)
		{
			if (ModelState.IsValid)
			{
				db.Entry(agendamento).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(agendamento);
		}

        [HttpPost]
        public ActionResult SalvarAgendamento(string cpf, string  nome, string email, string dataNascimento, string telefone, string celular, bool ehcliente,
            string consultas, string exames, string checkup, string dataPreferencial1, string dataPreferencial2, string  dataPreferencial3, string periodoPreferencial,
            string comoConheceu)
        {
            Paciente paciente = new Paciente(nome, cpf, email, dataNascimento, celular, telefone, ehcliente);
            PacienteRepositorio pacienteRep = new PacienteRepositorio();
            pacienteRep.ObterPaciente(paciente.Cpf);

            Agendamento agendamento = new Agendamento();
            AgendamentoRepositorio repAgendamento = new AgendamentoRepositorio();
            return Json(repAgendamento.Salvar(agendamento)); 
        }

		[HttpPost]
		public ActionResult AlterarAgendamento(int Id, bool Ativo, string Observacao, string Data, string Horario)
		{
            //AgendamentoRepositorio _rep = new AgendamentoRepositorio();
            //return Json(_rep.AlterarAgendamento(Id, Ativo, Observacao, Data, Horario));
            return null;
		}

		public JsonResult SendEmail(string Modulo, string Nome, string Email, string Assunto, string Mensagem, string MensagemHistorico)
        {

            Smtp _smtp = new Smtp();
            bool _enviou = _smtp.EnviarEmail(Modulo, Nome, Email, Assunto, Mensagem);

            if (!_enviou)
                return Json(_enviou);

            return Json(_enviou);
        }
    }
}