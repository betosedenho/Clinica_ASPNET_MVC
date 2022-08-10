using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Cadastro;
using Clinica.Site.Persistencia.Context;

namespace Clinica.Site.MVC.Controllers
{
    public class PreparosController : Controller
    {
        private ClinicaDbContext db = new ClinicaDbContext();        
        private PreparoRepositorio _preparoRepositorio;
        private IEnumerable<Preparo> _preparoColecao;

        // GET: Preparos
        //[Authorize]
        public ActionResult Index()
        {
            _preparoRepositorio = new PreparoRepositorio();
            _preparoColecao = _preparoRepositorio.ObterTodos();

            return View(_preparoColecao);            
        }

		public ActionResult Preparos()
		{
            return View(db.Preparo.ToList());
		}

        // GET: Preparos/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preparo preparo = db.Preparo.Find(id);
            if (preparo == null)
            {
                return HttpNotFound();
            }
            return View(preparo);
        }
	}
}
