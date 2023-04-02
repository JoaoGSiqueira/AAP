using QCuidadoAdmins.Acoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QCuidadoAdmins.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            DashboardAcoes acDashboard = new DashboardAcoes();
            return View(acDashboard.Consultar());
        }
    }
}