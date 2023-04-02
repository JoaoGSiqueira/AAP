using QCuidadoAdmins.Acoes;
using QCuidadoAdmins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace QCuidadoAdmins.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Cadastrar()
        {
            ViewBag.usuario = Session["usuarioLogado"];
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                FuncionarioAcoes acFuncionario = new FuncionarioAcoes();
                acFuncionario.Cadastrar(funcionario);
                
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
            
            FuncionarioAcoes acFuncionario = new FuncionarioAcoes();
           
            return View(acFuncionario.Consultar().ToPagedList(i ?? 1, 5)) ;
        }

        public ActionResult Excluir(int id)
        {
            FuncionarioAcoes acFuncionario = new FuncionarioAcoes();
            acFuncionario.Excluir(id);
            return RedirectToAction("Consultar");
        }

        public ActionResult Visualizar(int id)
        {
            FuncionarioAcoes acFuncionario = new FuncionarioAcoes();
            return View(acFuncionario.Consultar().Find(dto => dto.FUNCIONARIO_ID == id));
        }

        public ActionResult Editar(int id)
        {
            FuncionarioAcoes acFuncionario = new FuncionarioAcoes();
            return View(acFuncionario.Consultar().Find(dto => dto.FUNCIONARIO_ID == id));
        }

        [HttpPost]
        public ActionResult Editar(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                FuncionarioAcoes acFuncionario = new FuncionarioAcoes();
                acFuncionario.Alterar(funcionario);
                return RedirectToAction("Consultar");
            }
            else
            {
                ViewBag.msgErro = "É necessário Preencher todos os campos em * ";
            }
            return View();
        }
    }
}