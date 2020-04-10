using FluentNHibernate.Mapping;
using FluentNHibernate.MappingModel.ClassBased;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Petible_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_api.Mapping
{
    public class UserInfoMap : ClassMapping<UserInfo>
    {
        public UserInfoMap()
        {
            Id(x => x.idUserInfo, x =>
            {
                x.Generator(Generators.Guid);
                x.Type(NHibernateUtil.Guid);
                x.Column("idUserInfo");
                x.UnsavedValue(Guid.Empty);
            });

            Property(x => x.idUser, x =>
            {
                x.Type(NHibernateUtil.Guid);
                x.NotNullable(true);
            });

            Property(x => x.city, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(x => x.dateOfBirth, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(x => x.children, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });

            Property(x => x.gender, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });

            Property(x => x.nickname, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(x => x.description, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(x => x.timeFreePerDayInMinutes, x =>
            {
                x.Type(NHibernateUtil.Int16);
                x.NotNullable(true);
            });

            Property(x => x.otherPets, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });

            Table("UserInfo");

        }

    }
}
