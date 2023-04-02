using QCuidadoAdmins.Acoes;
using QCuidadoAdmins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QCuidadoAdmins.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        LoginAcoes log = new LoginAcoes();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Funcionario verLogin)
        {
            log.TestarUsuario(verLogin);

            if (verLogin.EMAIL_FUNCIONARIO != null && verLogin.SENHA_FUNCIONARIO != null)
            {
                Session["usuarioLogado"] = verLogin.EMAIL_FUNCIONARIO.ToString();
                Session["senhaLogado"] = verLogin.SENHA_FUNCIONARIO.ToString();

                if (verLogin.NV_ACESSO == 1)
                {
                    Session["tipoLogado1"] = verLogin.NV_ACESSO.ToString();
                }
                else
                {
                    Session["tipoLogado2"] = verLogin.NV_ACESSO.ToString();
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.msgLogar = "Funcionário não encontrado. Verifique o Email e a Senha!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["tipoLogado1"] = null;
            Session["tipoLogado2"] = null;
            return RedirectToAction("Index", "Login");
        }

        public ActionResult semAcesso()
        {
            Response.Write("<script>alert('Sem acesso')</script>");
            return View();
        }
    }
}