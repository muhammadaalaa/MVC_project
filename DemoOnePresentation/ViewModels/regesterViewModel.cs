using System.ComponentModel.DataAnnotations;

namespace DemoOnePresentation.ViewModels
{
    public class regesterViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "last Name is required")]

        public string Lastname { get; set; }
        [Required(ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }
        [Required(ErrorMessage = "confirm password is required")]
        [Compare("password", ErrorMessage = "passwords should be the same")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }
        public bool IsAgreed { get; set; }
    }
}
