using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Mvc;
using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Cadastro;
using System.Text;

namespace Clinica.Site.MVC.Controllers
{
    public class CidadeController : Controller
    {
        private List<Cidade> _cidades = new List<Cidade>();
        private CidadeRepositorio _cidadeRepositorio;

        // GET: Cidade
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Index(int idEstado)
        {
            _cidadeRepositorio = new CidadeRepositorio();
            _cidades = _cidadeRepositorio.ObterCidadesPorEstado(idEstado);

            List<Object> resultado = new List<object>();
            foreach(var item in _cidades)
            {
                resultado.Add(new {Nome = item.Nome, Id = item.Id});
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        // GET: Cidade/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cidade/Create
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

        // GET: Cidade/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cidade/Edit/5
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

        // GET: Cidade/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cidade/Delete/5
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
