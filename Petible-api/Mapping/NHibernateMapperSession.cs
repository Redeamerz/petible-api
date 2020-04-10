using NHibernate;
using Petible_api.Interfaces;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class NHibernateMapperSession : IMapperSession
    {
        private readonly ISession session;
        private ITransaction transaction;

        public IQueryable<UserInfo> userInfo => session.Query<UserInfo>();

        public NHibernateMapperSession(ISession session)
        {
            this.session = session;
        }

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public async Task Commit()
        {
            await transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await transaction.RollbackAsync();
        }
    }
}
