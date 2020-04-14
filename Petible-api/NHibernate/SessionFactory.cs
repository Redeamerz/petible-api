using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MySqlX.XDevAPI;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Petible_api.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.NHibernate
{
    public class SessionFactory
    {
        public static ISessionFactory Init(string connectionString)
        {
            object __sync = new object();

            lock (__sync)
                return Fluently.Configure()
                    .Database(MySQLConfiguration.Standard
                    .ConnectionString(connectionString))
                    .Mappings(m => m.FluentMappings.Add<UserInfoMap>())
                    .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                    .BuildSessionFactory();
        }
    }
}
