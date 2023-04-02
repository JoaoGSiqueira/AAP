using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QCuidadoAdmins.Models
{
    public class Empresa
    {
        public int EMPRESA_ID { get; set; }

        [Display(Name = "Nome da Empresa")]
        [Required(ErrorMessage ="*")]
        [MaxLength(100, ErrorMessage = "O nome deve conter no máximo 100 caracteres")]
        public string NOME_EMPRESA { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "*")]
        [MaxLength(18, ErrorMessage = "O nome deve conter no máximo 100 caracteres")]
        public string CNPJ { get; set; }

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

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "*")]
        public string TELEFONE_EMPRESA { get; set; }

    }
}









      