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
    public class EmpresaAcoes
    {
        public void Cadastrar(Empresa dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("Call sp_InsEmpresa(@NOME_EMPRESA, @CNPJ, @LOGRADOURO, @CEP," +
                "@NUMERO_LOGRADOURO, @BAIRRO, @CIDADE, @ESTADO, @TELEFONE_EMPRESA);", con.MyConectarBD());

            cmd.Parameters.Add("@NOME_EMPRESA", MySqlDbType.VarChar).Value = dto.NOME_EMPRESA;
            cmd.Parameters.Add("@CNPJ", MySqlDbType.VarChar).Value = dto.CNPJ;
            cmd.Parameters.Add("@LOGRADOURO", MySqlDbType.VarChar).Value = dto.LOGRADOURO;
            cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = dto.CEP;
            cmd.Parameters.Add("@NUMERO_LOGRADOURO", MySqlDbType.VarChar).Value = dto.NUMERO_LOGRADOURO;
            cmd.Parameters.Add("@BAIRRO", MySqlDbType.VarChar).Value = dto.BAIRRO;
            cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = dto.CIDADE;
            cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = dto.ESTADO;
            cmd.Parameters.Add("@TELEFONE_EMPRESA", MySqlDbType.VarChar).Value = dto.TELEFONE_EMPRESA;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<Empresa> Consultar()
        {
            Conexao con = new Conexao();
            var listaEmpresa = new List<Empresa>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraEmpresa", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach(DataRow dr in tabela.Rows)
            {
                listaEmpresa.Add(
                    new Empresa
                    {
                        EMPRESA_ID = int.Parse(dr["EMPRESA_ID"].ToString()),
                        NOME_EMPRESA = dr["NOME_EMPRESA"].ToString(),
                        CNPJ = dr["CNPJ"].ToString(),
                        LOGRADOURO = dr["LOGRADOURO"].ToString(),
                        CEP = dr["CEP"].ToString(),
                        NUMERO_LOGRADOURO = dr["NUMERO_LOGRADOURO"].ToString(),
                        BAIRRO = dr["BAIRRO"].ToString(),
                        CIDADE = dr["CIDADE"].ToString(),
                        ESTADO = dr["ESTADO"].ToString(),
                        TELEFONE_EMPRESA = dr["TELEFONE_EMPRESA"].ToString()
                    });
            }
            return listaEmpresa;
        }

        public void Excluir(int id)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("call sp_ExcEmpresa(@EEMPRESA_ID)", con.MyConectarBD());
            
            cmd.Parameters.Add("@EEMPRESA_ID", MySqlDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void Alterar(Empresa dto)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("call sp_AltEmpresa(@ALTEMPRESA_ID, @NOME_EMPRESA, @CNPJ, @LOGRADOURO, @CEP, @NUMERO_LOGRADOURO," +
                "@BAIRRO, @CIDADE, @ESTADO, @TELEFONE_EMPRESA);", con.MyConectarBD());

            cmd.Parameters.Add("@ALTEMPRESA_ID", MySqlDbType.Int32).Value = dto.EMPRESA_ID;
            cmd.Parameters.Add("@NOME_EMPRESA", MySqlDbType.VarChar).Value = dto.NOME_EMPRESA;
            cmd.Parameters.Add("@CNPJ", MySqlDbType.VarChar).Value = dto.CNPJ;
            cmd.Parameters.Add("@LOGRADOURO", MySqlDbType.VarChar).Value = dto.LOGRADOURO;
            cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = dto.CEP;
            cmd.Parameters.Add("@NUMERO_LOGRADOURO", MySqlDbType.VarChar).Value = dto.NUMERO_LOGRADOURO;
            cmd.Parameters.Add("@BAIRRO", MySqlDbType.VarChar).Value = dto.BAIRRO;
            cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = dto.CIDADE;
            cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = dto.ESTADO;
            cmd.Parameters.Add("@TELEFONE_EMPRESA", MySqlDbType.VarChar).Value = dto.TELEFONE_EMPRESA;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

    }
}