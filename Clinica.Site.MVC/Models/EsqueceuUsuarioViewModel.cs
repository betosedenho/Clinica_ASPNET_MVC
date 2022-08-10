using System.ComponentModel.DataAnnotations;

namespace Clinica.Site.MVC.Models
{
    public class EsqueceuUsuarioViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}