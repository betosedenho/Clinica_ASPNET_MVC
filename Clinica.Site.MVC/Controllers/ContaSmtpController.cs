using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Clinica.Site.Negocio.Estrutura;
using Clinica.Site.Persistencia.Cadastro;
using Clinica.Site.Persistencia.Context;

namespace Clinica.Site.MVC.Controllers
{
    public class ContaSmtpController : Controller
    {
        private ClinicaDbContext db = new ClinicaDbContext();

        // GET: ContaSmtp
        [Authorize]
        public ActionResult Index()
        {
            return View(db.ContaSmtp.ToList());
        }

        [Authorize]
        // GET: ContaSmtp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaSmtp contaSmtp = db.ContaSmtp.Find(id);
            if (contaSmtp == null)
            {
                return HttpNotFound();
            }
            return View(contaSmtp);
        }

        [Authorize]
        // GET: ContaSmtp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaSmtp contaSmtp = db.ContaSmtp.Find(id);
            if (contaSmtp == null)
            {
                return HttpNotFound();
            }
            return View(contaSmtp);
        }

        // POST: ContaSmtp/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Endereco,Servidor,Senha,Seguranca,Porta,Ativo")] ContaSmtp contaSmtp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contaSmtp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contaSmtp);
        }
        [Authorize]
        // GET: ContaSmtp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaSmtp contaSmtp = db.ContaSmtp.Find(id);
            if (contaSmtp == null)
            {
                return HttpNotFound();
            }
            return View(contaSmtp);
        }
        [Authorize]
        // POST: ContaSmtp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContaSmtp contaSmtp = db.ContaSmtp.Find(id);
            db.ContaSmtp.Remove(contaSmtp);
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
        [Authorize]
        [HttpPost]
        public ActionResult Salvar(int Id, string Nome, string Endereco, string Servidor, string Senha, string ConfSenha, int Porta, bool Ativo, bool Seguranca, string EmailFrom)
        {
            ContaSmtp smtp = new ContaSmtp(Id, Nome, Endereco, Servidor, Senha, Seguranca, Porta, Ativo, EmailFrom);
            ContaSmtpRepositorio _smtp = new ContaSmtpRepositorio();
            bool _result = _smtp.Salvar(smtp);
            return Json(_result);
        }
    }
}
