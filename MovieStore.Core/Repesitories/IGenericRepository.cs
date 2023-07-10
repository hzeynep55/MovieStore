using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Repesitories
{
    public interface IGenericRepository<T> where T:class
    {
        Task<T> GetByIdAsync(int id); //geri dönüş değeri var
        IQueryable<T> GetAll();
        Task AddAsync(T entity);//geri dönüş değeri yok

        void Remove(T entity);
        void Update(T entity);
    }
}
