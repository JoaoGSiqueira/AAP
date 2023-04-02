using MySql.Data.MySqlClient;
using QCuidadoAdmins.Acoes;
using QCuidadoAdmins.Data;
using QCuidadoAdmins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using PagedList;
using PagedList.Mvc;

namespace QCuidadoAdmins.Controllers
{
    public class PrestadorController : Controller
    {
        // GET: Prestador
        
        public ActionResult Cadastrar()
        {
            DropDownEmpresa();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Prestador prestador)
        {
            DropDownEmpresa();
            if (ModelState.IsValid)
            {
                PrestadorAcoes acPrestador = new PrestadorAcoes();
                acPrestador.Cadastrar(prestador);
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
            PrestadorAcoes acPrestador = new PrestadorAcoes();
            return View(acPrestador.Consultar().ToPagedList(i ?? 1, 5));
        }

        public ActionResult Excluir(int id)
        {
            PrestadorAcoes acPrestador = new PrestadorAcoes();
            acPrestador.Excluir(id);
            return RedirectToAction("Consultar");
        }

        public ActionResult Visualizar(int id)
        {
            PrestadorAcoes acPrestador = new PrestadorAcoes();
            return View(acPrestador.Consultar().Find(dto => dto.PRESTADOR_ID == id));
        }

        public ActionResult Editar(int id)
        {
            DropDownEmpresa();
            PrestadorAcoes acPrestador = new PrestadorAcoes();
            return View(acPrestador.Consultar().Find(dto => dto.PRESTADOR_ID == id));
        }

        [HttpPost]
        public ActionResult Editar(Prestador prestador)
        {
            DropDownEmpresa();
            if(ModelState.IsValid)
            {
                PrestadorAcoes acPrestador = new PrestadorAcoes();
                acPrestador.Alterar(prestador);
                return RedirectToAction("Consultar");
            }
            else
            {
                ViewBag.msgErro = "É necessário Preencher todos os campos em *";
            }
            return View();
        }

        public void DropDownEmpresa()
        {
            List<SelectListItem> empresa = new List<SelectListItem>();
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select * from EMPRESA", con.MyConectarBD());
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                empresa.Add(new SelectListItem
                {
                 Text = rdr[1].ToString(),
                 Value = rdr[0].ToString(),
                });
            }
            con.MyDesConectarBD();

            ViewBag.empresa = new SelectList(empresa, "Value", "Text");
        }
    }
}