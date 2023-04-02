using QCuidadoClientes.Acoes;
using QCuidadoClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QCuidadoClientes.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        LoginAcoes log = new LoginAcoes();
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Cliente login)
        {
            log.TestarUsuario(login);
            if(login.EMAIL_CLIENTE != null && login.SENHA_CLIENTE != null)
            {
                FormsAuthentication.SetAuthCookie(login.EMAIL_CLIENTE, false);

                Session["usuarioLogado"] = login.EMAIL_CLIENTE.ToString();
                Session["senhaLogado"] = login.SENHA_CLIENTE.ToString();
                Session["CLIENTE_ID"] = login.CLIENTE_ID.ToString();

                return RedirectToAction("Homepage", "Home");
            }
            else
            {
                ViewBag.msgLogar = "Usuário não encontrado! Verifique o Email e a Senha!";
                return View();
            }
            
        }

        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["CLIENTE_ID"] = null;
            return RedirectToAction("Homepage", "Home");
        }

    }
}