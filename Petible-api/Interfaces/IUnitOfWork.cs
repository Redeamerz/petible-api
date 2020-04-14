using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
        void OpenSession();
        void BeginTransaction();
        ISession Session { get; }
    }
}
