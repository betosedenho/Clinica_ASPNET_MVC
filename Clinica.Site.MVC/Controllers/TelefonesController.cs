using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Cadastro;
using Clinica.Site.Persistencia.Context;

namespace Clinica.Site.MVC.Controllers
{
    [Authorize]
    public class TelefonesController : Controller
	{
		private ClinicaDbContext db = new ClinicaDbContext();

		// GET: Telefones
		public ActionResult Index()
		{
			return View(db.Telefone.ToList());
		}

		// GET: Telefones/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Telefone telefone = db.Telefone.Find(id);
			if (telefone == null)
			{
				return HttpNotFound();
			}
			return View(telefone);
		}

		// GET: Telefones/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Telefones/Create
		// Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
		// obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Ddd,Numero,TipoTelefone")] Telefone telefone)
		{
			if (ModelState.IsValid)
			{
				db.Telefone.Add(telefone);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(telefone);
		}

		// GET: Telefones/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Telefone telefone = db.Telefone.Find(id);
			if (telefone == null)
			{
				return HttpNotFound();
			}
			return View(telefone);
		}

		// POST: Telefones/Edit/5
		// Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
		// obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Ddd,Numero,TipoTelefone")] Telefone telefone)
		{
			if (ModelState.IsValid)
			{
				db.Entry(telefone).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(telefone);
		}

		// GET: Telefones/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Telefone telefone = db.Telefone.Find(id);
			if (telefone == null)
			{
				return HttpNotFound();
			}
			return View(telefone);
		}

		// POST: Telefones/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Telefone telefone = db.Telefone.Find(id);
			db.Telefone.Remove(telefone);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		[HttpPost]
		public JsonResult Salvar(int Id, string DDD, string Numero, bool Ativo, int Ordenacao)
		{
			TelefoneRepositorio _repTelefones = new TelefoneRepositorio();
			Telefone telefone = new Telefone(Id, DDD, Numero, TipoTelefone.Comercial);
			return Json(_repTelefones.Salvar(telefone));
			
		}
    }
}
