using QCuidadoClientes.Acoes;
using QCuidadoClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace QCuidadoClientes.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult Perfil()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        public ActionResult Alterar(int id)
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }

            ClienteAcoes acCliente = new ClienteAcoes();
            return View(acCliente.ConsultaPerfil(id).Find(dto => dto.CLIENTE_ID == id));
        }

        [HttpPost]
        public ActionResult Alterar(Cliente dto)
        {
            if (ModelState.IsValid)
            {
                ClienteAcoes acCliente = new ClienteAcoes();
                acCliente.Alterar(dto);
                TempData["AlertMessage"] = "Alteração realizada com sucesso!";
                return RedirectToAction("Alterar", "Perfil");
            }
            else
            {
                ViewBag.msgErro = "É necessário Preencher todos os campos!";
            }
            return View();
        }

        public ActionResult SolicitarServico()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
        [HttpPost]
        public ActionResult SolicitarServico(Agendaservico servico)
        {
            if(ModelState.IsValid)
            {
                servico.CLIENTE_ID = int.Parse(Session["CLIENTE_ID"].ToString());
                AgendaservicoAcoes acServico = new AgendaservicoAcoes();
                acServico.Cadastrar(servico);
                TempData["AlertMessage"] = "Solicitação agendada com sucesso!";
                return RedirectToAction("SolicitarServico");
            }
            else
            {
                ViewBag.msgErro = "É necessário Preencher os campos em * !";
            }
            return View();
        }

        public ActionResult Historico(int id, int?i)
        {
            AgendaservicoAcoes acServico = new AgendaservicoAcoes();
            return View(acServico.Consultar(id).ToPagedList(i?? 1 , 5));
        }

        public ActionResult Conta()
        {
            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        public ActionResult DesativarConta(int id)
        {
            ClienteAcoes acCliente = new ClienteAcoes();
            acCliente.DesativarConta(id);
            return RedirectToAction("Perfil");
        }

        public ActionResult AtivarConta(int id)
        {
            ClienteAcoes acCliente = new ClienteAcoes();
            acCliente.AtivarConta(id);
            return RedirectToAction("Perfil");
        }
    }
}