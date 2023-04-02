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
    public class PrestadorAcoes
    {
        public void Cadastrar(Prestador dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("Call sp_InsPrestador(@NOME_PRESTADOR, @EMAIL_PRESTADOR, @DATA_NASCIMENTO, " +
                "@SEXO, @CELULAR_PRESTADOR, @CPF, @LOGRADOURO, @CEP, @NUMERO_LOGRADOURO, @BAIRRO, @CIDADE, @ESTADO, @EMPRESA_ID);", con.MyConectarBD());

            cmd.Parameters.Add("@NOME_PRESTADOR", MySqlDbType.VarChar).Value = dto.NOME_PRESTADOR;
            cmd.Parameters.Add("@EMAIL_PRESTADOR", MySqlDbType.VarChar).Value = dto.EMAIL_PRESTADOR;
            cmd.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Date).Value = dto.DATA_NASCIMENTO.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@SEXO", MySqlDbType.VarChar).Value = dto.SEXO;
            cmd.Parameters.Add("@CELULAR_PRESTADOR", MySqlDbType.VarChar).Value = dto.CELULAR_PRESTADOR;
            cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = dto.CPF;
            cmd.Parameters.Add("@LOGRADOURO", MySqlDbType.VarChar).Value = dto.LOGRADOURO;
            cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = dto.CEP;
            cmd.Parameters.Add("@NUMERO_LOGRADOURO", MySqlDbType.VarChar).Value = dto.NUMERO_LOGRADOURO;
            cmd.Parameters.Add("@BAIRRO", MySqlDbType.VarChar).Value = dto.BAIRRO;
            cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = dto.CIDADE;
            cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = dto.ESTADO;
            cmd.Parameters.Add("@EMPRESA_ID", MySqlDbType.Int32).Value = dto.EMPRESA_ID;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<Prestador> Consultar()
        {
            Conexao con = new Conexao();
            var listaEmpresa = new List<Prestador>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraPrestador", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach(DataRow dr in tabela.Rows)
            {
                listaEmpresa.Add(
                    new Prestador
                    {
                        PRESTADOR_ID = int.Parse(dr["PRESTADOR_iD"].ToString()),
                        NOME_PRESTADOR = Convert.ToString(dr["NOME_PRESTADOR"]),
                        EMAIL_PRESTADOR = Convert.ToString(dr["EMAIL_PRESTADOR"]),
                        DATA_NASCIMENTO = DateTime.Parse(dr["DATA_NASCIMENTO"].ToString()),
                        SEXO = Convert.ToString(dr["SEXO"]),
                        CELULAR_PRESTADOR = Convert.ToString(dr["CELULAR_PRESTADOR"]),
                        CPF = Convert.ToString(dr["CPF"]),
                        LOGRADOURO = Convert.ToString(dr["LOGRADOURO"]),
                        CEP = Convert.ToString(dr["CEP"]),
                        NUMERO_LOGRADOURO = Convert.ToString(dr["NUMERO_LOGRADOURO"]),
                        BAIRRO = Convert.ToString(dr["BAIRRO"]),
                        CIDADE = Convert.ToString(dr["CIDADE"]),
                        ESTADO = Convert.ToString(dr["ESTADO"]),
                        EMPRESA_ID = int.Parse(dr["EMPRESA_ID"].ToString()),
                        NOME_EMPRESA = Convert.ToString(dr["NOME_EMPRESA"])
                    });
            }
            return listaEmpresa;
        }

        public void Excluir(int id)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("call sp_ExcPrestador(@EPRESTADOR_ID)", con.MyConectarBD());

            cmd.Parameters.Add("@EPRESTADOR_ID", MySqlDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void Alterar(Prestador dto)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("call sp_AltPrestador(@ALTPRESTADOR_ID, @NOME_PRESTADOR, @EMAIL_PRESTADOR, @DATA_NASCIMENTO, " +
                "@SEXO, @CELULAR_PRESTADOR, @CPF, @LOGRADOURO, @CEP, @NUMERO_LOGRADOURO, @BAIRRO, @CIDADE, @ESTADO, @EMPRESA_ID);", con.MyConectarBD());

            cmd.Parameters.Add("@ALTPRESTADOR_ID", MySqlDbType.Int32).Value = dto.PRESTADOR_ID;
            cmd.Parameters.Add("@NOME_PRESTADOR", MySqlDbType.VarChar).Value = dto.NOME_PRESTADOR;
            cmd.Parameters.Add("@EMAIL_PRESTADOR", MySqlDbType.VarChar).Value = dto.EMAIL_PRESTADOR;
            cmd.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Date).Value = dto.DATA_NASCIMENTO.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@SEXO", MySqlDbType.VarChar).Value = dto.SEXO;
            cmd.Parameters.Add("@CELULAR_PRESTADOR", MySqlDbType.VarChar).Value = dto.CELULAR_PRESTADOR;
            cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = dto.CPF;
            cmd.Parameters.Add("@LOGRADOURO", MySqlDbType.VarChar).Value = dto.LOGRADOURO;
            cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = dto.CEP;
            cmd.Parameters.Add("@NUMERO_LOGRADOURO", MySqlDbType.VarChar).Value = dto.NUMERO_LOGRADOURO;
            cmd.Parameters.Add("@BAIRRO", MySqlDbType.VarChar).Value = dto.BAIRRO;
            cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = dto.CIDADE;
            cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = dto.ESTADO;
            cmd.Parameters.Add("@EMPRESA_ID", MySqlDbType.Int32).Value = dto.EMPRESA_ID;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
  

    }
}