using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "name is required ")]
        [MaxLength(50)]
        public string name { get; set; }
        [Required(ErrorMessage = "name is required ")]
        public int code { get; set; }
        public DateTime dateOFCreation { get; set; }


        public ICollection<Employee> employees = new HashSet<Employee>();

    }
}
