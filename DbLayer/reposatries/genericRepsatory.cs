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
        public async Task AddAsync(T item)
        {
            await _dbcontext.AddAsync(item);
            //return _dbcontext.SaveChanges();

        }

        //public int Delete(T item)
        public void Delete(T item)
        {
            _dbcontext.Remove(item);
            //return _dbcontext.SaveChanges();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>)await _dbcontext.Employees.Include(E => E.department).ToListAsync();
            }
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbcontext.Set<T>().FindAsync(id);
        }

        public void Update(T item)
        {
            _dbcontext.Update(item);
            //return _dbcontext.SaveChanges();
        }
    }
}
