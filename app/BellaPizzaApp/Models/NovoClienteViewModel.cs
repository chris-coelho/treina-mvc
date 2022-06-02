using System.ComponentModel.DataAnnotations;

namespace BellaPizzaApp.Models
{
    public class NovoClienteViewModel
    {
        [Range(1, 9999, ErrorMessage = "Código inválido. Digite de 1 a 9999")]
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [Display(Name = "Nome do cliente")]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

    }
}
