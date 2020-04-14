using NHibernate;
using Petible_api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Petible_api.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private ISessionFactory sessionFactory;
        private ITransaction transaction;

        public ISession Session { get; private set; }

        public NHUnitOfWork(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public async Task Commit()
        {
            try
            {
                await this.transaction.CommitAsync();
            }
            catch
            {
                await this.transaction.RollbackAsync();

                throw;
            }
        }

        public void OpenSession()
        {
            if(this.Session == null || !this.Session.IsConnected)
            {
                this.Session = sessionFactory.OpenSession();
            }
        }

        public void Dispose()
        {
            if(this.transaction != null)
            {
                this.Session.Dispose();
                Session = null;
            }
        }

        public void BeginTransaction()
        {
            if(this.transaction == null || !this.transaction.IsActive)
            {
                this.transaction = this.Session.BeginTransaction(IsolationLevel.ReadCommitted);
            }
        }
    }
}
