using System.ComponentModel.DataAnnotations;

namespace DemoOnePresentation.ViewModels
{
    public class RessetPasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "password is required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "confirm password is required")]
        [Compare("NewPassword", ErrorMessage = "passwords should be the same")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
    }
}
