using NHibernate.Linq;
using Petible_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Models
{
    public abstract class Repository<T, TEntityKey>
    {
        private IUnitOfWork uow;

        public Repository(IUnitOfWork uow)
        {
            this.uow = uow;
            uow.OpenSession();
            uow.BeginTransaction();
        }
        public async Task Remove(T entity) => await uow.Session.DeleteAsync(entity);
        public async Task Save(T entity) => await uow.Session.SaveOrUpdateAsync(entity);
        public async Task<T> FindById(TEntityKey id) => await uow.Session.GetAsync<T>(id);
        public async Task<List<T>> ListAll() => await uow.Session.Query<T>().ToListAsync();
    }
}
