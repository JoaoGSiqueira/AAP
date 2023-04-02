using QCuidadoAdmins.Acoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace QCuidadoAdmins.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Consultar(string search, int? i)
        {
            ClienteAcoes acCliente = new ClienteAcoes();

            return View(acCliente.Consultar().ToPagedList(i ?? 1, 5));
        }

        public ActionResult Visualizar(int id)
        {
            ClienteAcoes acCliente = new ClienteAcoes();
            return View(acCliente.Consultar().Find(dto => dto.CLIENTE_ID == id));
        }
    }
}