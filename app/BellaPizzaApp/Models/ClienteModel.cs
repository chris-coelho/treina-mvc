using System.ComponentModel.DataAnnotations;

namespace BellaPizzaApp.Models
{
    public class ClienteModel
    {
        [Range(1, 9999, ErrorMessage = "ID inválido. Digite de 1 a 9999")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

    }
}
