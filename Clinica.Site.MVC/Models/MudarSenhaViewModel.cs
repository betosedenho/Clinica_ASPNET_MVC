using System.ComponentModel.DataAnnotations;

namespace Clinica.Site.MVC.Models
{
    public class MudarSenhaViewModel
    {
        [Required]        
        [Display(Name = "Nome do Usuário")]
        public string NomeUsuario { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O/A {0} deve ter no mínimo {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Senha", ErrorMessage = "A senha e a senha de confirmação não coincidem.")]
        public string ConfirmaSenha { get; set; }        
    }
}