using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee
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
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
