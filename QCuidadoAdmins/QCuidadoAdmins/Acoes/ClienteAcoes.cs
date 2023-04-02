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
    public class ClienteAcoes
    {
        public  List<Cliente> Consultar()
        {
            Conexao con = new Conexao();
            var listaCliente = new List<Cliente>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraCliente", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach(DataRow dr in tabela.Rows)
            {
                listaCliente.Add(
                    new Cliente
                    {
                        CLIENTE_ID = int.Parse(dr["CLIENTE_ID"].ToString()),
                        NOME_CLIENTE = dr["NOME_CLIENTE"].ToString(),
                        EMAIL_CLIENTE = dr["EMAIL_CLIENTE"].ToString(),
                        SENHA_CLIENTE = dr["SENHA_CLIENTE"].ToString(),
                        DATA_NASCIMENTO = DateTime.Parse(dr["DATA_NASCIMENTO"].ToString()),
                        SEXO = dr["SEXO"].ToString(),
                        CELULAR_CLIENTE = dr["CELULAR_CLIENTE"].ToString(),
                        CELULAR_FAMILIA = dr["CELULAR_FAMILIA"].ToString(),
                        CPF = dr["CPF"].ToString(),
                        LOGRADOURO = dr["LOGRADOURO"].ToString(),
                        CEP = dr["CEP"].ToString(),
                        NUMERO_LOGRADOURO = dr["NUMERO_LOGRADOURO"].ToString(),
                        BAIRRO = dr["BAIRRO"].ToString(),
                        CIDADE = dr["CIDADE"].ToString(),
                        ESTADO = dr["ESTADO"].ToString(),
                        INFOS_ADICIONAIS = dr["INFOS_ADICIONAIS"].ToString(),
                        DS_STATUS = dr["DS_STATUS"].ToString()
                    });
            }
            return listaCliente;
        }
    }
}