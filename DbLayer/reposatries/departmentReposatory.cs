using BLLayer.interFaces;
using DAL.Contexts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer.reposatries
{
    public class departmentReposatory : IDepartmentReposatory
    {
        private MVC_Dbcontext _dbContext;

        public departmentReposatory(MVC_Dbcontext dbContext)
        {
            //dbcontet = new MVC_Dbcontext();
            // if we do this will
            // supposed to create object when you want to make any crud operation but ever time you want to create crud operation that
            // will lead to two req for connection but if yu passs it as a parameter that will be dependancy 
            //that parameter is a refernce when we pass it as a parameter will point to an object 
            //=======================================after that================================ 
            _dbContext = dbContext;
        }
        public int Add(Department department)
        {
            _dbContext.Add(department);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department department)
        {

            _dbContext.Remove(department);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Departments.ToList();
        }
        public Department GetById(int id)
        {
            // var department = _dbContext.Departments.Local.Where(d => d.Id == id).FirstOrDefault();
            // if (department == null)
            // department = _dbContext.Departments.Local.Where(d => d.Id == id).FirstOrDefault();
            // return department;
            // istead of that the ward find do this search first at local then if it didn't find it will send request at data basae
            return _dbContext.Departments.Find(id);
        }

        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }
    }
}
