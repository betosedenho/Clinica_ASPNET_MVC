using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinica.Site.Negocio.Estrutura;
using Clinica.Site.Persistencia.Estrutura;
using Clinica.Site.Persistencia.Context;
using System.IO;
using Clinica.Site.Comum;

namespace Clinica.Site.MVC.Controllers
{
    public class CarrosselsController : Controller
    {
        private ClinicaDbContext db = new ClinicaDbContext();

        // GET: Carrossels
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Carrossel.ToList());
        }

        // GET: Carrossels/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrossel carrossel = db.Carrossel.Find(id);
            if (carrossel == null)
            {
                return HttpNotFound();
            }
            return View(carrossel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}
