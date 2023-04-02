using MySql.Data.MySqlClient;
using QCuidadoAdmins.Data;
using QCuidadoAdmins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCuidadoAdmins.Acoes
{
    public class LoginAcoes
    {
        public void TestarUsuario(Funcionario user)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select * from Funcionario where EMAIL_FUNCIONARIO = @EMAIL_FUNCIONARIO " +
                "and SENHA_FUNCIONARIO = @SENHA_FUNCIONARIO", con.MyConectarBD());

            cmd.Parameters.Add("@EMAIL_FUNCIONARIO", MySqlDbType.VarChar).Value = user.EMAIL_FUNCIONARIO;
            cmd.Parameters.Add("@SENHA_FUNCIONARIO", MySqlDbType.VarChar).Value = user.SENHA_FUNCIONARIO;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.EMAIL_FUNCIONARIO = Convert.ToString(leitor["EMAIL_FUNCIONARIO"]);
                    user.SENHA_FUNCIONARIO = Convert.ToString(leitor["SENHA_FUNCIONARIO"]);
                    user.NV_ACESSO = int.Parse(leitor["NV_ACESSO"].ToString());
                }
            }

            else
            {
                user.EMAIL_FUNCIONARIO = null;
                user.SENHA_FUNCIONARIO = null;
            }

            con.MyDesConectarBD();
        }
    }
}