using BLLayer.interFaces;
using DAL.Contexts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer.reposatries
{
    public class employeeReposatory : genericRepsatory<Employee>, IEmployeeReposatory
    {
        private readonly MVC_Dbcontext _dbcontext;
        #region non generic
        //private readonly MVC_Dbcontext _dbcontext;

        //employeeReposatory(MVC_Dbcontext dbcontext)//ask clr to create object
        //{
        //    _dbcontext = dbcontext;
        //}
        //public int Add(Employee employee)
        //{
        //    _dbcontext.Add(employee);
        //    return _dbcontext.SaveChanges();
        //}

        //public int Delete(Employee employee)
        //{
        //    _dbcontext.Remove(employee);
        //    return _dbcontext.SaveChanges();
        //}

        //public IEnumerable<Employee> GetAll()
        //=> _dbcontext.Employees.ToList();

        //public Employee GetById(int id)
        //{
        //    return _dbcontext.Employees.Find(id);
        //}
        //public int Update(Employee employee)
        //{
        //    _dbcontext.Update(employee);
        //    return _dbcontext.SaveChanges();
        //} 
        #endregion

        //inject
        public employeeReposatory(MVC_Dbcontext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IQueryable<Employee> GetEmployeesByAdress(string address)
        {
            return _dbcontext.Employees.Where(E => E.Address == address);
        }

        public IQueryable<Employee> GetEmployeesByName(string searchName)
        {
            return _dbcontext.Employees
             .Where(E => E.Name.ToLower().Contains(searchName.ToLower()))
             .Include(E => E.department);


        }
    }
}
