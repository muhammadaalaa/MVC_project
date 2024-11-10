using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contexts
{
    public class MVC_Dbcontext : DbContext
    {
        public MVC_Dbcontext(DbContextOptions<MVC_Dbcontext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.; Database=MVCDataBase;Trusted_Connection = true ;");
        //}

        public DbSet<Department> Departments { get; set; }
    }
}
