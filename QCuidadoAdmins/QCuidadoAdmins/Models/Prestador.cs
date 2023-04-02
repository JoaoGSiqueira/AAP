using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QCuidadoAdmins.Models
{
    public class Prestador
    {
        public int PRESTADOR_ID { get; set; }

        
        [Display(Name = "Nome do Prestador")]
        [Required(ErrorMessage ="*")]
        [MaxLength(100, ErrorMessage = "O nome deve conter no máximo 100 caracteres")]
        public string NOME_PRESTADOR { get; set; }

        [Display(Name = "E-mail do Prestador")]
        [Required(ErrorMessage ="*")]
        [MaxLength(50, ErrorMessage = "O Email deve conter no máximo 50 caracteres")]
        public string EMAIL_PRESTADOR { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "*")]
        public DateTime DATA_NASCIMENTO { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "*")]
        public string SEXO { get; set; }

        [Display(Name = "Celular do Prestador")]
        [Required(ErrorMessage = "*")]
        public string CELULAR_PRESTADOR { get; set; }


        [Display(Name = "CPF")]
        [Required(ErrorMessage = "*")]
        [MinLength(14, ErrorMessage = "O CPF deve conter no mínimo 14 caracteres")]
        [MaxLength(14, ErrorMessage = "O CPF deve conter no máximo 14 caracteres")]
        public string CPF { get; set; }


        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "*")]
        public string LOGRADOURO { get; set; }


        [Display(Name = "CEP")]
        [Required(ErrorMessage = "*")]
        [MinLength(8, ErrorMessage = "O CEP deve conter no mínimo 8 caracteres")]
        [MaxLength(8, ErrorMessage = "O CEP deve conter no máximo 8 caracteres")]
        public string CEP { get; set; }


        [Display(Name = "Número")]
        [Required(ErrorMessage = "*")]
        [RegularExpression("([1-9][0-9]*)")]
        public string NUMERO_LOGRADOURO { get; set; }


        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "*")]
        public string BAIRRO { get; set; }


        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "*")]
        public string CIDADE { get; set; }


        [Display(Name = "Estado")]
        [Required(ErrorMessage = "*")]
        public string ESTADO { get; set; }

        [Display(Name = "Selecione a Empresa")]
        [Required(ErrorMessage = "*")]
        public int EMPRESA_ID { get; set; }

        [Display(Name = "Empresa")]
        public string NOME_EMPRESA { get; set; }

        
    }
}