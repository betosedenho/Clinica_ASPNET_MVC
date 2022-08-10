using System.Web.Mvc;

namespace Clinica.Site.MVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.NomeUsuario = this.ViewBag.NomeUsuario;
            return View();
        }
    }
}