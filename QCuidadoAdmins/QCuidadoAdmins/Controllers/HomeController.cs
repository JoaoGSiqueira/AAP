using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QCuidadoAdmins.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if(Session["usuarioLogado"] == null || Session["senhaLogado"]==null)
            //{
            //    return RedirectToAction("semAcesso", "Login");
            //}
            ViewBag.usuario = Session["usuarioLogado"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}