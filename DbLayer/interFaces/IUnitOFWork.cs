using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer.interFaces
{
    public interface IUnitOFWork
    {
        public IEmployeeReposatory EmployeeReposatory { get; set; }
        public IDepartmentReposatory DepartmentReposatory { get; set; }
        int compelete();
    }
}
