using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.Services
{
    public interface IService<T> where T:class
    {
        Task<T> GetByIdAsync(int id); //geri dönüş değeri var
        Task<IEnumerable<T>> GetAllAsync(); //tüm datayı çekiyor
        Task<T> AddAsync(T entity);//geri dönüş değeri yok

        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
