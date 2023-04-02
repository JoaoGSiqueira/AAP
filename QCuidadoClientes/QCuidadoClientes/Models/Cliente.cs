using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QCuidadoClientes.Models
{
    public class Cliente
    {
        public int CLIENTE_ID { get; set; }


        [Required(ErrorMessage = " *")]
        [Display(Name = "Nome")]
        public string NOME_CLIENTE { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "Email")]
        public string EMAIL_CLIENTE { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "Senha")]
        public string SENHA_CLIENTE { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DATA_NASCIMENTO { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "Sexo")]
        public string SEXO { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "Celular do Cliente")]
        public string CELULAR_CLIENTE { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "Celular de Familiar")]
        public string CELULAR_FAMILIA { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "Logradouro")]
        public string LOGRADOURO { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "Número")]
        public string NUMERO_LOGRADOURO { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "Bairro")]
        public string BAIRRO { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "Cidade")]
        public string CIDADE { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "Estado")]
        public string ESTADO { get; set; }

        [Required(ErrorMessage = " *")]
        [Display(Name = "Informações Adicionais(Doenças crônicas, PCD, Limitações...)")]
        public string INFOS_ADICIONAIS { get; set; }

       
        [Display(Name = "Status da Conta")]
        public string DS_STATUS { get; set; }
    }
}