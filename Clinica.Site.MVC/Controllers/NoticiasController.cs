using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinica.Site.Negocio.Estrutura;
using Clinica.Site.Persistencia.Estrutura;
using Clinica.Site.Persistencia.Context;

namespace Clinica.Site.MVC.Controllers
{
    [Authorize]
    public class NoticiasController : Controller
    {
        private ClinicaDbContext db = new ClinicaDbContext();

        // GET: Noticias
        public ActionResult Index()
        {
            return View(db.Noticias.ToList());
        }

        // GET: Noticias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticias noticias = db.Noticias.Find(id);
            if (noticias == null)
            {
                return HttpNotFound();
            }
            return View(noticias);
        }
	}
}
