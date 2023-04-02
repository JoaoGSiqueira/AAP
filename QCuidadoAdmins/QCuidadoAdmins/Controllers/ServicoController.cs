using MySql.Data.MySqlClient;
using QCuidadoAdmins.Acoes;
using QCuidadoAdmins.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using QCuidadoAdmins.Models;

namespace QCuidadoAdmins.Controllers
{
    public class ServicoController : Controller
    {
        // GET: Servico
        public ActionResult Consultar(string search, int?i)
        {
            ServicoAcoes acServico = new ServicoAcoes();
            return View(acServico.Consultar().ToPagedList(i ?? 1,5));
        }

        public ActionResult Visualizar(int id)
        {
            ServicoAcoes acServico = new ServicoAcoes();
            return View(acServico.Consultar().Find(dto => dto.AGENDASERVICO_ID == id));
        }

        public ActionResult ConsultarConfirmado(string search, int? i)
        {
            ServicoAcoes acServico = new ServicoAcoes();
            return View(acServico.ConsultarConfirmado().ToPagedList(i ?? 1, 5));
        }

        public ActionResult VisualizarConfirmado(int id)
        {
            ServicoAcoes acServico = new ServicoAcoes();
            return View(acServico.ConsultarConfirmado().Find(dto => dto.AGENDASERVICO_ID == id));
        }

        public ActionResult Editar(int id)
        {
            DropDownPrestador();
            ServicoAcoes acServico = new ServicoAcoes();
            return View(acServico.Consultar().Find(dto => dto.AGENDASERVICO_ID == id));
        }

        [HttpPost]
        public ActionResult Editar(Servicos servico)
        {
            DropDownPrestador();
            if (ModelState.IsValid)
            {
                ServicoAcoes acServico = new ServicoAcoes();
                acServico.Alterar(servico);
                return RedirectToAction("Consultar");
            }
            else
            {
                ViewBag.msgErro = "É necessário Preencher todos os campos em *";
            }
            return View();
        }

        public void DropDownPrestador()
        {
            List<SelectListItem> prestador = new List<SelectListItem>();
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select * from PRESTADOR", con.MyConectarBD());
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                prestador.Add(new SelectListItem
                {
                    Text = rdr[1].ToString(),
                    Value = rdr[0].ToString(),
                });
            }
            con.MyDesConectarBD();

            ViewBag.Prestador = new SelectList(prestador, "Value", "Text");
        }
    }
}