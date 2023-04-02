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
    public class FuncionarioAcoes
    {
        public void Cadastrar(Funcionario dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_InsFuncionario(@NOME_FUNCIONARIO, @EMAIL_FUNCIONARIO," +
                "@SENHA_FUNCIONARIO, @DATA_NASCIMENTO, @SEXO, @CELULAR_FUNCIONARIO, @CPF, @LOGRADOURO, @CEP," +
                "@NUMERO_LOGRADOURO, @BAIRRO, @CIDADE, @ESTADO, @NV_ACESSO);", con.MyConectarBD());

            cmd.Parameters.Add("@NOME_FUNCIONARIO", MySqlDbType.VarChar).Value = dto.NOME_FUNCIONARIO;
            cmd.Parameters.Add("@EMAIL_FUNCIONARIO", MySqlDbType.VarChar).Value = dto.EMAIL_FUNCIONARIO;
            cmd.Parameters.Add("@SENHA_FUNCIONARIO", MySqlDbType.VarChar).Value = dto.SENHA_FUNCIONARIO;
            cmd.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Date).Value = dto.DATA_NASCIMENTO.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@SEXO", MySqlDbType.VarChar).Value = dto.SEXO;
            cmd.Parameters.Add("@CELULAR_FUNCIONARIO", MySqlDbType.VarChar).Value = dto.CELULAR_FUNCIONARIO;
            cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = dto.CPF;
            cmd.Parameters.Add("@LOGRADOURO", MySqlDbType.VarChar).Value = dto.LOGRADOURO;
            cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = dto.CEP;
            cmd.Parameters.Add("@NUMERO_LOGRADOURO", MySqlDbType.VarChar).Value = dto.NUMERO_LOGRADOURO;
            cmd.Parameters.Add("@BAIRRO", MySqlDbType.VarChar).Value = dto.BAIRRO;
            cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = dto.CIDADE;
            cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = dto.ESTADO;
            cmd.Parameters.Add("@NV_ACESSO", MySqlDbType.VarChar).Value = dto.NV_ACESSO;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        } 

        public List<Funcionario> Consultar()
        {
            Conexao con = new Conexao();
            var listaFuncionario = new List<Funcionario>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraFuncionario", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);
            
            foreach(DataRow dr in tabela.Rows)
            {
                listaFuncionario.Add(
                    new Funcionario
                    {
                        FUNCIONARIO_ID = int.Parse(dr["FUNCIONARIO_ID"].ToString()),
                        NOME_FUNCIONARIO = dr["NOME_FUNCIONARIO"].ToString(),
                        EMAIL_FUNCIONARIO = dr["EMAIL_FUNCIONARIO"].ToString(),
                        SENHA_FUNCIONARIO = dr["SENHA_FUNCIONARIO"].ToString(),
                        DATA_NASCIMENTO = DateTime.Parse(dr["DATA_NASCIMENTO"].ToString()),
                        SEXO = dr["SEXO"].ToString(),
                        CELULAR_FUNCIONARIO = dr["CELULAR_FUNCIONARIO"].ToString(),
                        CPF = dr["CPF"].ToString(),
                        LOGRADOURO = dr["LOGRADOURO"].ToString(),
                        CEP = dr["CEP"].ToString(),
                        NUMERO_LOGRADOURO = dr["NUMERO_LOGRADOURO"].ToString(),
                        BAIRRO = dr["BAIRRO"].ToString(),
                        CIDADE = dr["CIDADE"].ToString(),
                        ESTADO = dr["ESTADO"].ToString(),
                        NV_ACESSO = int.Parse(dr["NV_ACESSO"].ToString())
                    });
                
            }
            return listaFuncionario;
        }

        public void Excluir(int id)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_ExcFuncionario(@EFUNCIONARIO_ID)", con.MyConectarBD());

            cmd.Parameters.Add("@EFUNCIONARIO_ID", MySqlDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void Alterar(Funcionario dto)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("call sp_AltFuncionario(@ALT_FUNCIONARIO_ID, @NOME_FUNCIONARIO, @EMAIL_FUNCIONARIO, @SENHA_FUNCIONARIO," +
                "@DATA_NASCIMENTO, @SEXO, @CELULAR_FUNCIONARIO, @CPF, @LOGRADOURO, @CEP, @NUMERO_LOGRADOURO, @BAIRRO, @CIDADE, @ESTADO, @NV_ACESSO);", con.MyConectarBD());

            cmd.Parameters.Add("@ALT_FUNCIONARIO_ID", MySqlDbType.Int32).Value = dto.FUNCIONARIO_ID;
            cmd.Parameters.Add("@NOME_FUNCIONARIO", MySqlDbType.VarChar).Value = dto.NOME_FUNCIONARIO;
            cmd.Parameters.Add("@EMAIL_FUNCIONARIO", MySqlDbType.VarChar).Value = dto.EMAIL_FUNCIONARIO;
            cmd.Parameters.Add("@SENHA_FUNCIONARIO", MySqlDbType.VarChar).Value = dto.SENHA_FUNCIONARIO;
            cmd.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Date).Value = dto.DATA_NASCIMENTO.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@SEXO", MySqlDbType.VarChar).Value = dto.SEXO;
            cmd.Parameters.Add("@CELULAR_FUNCIONARIO", MySqlDbType.VarChar).Value = dto.CELULAR_FUNCIONARIO;
            cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = dto.CPF;
            cmd.Parameters.Add("@LOGRADOURO", MySqlDbType.VarChar).Value = dto.LOGRADOURO;
            cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = dto.CEP;
            cmd.Parameters.Add("@NUMERO_LOGRADOURO", MySqlDbType.VarChar).Value = dto.NUMERO_LOGRADOURO;
            cmd.Parameters.Add("@BAIRRO", MySqlDbType.VarChar).Value = dto.BAIRRO;
            cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = dto.CIDADE;
            cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = dto.ESTADO;
            cmd.Parameters.Add("@NV_ACESSO", MySqlDbType.VarChar).Value = dto.NV_ACESSO;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}