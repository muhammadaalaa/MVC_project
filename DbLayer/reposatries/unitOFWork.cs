using BLLayer.interFaces;
using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer.reposatries
{
    public class unitOFWork : IUnitOFWork , IDisposable
    {
        private readonly MVC_Dbcontext _dbContext;

    public IEmployeeReposatory EmployeeReposatory { get; set; }
    public IDepartmentReposatory DepartmentReposatory { get; set; }

    public unitOFWork(MVC_Dbcontext dbContext)
    {
        EmployeeReposatory = new employeeReposatory(dbContext);
        DepartmentReposatory = new departmentReposatory(dbContext);
        _dbContext = dbContext;
    }

    public int compelete()

           => _dbContext.SaveChanges();


    public void Dispose()
    => _dbContext.Dispose();


}
}
