using System.ComponentModel.DataAnnotations;

namespace PBSportStore.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Inform the name")]
        [Display(Name = "User")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
