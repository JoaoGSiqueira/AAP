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
    public class ServicoAcoes
    {
        public List<Servicos>Consultar()
        {
            Conexao con = new Conexao();
            var listaServico = new List<Servicos>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraAgenda", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach(DataRow dr in tabela.Rows)
            {
                listaServico.Add(
                    new Servicos
                    {
                        AGENDASERVICO_ID = int.Parse(dr["AGENDASERVICO_ID"].ToString()),
                        TIPO_SERVICO = dr["TIPO_SERVICO"].ToString(),
                        DESC_SERVICO = dr["DESC_SERVICO"].ToString(),
                        LOCAL_INICIO = dr["LOCAL_INICIO"].ToString(),
                        LOCAL_DESTINO = dr["LOCAL_DESTINO"].ToString(),
                        VALOR_SERVICO = double.Parse(dr["VALOR_SERVICO"].ToString()),
                        DATA_SERVICO = DateTime.Parse(dr["DATA_SERVICO"].ToString()),
                        HORARIO = dr["HORARIO"].ToString(),
                        HORARIO_TERMINO = dr["HORARIO_TERMINO"].ToString(),
                        STATUSSERVICO = dr["STATUSSERVICO"].ToString(),
                        CLIENTE_ID = int.Parse(dr["CLIENTE_ID"].ToString()),
                        
                        PAGAMENTO_ID = int.Parse(dr["PAGAMENTO_ID"].ToString()),
       
                    });
            }
            return listaServico;

                
        }

        public List<Servicos> ConsultarConfirmado()
        {
            Conexao con = new Conexao();
            var listaServico = new List<Servicos>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraAgendaConfirmado", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach (DataRow dr in tabela.Rows)
            {
                listaServico.Add(
                    new Servicos
                    {
                        AGENDASERVICO_ID = int.Parse(dr["AGENDASERVICO_ID"].ToString()),
                        TIPO_SERVICO = dr["TIPO_SERVICO"].ToString(),
                        DESC_SERVICO = dr["DESC_SERVICO"].ToString(),
                        LOCAL_INICIO = dr["LOCAL_INICIO"].ToString(),
                        LOCAL_DESTINO = dr["LOCAL_DESTINO"].ToString(),
                        VALOR_SERVICO = double.Parse(dr["VALOR_SERVICO"].ToString()),
                        DATA_SERVICO = DateTime.Parse(dr["DATA_SERVICO"].ToString()),
                        HORARIO = dr["HORARIO"].ToString(),
                        HORARIO_TERMINO = dr["HORARIO_TERMINO"].ToString(),
                        STATUSSERVICO = dr["STATUSSERVICO"].ToString(),
                        CLIENTE_ID = int.Parse(dr["CLIENTE_ID"].ToString()),

                        PAGAMENTO_ID = int.Parse(dr["PAGAMENTO_ID"].ToString()),

                    });
            }
            return listaServico;


        }

        public void Alterar(Servicos dto)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("call sp_AltServicoAdmin(@ALTAGENDASERVICO_ID, @STATUSSERVICO, @PRESTADOR_ID);", con.MyConectarBD());

            cmd.Parameters.Add("@ALTAGENDASERVICO_ID", MySqlDbType.Int32).Value = dto.AGENDASERVICO_ID;
            cmd.Parameters.Add("@STATUSSERVICO", MySqlDbType.VarChar).Value = dto.STATUSSERVICO;
            cmd.Parameters.Add("@PRESTADOR_ID", MySqlDbType.Int32).Value = dto.PRESTADOR_ID;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}