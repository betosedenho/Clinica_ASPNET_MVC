using System;
using System.Collections.Generic;
using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Cadastro;
using Clinica.Site.Persistencia.Context;
using Clinica.Site.Comum;
using System.Net;
using System.Web.Mvc;

namespace Clinica.Site.MVC.Controllers
{
    public class PacienteController : Controller
    {
        private ClinicaDbContext db = new ClinicaDbContext();
        private PacienteRepositorio _pacienteRepositorio;
        private EnderecoRepositorio _enderecoRepositorio;
        private EstadoRepositorio _estadoRepositorio;
        private CidadeRepositorio _cidadeoRepositorio;

        // GET: Paciente
        public ActionResult Index()
        {
            System.Web.HttpCookie cookie = Request.Cookies["cpfPaciente"];
            string valcookie = cookie.Value;

            Paciente paciente = new Paciente();
            _pacienteRepositorio = new PacienteRepositorio();
            paciente = _pacienteRepositorio.ObterPaciente(valcookie);

            _enderecoRepositorio = new EnderecoRepositorio();
            Endereco endereco = _enderecoRepositorio.ObterEnderecoPaciente(paciente.Id);
            ViewData["endereco"] = endereco;
                       
            return View(paciente);
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            Cidade cidada = new Cidade();
            CidadeRepositorio cidRep = new CidadeRepositorio();
            var cidades = cidRep.ObterCidades();

            Estado estado = new Estado();
            _estadoRepositorio = new EstadoRepositorio();
            List<Estado> estados = _estadoRepositorio.ObterEstados();
            ViewBag.Estado = _estadoRepositorio.ObterEstados();

            return View();
        }

        // POST: Paciente/Create
        [HttpPost]
        public JsonResult Create(string Nome, string Cpf, string Email, string DataNascimento, string Celular,
            string TelefoneFixo, string EhPaciente,
            string Logradouro, string Numero, string Complemento, string Bairro, int Cidade, string CEP, int IdEstado)
        {
            try
            {
                Paciente paciente = null;
                _pacienteRepositorio = new PacienteRepositorio();

                paciente = _pacienteRepositorio.ObterPaciente(Cpf);

                if ( paciente != null )
                    return Json(1);

                 paciente = new Paciente(Nome, Cpf, Email, DataNascimento, Celular, TelefoneFixo, EhPaciente == "true" ? true : false);
                _pacienteRepositorio.Salvar(paciente);
                _cidadeoRepositorio = new CidadeRepositorio();
                Cidade cidade = _cidadeoRepositorio.ObterCidade(Cidade, IdEstado);

                Endereco endereco = new Endereco(0, Logradouro, Numero, Complemento, Bairro, cidade.Nome, CEP, paciente, cidade);
                _enderecoRepositorio = new EnderecoRepositorio();
                _enderecoRepositorio.Salvar(endereco);

                CriarCookie(Cpf);
            }
            catch(Exception)
            {
                //logar excepton
                return Json(false);
            }
            
            return Json(true);
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int id)
        {
            _pacienteRepositorio = new PacienteRepositorio();
            Paciente paciente = _pacienteRepositorio.ObterPaciente(id);
            return View(paciente);
        }

        //POST: Paciente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Paciente paciente = new Paciente();
                paciente.Id = id;
                paciente.Cpf = collection["Cpf"];
                paciente.Nome = collection["Nome"];
                paciente.Email = collection["Email"];
                paciente.DataNascimento = collection["DataNascimento"];
                paciente.Celular = collection["Celular"];
                paciente.TelefoneFixo = collection["TelefoneFixo"];
                string s = collection["EhPaciente"];
                paciente.EhPaciente = collection["EhPaciente"] == "Sim" ? true : false;
                paciente.FaixaEtaria = Comum.Idade.CalcularIdade(paciente.DataNascimento);
                new PacienteRepositorio().Salvar(paciente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Paciente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void CriarCookie(string Cpf)
        {
            System.Web.Security.FormsAuthentication.SetAuthCookie(Cpf, false);
            System.Web.HttpCookie cookieNomeLogin = new System.Web.HttpCookie("cpfPaciente")
            {
                Value = Cpf
            };
            Response.Cookies.Add(cookieNomeLogin);
        }
    }
}
