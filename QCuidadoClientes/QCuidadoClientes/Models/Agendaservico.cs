using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QCuidadoClientes.Models
{
    public class Agendaservico
    {
        public int AGENDASERVICO_ID { get; set; }

        [Display(Name = "Tipo de Serviço")]
        [Required(ErrorMessage = "*")]
        public string TIPO_SERVICO { get; set; }

        [Display(Name = "Descrição das tarefas")]
        [Required(ErrorMessage = "*")]
        public string DESC_SERVICO { get; set; }

        [Display(Name = "Local")]
        [Required(ErrorMessage = "*")]
        public string LOCAL_INICIO { get; set; }

        [Display(Name = "Local de Destino(se for necessário)")]
        public string LOCAL_DESTINO { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "*")]
        public double VALOR_SERVICO { get; set; }

        [Display(Name = "Data para o serviço")]
        [Required(ErrorMessage = "*")]
        public DateTime DATA_SERVICO { get; set; }

        [Display(Name = "Horário de inicio")]
        [Required(ErrorMessage = "*")]
        public string HORARIO { get; set; }

        [Display(Name = "Horário de término")]
        [Required(ErrorMessage = "*")]
        public string HORARIO_TERMINO { get; set; }

        public int CLIENTE_ID { get; set; }

        [Display(Name = "Tipo de pagamento")]
        public int PAGAMENTO_ID { get; set; }

        [Display(Name = "Prestador")]
        public string NOME_PRESTADOR { get; set; }

        [Display(Name = "Empresa")]
        public string NOME_EMPRESA { get; set; }

        [Display(Name = "Status")]
        public string STATUSSERVICO { get; set; }
    }
}