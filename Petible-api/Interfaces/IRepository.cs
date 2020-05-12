using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Interfaces
{
    public interface IRepository<T,TId>
    {
        Task Save(T entity);
        Task Remove(T entity);
        Task<T> FindBy(TId id);
        Task<List<T>> ListAll();
    }
}
