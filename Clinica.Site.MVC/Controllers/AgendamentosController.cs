using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinica.Site.MVC.Controllers
{
    public class AgendamentosController : Controller
    {
        // GET: Agendamentos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Agendamentos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Agendamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agendamentos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agendamentos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Agendamentos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agendamentos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Agendamentos/Delete/5
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
    }
}
