using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JLC.CursoMvc.Application.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid EderecoId { get; set; }

        [Required(ErrorMessage ="Preencha o campo Logradouro")]
        [MaxLength(100,ErrorMessage ="Máximo {0} caracteres")]
        [MinLength(2,ErrorMessage ="Mínimo {0} caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage ="Preencha o campo Numero")]
        [MaxLength(100,ErrorMessage ="Máximo {0} caracteres")]
        [MinLength(2,ErrorMessage ="Mínimo {0} caracteres")]
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo CEP")]
        [MaxLength(8, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo {0} caracteres")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Estado")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Estado { get; set; }
    }
}
