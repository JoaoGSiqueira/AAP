using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QCuidadoAdmins.Models
{
    public class Dashboard
    {
        public Decimal Caixa { get; set; }

        [Display(Name = "Funcionários")]
        public int Funcionarios { get; set; }
        public int Clientes { get; set; }
        public int Prestadores { get; set; }
        public int Empresas { get; set; }

        [Display(Name ="Serviços Solicitados")]
        public int Servicos { get; set; }
    }
}