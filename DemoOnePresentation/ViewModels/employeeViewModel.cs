using DAL.Models;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace DemoOnePresentation.ViewModels
{
    public class employeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "name is required")]
        [MaxLength(50, ErrorMessage = "max Length must be from 5 to 50")]
        [MinLength(5, ErrorMessage = "min Length must be from 5 to 50")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNum { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
        public int? departmentID { get; set; }

        // oprion will lead when you delete this department will throw an error
        // if you make it required will lead to be cascade when you delete it 
        public Department department { get; set; }

    }
}
