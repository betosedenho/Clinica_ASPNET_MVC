using Clinica.Site.Negocio.Estrutura;
using Clinica.Site.Persistencia.Context;
using Clinica.Site.Persistencia.Cadastro;
using System.Web.Mvc;
using System;
using System.Web;
using Clinica.Site.Negocio.Cadastro;

namespace Clinica.Site.MVC.Controllers
{
    public class AutenticacaoController : Controller
    {
        private PacienteRepositorio _pacienteRepositorio;
        private ClinicaDbContext db = new ClinicaDbContext();
        private Paciente _paciente;
        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LogOnJS(string usuario)
        {
            if (!(string.IsNullOrEmpty(usuario)))
            {
                try
                {
                    _pacienteRepositorio = new PacienteRepositorio();
                    string cpfUsuario = usuario.Replace(".", "").Replace("-", "");

                    _paciente = _pacienteRepositorio.ObterPaciente(cpfUsuario);

                    if (_paciente == null)
                    {
                        ModelState.AddModelError("", "Paciente não localizado!");
                    }
                    else
                    {
                        FormCollection user = new FormCollection();
                        user["usuario"] = usuario;
                        CriarCookie(user);
                    }
                }
                catch (InvalidOperationException)
                {
                    ModelState.AddModelError("", "Usuário ou Senha inválido!");
                    return Json(false);
                }
            }
            else
            {
                ModelState.AddModelError("UserOrPassword", "Usuário ou Senha Inválido!");
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult LogOn(FormCollection usuario, string returnUrl)
        {
            if (!(string.IsNullOrEmpty(usuario["login"])) && !(string.IsNullOrEmpty(usuario["senha"])))
            {                
                try
                {
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        //returnUrl = "/Paciente/";
                    }

                    _pacienteRepositorio = new PacienteRepositorio();
                    string cpfUsuario = usuario["login"].Replace(".","").Replace("-","");

                    _paciente = _pacienteRepositorio.ObterPaciente(cpfUsuario);

                    if (_paciente == null)
                    {
                        ModelState.AddModelError("", "Paciente não localizado!");
                        ViewBag.ReturnUrl = returnUrl;
                        return View(usuario);
                    }
                    else
                    {
                        CriarCookie(usuario);
                        return Redirect("/Paciente");

                        //ViewBag.ReturnUrl = "/Paciente/";
                        //return View(_paciente);
                        //return Redirect("/Paciente");

                        //ModelState.AddModelError("", "Usuário ou Senha inválido!");
                        //ViewBag.ReturnUrl = returnUrl;
                        //return View(_paciente);
                    }
                }
                catch (InvalidOperationException)
                {
                    ModelState.AddModelError("", "Usuário ou Senha inválido!");
                    ViewBag.ReturnUrl = returnUrl;
                    return View(usuario);
                }                                
            }
            else
            {
                ModelState.AddModelError("UserOrPassword", "Usuário ou Senha Inválido!");
            }

            return View();
        }

        public ActionResult LogOff()
        {
            try
            {
                ApagarCookie();
            }
            finally
            {
                System.Web.Security.FormsAuthentication.SignOut();                
            }
            return Redirect("/Home");
        }

        public void CriarCookie(FormCollection usuario)
        {
            try
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(usuario["login"], false);
                ViewBag.Nome = _paciente.Nome;
                HttpCookie cookieNomeLogin = new HttpCookie("cpfPaciente")
                {
                    Value = _paciente.Cpf.Replace(".","").Replace("-","")
                };
                string[] nome = _paciente.Nome.Split(' ');
                Session["paciente"] = nome[0];
                Response.Cookies.Add(cookieNomeLogin);
            }
            catch(Exception)
            {
            }
        }

        public void ApagarCookie()
        {
            System.Web.HttpCookie cookie = Request.Cookies["cpfPaciente"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(cookie);
            }
        }
    }
}