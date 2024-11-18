using System.ComponentModel.DataAnnotations;

namespace DemoOnePresentation.ViewModels
{
    public class loginViewMode
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }
        public bool remmberMe { get; set; }
    }
}
