using Clinica.Site.Negocio.Estrutura;
using Clinica.Site.Negocio.Cadastro;
using Clinica.Site.Persistencia.Estrutura;
using Clinica.Site.Persistencia.Cadastro;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Clinica.Site.MVC.Controllers
{
    public class HomeController : Controller
    {
        private CarrosselRepositorio _carrossel;
        private NoticiasRepositorio _noticias;
        private HorariosRepositorio _horarios;

        public ActionResult Index()
        {   
            _carrossel = new CarrosselRepositorio();
            _noticias = new NoticiasRepositorio();
         
            IEnumerable<Carrossel> carrosselColecao = _carrossel.Obter();
            ViewData["carrossel"] = carrosselColecao;

            IEnumerable<Noticias> noticiasColecao = _noticias.Obter();
            ViewData["noticias"] = noticiasColecao;

            return View();
        }
      
        public ActionResult Localizacao()
        {  
            return View();
        }
        public ActionResult FaleConosco()
        {
            _horarios = new HorariosRepositorio();
            IEnumerable<Horarios> horariosColecao = _horarios.Obter();
            ViewData["horarios"] = horariosColecao;
            return View();
        }
    }
}