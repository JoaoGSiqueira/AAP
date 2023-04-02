using PagedList;
using QCuidadoAdmins.Acoes;
using QCuidadoAdmins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

namespace QCuidadoAdmins.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Cadastrar()
        {
            ViewBag.usuario = Session["usuarioLogado"];
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Empresa empresa)
        {
            if(ModelState.IsValid)
            {
                EmpresaAcoes acEmpresa = new EmpresaAcoes();
                acEmpresa.Cadastrar(empresa);
                TempData["AlertMessage"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Cadastrar");
            }
            else
            {
                ViewBag.msgErro = "É necessário Preencher todos os campos em * ";
            }
            return View();
        }

        public ActionResult Consultar(string search, int?i)
        {
            EmpresaAcoes acEmpresa = new EmpresaAcoes();
            return View(acEmpresa.Consultar().ToPagedList(i ?? 1, 5));
        }

        public ActionResult Excluir(int id)
        {
            EmpresaAcoes acEmpresa = new EmpresaAcoes();
            acEmpresa.Excluir(id);
            return RedirectToAction("Consultar");
        }

        public ActionResult Visualizar(int id)
        {
            EmpresaAcoes acEmpresa = new EmpresaAcoes();
            return View(acEmpresa.Consultar().Find(dto => dto.EMPRESA_ID == id));
        }

        public ActionResult Editar(int id)
        {
            EmpresaAcoes acEmpresa = new EmpresaAcoes();
            return View(acEmpresa.Consultar().Find(dto => dto.EMPRESA_ID == id));
        }
        
        [HttpPost]
        public ActionResult Editar(Empresa empresa)
        {
            if(ModelState.IsValid)
            {
                EmpresaAcoes acEmpresa = new EmpresaAcoes();
                acEmpresa.Alterar(empresa);
                return RedirectToAction("Consultar");
            }
            else
            {
                ViewBag.msgErro = "É necessário Preencher todos os campos em *";
            }
            return View();
        }
    }
}