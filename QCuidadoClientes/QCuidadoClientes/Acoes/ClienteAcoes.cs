using MySql.Data.MySqlClient;
using QCuidadoClientes.Data;
using QCuidadoClientes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QCuidadoClientes.Acoes
{
    public class ClienteAcoes
    {
        public void Cadastrar(Cliente dto)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("call sp_InsCliente(@NOME_CLIENTE, @EMAIL_CLIENTE, @SENHA_CLIENTE, @DATA_NASCIMENTO, @SEXO," +
                "@CELULAR_CLIENTE, @CELULAR_FAMILIA, @CPF, @LOGRADOURO, @CEP, @NUMERO_LOGRADOURO, @BAIRRO, @CIDADE, @ESTADO, @INFOS_ADICIONAIS);", con.MyConectarBD());

            cmd.Parameters.Add("@NOME_CLIENTE", MySqlDbType.VarChar).Value = dto.NOME_CLIENTE;
            cmd.Parameters.Add("@EMAIL_CLIENTE", MySqlDbType.VarChar).Value = dto.EMAIL_CLIENTE;
            cmd.Parameters.Add("@SENHA_CLIENTE", MySqlDbType.VarChar).Value = dto.SENHA_CLIENTE;
            cmd.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Date).Value = dto.DATA_NASCIMENTO.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@SEXO", MySqlDbType.VarChar).Value = dto.SEXO;
            cmd.Parameters.Add("@CELULAR_CLIENTE", MySqlDbType.VarChar).Value = dto.CELULAR_CLIENTE;
            cmd.Parameters.Add("@CELULAR_FAMILIA", MySqlDbType.VarChar).Value = dto.CELULAR_FAMILIA;
            cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = dto.CPF;
            cmd.Parameters.Add("@LOGRADOURO", MySqlDbType.VarChar).Value = dto.LOGRADOURO;
            cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = dto.CEP;
            cmd.Parameters.Add("@NUMERO_LOGRADOURO", MySqlDbType.VarChar).Value = dto.NUMERO_LOGRADOURO;
            cmd.Parameters.Add("@BAIRRO", MySqlDbType.VarChar).Value = dto.BAIRRO;
            cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = dto.CIDADE;
            cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = dto.ESTADO;
            cmd.Parameters.Add("@INFOS_ADICIONAIS", MySqlDbType.VarChar).Value = dto.INFOS_ADICIONAIS;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<Cliente> Consultar()
        {
            Conexao con = new Conexao();
            var listaCliente = new List<Cliente>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraCliente", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach (DataRow dr in tabela.Rows)
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


        public List<Cliente> ConsultaPerfil(int id)
        {
            Conexao con = new Conexao();

            var listaCliente = new List<Cliente>();
            MySqlCommand cmd = new MySqlCommand("Call sp_ConsultaPerfil(@CodCli)", con.MyConectarBD());
            cmd.Parameters.Add("@CodCli", MySqlDbType.Int32).Value = id;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach(DataRow dr in tabela.Rows)
            {
                listaCliente.Add(
                    new Cliente
                    {
                        CLIENTE_ID= int.Parse(dr["CLIENTE_ID"].ToString()),
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
                    }) ;
            }
            return listaCliente;
        }

        public void Alterar(Cliente dto)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("call sp_AltCliente(@ALT_CLIENTE_ID, @NOME_CLIENTE, @EMAIL_CLIENTE, @SENHA_CLIENTE," +
                "@DATA_NASCIMENTO, @SEXO, @CELULAR_CLIENTE, @CELULAR_FAMILIA, @CPF, @LOGRADOURO, @CEP, @NUMERO_LOGRADOURO, @BAIRRO, @CIDADE, @ESTADO, @INFOS_ADICIONAIS);", con.MyConectarBD());

            cmd.Parameters.Add("@ALT_CLIENTE_ID", MySqlDbType.Int32).Value = dto.CLIENTE_ID;
            cmd.Parameters.Add("@NOME_CLIENTE", MySqlDbType.VarChar).Value = dto.NOME_CLIENTE;
            cmd.Parameters.Add("@EMAIL_CLIENTE", MySqlDbType.VarChar).Value = dto.EMAIL_CLIENTE;
            cmd.Parameters.Add("@SENHA_CLIENTE", MySqlDbType.VarChar).Value = dto.SENHA_CLIENTE;
            cmd.Parameters.Add("@DATA_NASCIMENTO", MySqlDbType.Date).Value = dto.DATA_NASCIMENTO.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@SEXO", MySqlDbType.VarChar).Value = dto.SEXO;
            cmd.Parameters.Add("@CELULAR_CLIENTE", MySqlDbType.VarChar).Value = dto.CELULAR_CLIENTE;
            cmd.Parameters.Add("@CELULAR_FAMILIA", MySqlDbType.VarChar).Value = dto.CELULAR_FAMILIA;
            cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = dto.CPF;
            cmd.Parameters.Add("@LOGRADOURO", MySqlDbType.VarChar).Value = dto.LOGRADOURO;
            cmd.Parameters.Add("@CEP", MySqlDbType.VarChar).Value = dto.CEP;
            cmd.Parameters.Add("@NUMERO_LOGRADOURO", MySqlDbType.VarChar).Value = dto.NUMERO_LOGRADOURO;
            cmd.Parameters.Add("@BAIRRO", MySqlDbType.VarChar).Value = dto.BAIRRO;
            cmd.Parameters.Add("@CIDADE", MySqlDbType.VarChar).Value = dto.CIDADE;
            cmd.Parameters.Add("@ESTADO", MySqlDbType.VarChar).Value = dto.ESTADO;
            cmd.Parameters.Add("@INFOS_ADICIONAIS", MySqlDbType.VarChar).Value = dto.INFOS_ADICIONAIS;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void DesativarConta(int id)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("call sp_DesativarConta(@CodUsuario);", con.MyConectarBD());

            cmd.Parameters.Add("@CodUsuario", MySqlDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void AtivarConta(int id)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("call sp_AtivarConta(@CodUsuario);", con.MyConectarBD());

            cmd.Parameters.Add("@CodUsuario", MySqlDbType.Int32).Value = id;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}