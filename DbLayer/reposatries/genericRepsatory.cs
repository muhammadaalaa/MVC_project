using BLLayer.interFaces;
using DAL.Contexts;
using System;
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
        public int Add(T item)
        {
            _dbcontext.Add(item);
            return _dbcontext.SaveChanges();

        }

        public int Delete(T item)
        {
            _dbcontext.Remove(item);
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbcontext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dbcontext.Set<T>().Find(id);
        }

        public int Update(T item)
        {
            _dbcontext.Update(item);
            return _dbcontext.SaveChanges();
        }
    }
}
