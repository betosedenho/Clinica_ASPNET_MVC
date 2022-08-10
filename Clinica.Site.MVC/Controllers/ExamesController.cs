using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Cadastro;
using Clinica.Site.Persistencia.Context;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace Clinica.Site.MVC.Controllers
{
    public class ExamesController : Controller
    {
        
        private ClinicaDbContext db = new ClinicaDbContext();
        private ExameRepositorio _exameRepositorio;
        private IEnumerable<Exame> _exameColecao;
        
        // GET: Exames
        public ActionResult ExamesQueRealizamos()
        {
            _exameRepositorio = new ExameRepositorio();
            _exameColecao = _exameRepositorio.ObterTodosExame();

            return View(_exameColecao);
        }        
        [Authorize]
        public ActionResult Index()
        {
            _exameRepositorio = new ExameRepositorio();
            _exameColecao = _exameRepositorio.ObterTodosExame();            

            return View(_exameColecao);
        }
        [Authorize]
        public ActionResult Edit(int? id)
        {
            return View();
        }
        [Authorize]
        public ActionResult Details(int? id)
        {
            return View();
        }
        [Authorize]
        public ActionResult Delete(int? id)
        {
            return View();
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }
    }
}