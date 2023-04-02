using QCuidadoClientes.Acoes;
using QCuidadoClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QCuidadoClientes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Homepage()
        {
            return View();
        }

        public ActionResult Servicos()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                ClienteAcoes acCliente = new ClienteAcoes();
                acCliente.Cadastrar(cliente);

                TempData["AlertMessage"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Cadastro");
            }
            else
            {
                ViewBag.msgErro = "É necessário Preencher todos os campos!";
            }
            return View();
        }
    }
}