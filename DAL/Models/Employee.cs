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
        [Required]

        public string Name { get; set; }
        [Required]

        public string Email { get; set; }

        public string PhoneNum { get; set; }
        public string Address { get; set; }

        public decimal Salary { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        public int? departmentID { get; set; }

        // oprion will lead when you delete this department will throw an error
        // if you make it required will lead to be cascade when you delete it 
        public Department department { get; set; }

    }
}
