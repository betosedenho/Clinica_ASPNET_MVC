using System.ComponentModel.DataAnnotations;

namespace Clinica.Site.MVC.Models
{
    public class EsqueceuSenhaViewModel
    {
        [Required]
        [Display(Name = "Nome do Usuário")]
        public string NomeUsuario { get; set; }
    }
}