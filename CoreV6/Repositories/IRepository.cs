using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<T>
    {

        T Get();
        IEnumerable<T> GetAll(int offset, int limit);
        IEnumerable<T> FindByName(string name);
        Task<T?> FindById(int id);

        Task<T> Add(T item);

        Task<T> Update(T item);

        Task Delete(int id);


    }
}
