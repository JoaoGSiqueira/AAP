using MySql.Data.MySqlClient;
using QCuidadoClientes.Data;
using QCuidadoClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCuidadoClientes.Acoes
{
    public class LoginAcoes
    {
        public void TestarUsuario(Cliente user)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select * from CLIENTE where EMAIL_CLIENTE = @EMAIL_CLIENTE" +
                " and SENHA_CLIENTE = @SENHA_CLIENTE", con.MyConectarBD());

            cmd.Parameters.Add("@EMAIL_CLIENTE", MySqlDbType.VarChar).Value = user.EMAIL_CLIENTE;
            cmd.Parameters.Add("@SENHA_CLIENTE", MySqlDbType.VarChar).Value = user.SENHA_CLIENTE;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.CLIENTE_ID = int.Parse(leitor["CLIENTE_ID"].ToString());
                    user.EMAIL_CLIENTE = Convert.ToString(leitor["EMAIL_CLIENTE"]);
                    user.SENHA_CLIENTE = Convert.ToString(leitor["SENHA_CLIENTE"]);
                    
                }
            }
            else
            {
                user.EMAIL_CLIENTE = null;
                user.SENHA_CLIENTE = null;
            }
            con.MyDesConectarBD();
        }
    }
}