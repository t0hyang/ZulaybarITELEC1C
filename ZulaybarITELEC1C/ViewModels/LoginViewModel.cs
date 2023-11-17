using System.ComponentModel.DataAnnotations;

namespace ZulaybarITELEC1C.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "a username is required")]
        public string? UserName;

        [Display(Name = "Password")]
        [Required(ErrorMessage = "a password is required")]
        public string? Password;

        [Display(Name = "Remember me?")]
        public bool RememberMe;

    }
}
