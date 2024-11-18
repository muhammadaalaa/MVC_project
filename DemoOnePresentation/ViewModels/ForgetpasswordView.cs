using System.ComponentModel.DataAnnotations;

namespace DemoOnePresentation.ViewModels
{
    public class ForgetpasswordView
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "invalidEmailAddress")]
        public string Email { get; set; }
    }
}
