using MySql.Data.MySqlClient;
using QCuidadoAdmins.Data;
using QCuidadoAdmins.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QCuidadoAdmins.Acoes
{
    public class DashboardAcoes
    {
        public List<Dashboard> Consultar()
        {
            Conexao con = new Conexao();
            var listaDashboard = new List<Dashboard>();
            MySqlCommand cmd = new MySqlCommand("call sp_Dashboard;", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);
            
            foreach (DataRow dr in tabela.Rows)
            {
                listaDashboard.Add(
                    new Dashboard
                    {
                        //Caixa = Decimal.Parse(dr["Caixa"].ToString()),
                        Funcionarios = int.Parse(dr["Funcionarios"].ToString()),
                        Clientes = int.Parse(dr["Clientes"].ToString()),
                        Prestadores = int.Parse(dr["Prestadores"].ToString()),
                        Empresas = int.Parse(dr["Empresas"].ToString()),
                        Servicos = int.Parse(dr["Servicos"].ToString()),
                    });
            }
            return listaDashboard;
        }
    }
}