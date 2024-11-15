using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer.interFaces
{
    public interface IEmployeeReposatory : IGenericReposatory<Employee>
    {
        IQueryable<Employee> GetEmployeesByAdress(string address);
        IQueryable<Employee> GetEmployeesByName(string searchName);

    }
}
