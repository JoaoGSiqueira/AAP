using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QCuidadoAdmins.Models
{
    public class Cliente
    {
        public int CLIENTE_ID { get; set; }

        [Display(Name = "Nome")]
        public string NOME_CLIENTE { get; set; }

        [Display(Name = "Email")]
        public string EMAIL_CLIENTE { get; set; }

        [Display(Name = "Senha")]
        public string SENHA_CLIENTE { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DATA_NASCIMENTO { get; set; }

        [Display(Name ="Sexo")]
        public string SEXO { get; set; }

        [Display(Name ="Celular do Cliente")]
        public string CELULAR_CLIENTE { get; set; }

        [Display(Name ="Celular de Familiar")]
        public string CELULAR_FAMILIA { get; set; }

        [Display(Name ="CPF")]
        public string CPF { get; set; }

        [Display(Name = "Logradouro")]
        public string LOGRADOURO { get; set; }

        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Display(Name = "Número")]
        public string NUMERO_LOGRADOURO { get; set; }

        [Display(Name = "Bairro")]
        public string BAIRRO { get; set; }

        [Display(Name = "Cidade")]
        public string CIDADE { get; set; }

        [Display(Name = "Estado")]
        public string ESTADO { get; set; }

        [Display(Name = "Informações Adicionais" )]
        public string INFOS_ADICIONAIS { get; set; }

        [Display(Name ="Status da Conta")]
        public string DS_STATUS { get; set; }
    }
}