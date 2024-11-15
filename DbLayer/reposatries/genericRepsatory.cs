using BLLayer.interFaces;
using DAL.Contexts;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer.reposatries
{
    public class genericRepsatory<T> : IGenericReposatory<T> where T : class
    {
        private readonly MVC_Dbcontext _dbcontext;

        public genericRepsatory(MVC_Dbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        //public int Add(T item)
        public void Add(T item)
        {
            _dbcontext.Add(item);
            //return _dbcontext.SaveChanges();

        }

        //public int Delete(T item)
        public void Delete(T item)
        {
            _dbcontext.Remove(item);
            //return _dbcontext.SaveChanges();

        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>)_dbcontext.Employees.Include(E => E.department).ToList();
            }
            return _dbcontext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dbcontext.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            _dbcontext.Update(item);
            //return _dbcontext.SaveChanges();
        }
    }
}
