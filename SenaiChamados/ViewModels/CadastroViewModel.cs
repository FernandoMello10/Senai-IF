using System.ComponentModel.DataAnnotations;

namespace SenaiChamados.ViewModels
{
    public class CadastroViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int SetorID { get; set; }
        [Required]
        public string Telefone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
