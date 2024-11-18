using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLayer.interFaces
{
    public interface IGenericReposatory<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        #region generic
        //int Add(T item);
        //int Update(T item);
        //int Delete(T item); 
        #endregion
        #region unitOfWork
        Task AddAsync(T item);
        void Update(T item);
        void Delete(T item);
        #endregion
    }
}
