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
    public class AgendaservicoAcoes
    {
        public void Cadastrar(Agendaservico dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("Call sp_InsAgendaservico(@TIPO_SERVICO, @DESC_SERVICO, @LOCAL_INICIO, @LOCAL_DESTINO, " +
                "@VALOR_SERVICO, @DATA_SERVICO, @HORARIO, @HORARIO_TERMINO, @CLIENTE_ID, @PAGAMENTO_ID);", con.MyConectarBD());

            cmd.Parameters.Add("@TIPO_SERVICO", MySqlDbType.VarChar).Value = dto.TIPO_SERVICO;
            cmd.Parameters.Add("@DESC_SERVICO", MySqlDbType.VarChar).Value = dto.DESC_SERVICO;
            cmd.Parameters.Add("@LOCAL_INICIO", MySqlDbType.VarChar).Value = dto.LOCAL_INICIO;
            cmd.Parameters.Add("@LOCAL_DESTINO", MySqlDbType.VarChar).Value = dto.LOCAL_DESTINO;
            cmd.Parameters.Add("@VALOR_SERVICO", MySqlDbType.Decimal).Value = dto.VALOR_SERVICO;
            cmd.Parameters.Add("@DATA_SERVICO", MySqlDbType.Date).Value = dto.DATA_SERVICO.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@HORARIO", MySqlDbType.VarChar).Value = dto.HORARIO;
            cmd.Parameters.Add("@HORARIO_TERMINO", MySqlDbType.VarChar).Value = dto.HORARIO_TERMINO;
            cmd.Parameters.Add("@CLIENTE_ID", MySqlDbType.Int32).Value = dto.CLIENTE_ID;
            cmd.Parameters.Add("@PAGAMENTO_ID", MySqlDbType.Int32).Value = dto.PAGAMENTO_ID;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<Agendaservico>Consultar(int id)
        {
            Conexao con = new Conexao();
            var listaAgenda = new List<Agendaservico>();
            MySqlCommand cmd = new MySqlCommand("sp_MostraAgendaservico(@CodCli);", con.MyConectarBD());
            cmd.Parameters.Add("@CodCli", MySqlDbType.Int32).Value = id;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach(DataRow dr in tabela.Rows)
            {
                listaAgenda.Add(
                    new Agendaservico
                    {
                        AGENDASERVICO_ID = int.Parse(dr["AGENDASERVICO_ID"].ToString()),
                        TIPO_SERVICO = Convert.ToString(dr["TIPO_SERVICO"]),
                        DESC_SERVICO = Convert.ToString(dr["DESC_SERVICO"]),
                        LOCAL_INICIO = Convert.ToString(dr["LOCAL_INICIO"]),
                        LOCAL_DESTINO = Convert.ToString(dr["LOCAL_DESTINO"]),
                        VALOR_SERVICO = double.Parse(dr["VALOR_SERVICO"].ToString()),
                        DATA_SERVICO = Convert.ToDateTime(dr["DATA_SERVICO"]),
                        HORARIO = Convert.ToString(dr["HORARIO"]),
                        HORARIO_TERMINO = Convert.ToString(dr["HORARIO_TERMINO"]),
                        STATUSSERVICO = Convert.ToString(dr["STATUSSERVICO"]),
                        NOME_PRESTADOR = Convert.ToString(dr["NOME_PRESTADOR"]),
                        NOME_EMPRESA = Convert.ToString(dr["NOME_EMPRESA"]),

                    });
            }
            return listaAgenda;
        }
    }
}