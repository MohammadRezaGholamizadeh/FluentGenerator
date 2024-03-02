using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentGenerator
{
    public class InMemoryDataBase
    {
        /// <summary>
        /// This Method Create Your InMemory DataBase By Using SqlLite Configuration  That You Defined
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="sqliteConnection">SqlLite Connection Options</param>
        /// <param name="dbContextConstructorParameterDetails">Specific Parameters Of DbContext Constructor That You Want To Make Instance With </param>
        /// <param name="entities"></param>
        /// <returns>TDbContext As Your Specific DbContext </returns>
        public TDbContext CreateInMemoryDataContext<TDbContext>(
                SqliteConnection sqliteConnection,
                Dictionary<Type, object> dbContextConstructorParameterDetails,
                params object[] entities)
                where TDbContext : DbContext
        {
            if (dbContextConstructorParameterDetails == null)
            {
                dbContextConstructorParameterDetails =
                    new Dictionary<Type, object>();
            }
            var dbContext =
                ResolveFactory<TDbContext>(
                   sqliteConnection,
                   dbContextConstructorParameterDetails).Invoke();
            dbContext.Database.EnsureCreated();
            if (entities?.Length > 0)
            {
                dbContext.AddRange(entities);
                dbContext.SaveChanges();
            }

            return dbContext;
        }

        /// <summary>
        /// This Method Used For Create SqlLite DbContext With Your Specific Configuration
        /// </summary>
        /// <typeparam name="TDbContext">Specific DbContext Type</typeparam>
        /// <param name="sqliteConnection">Sql Connection Options</param>
        /// <param name="constructorParametersDetail">Specific Parameters Of DbContext Constructor</param>
        /// <returns>Func<TDbContext></returns>
        /// <exception cref="Exception"></exception>
        private Func<TDbContext>
                ResolveFactory<TDbContext>(
                SqliteConnection sqliteConnection,
                Dictionary<Type, object> constructorParametersDetail)
                where TDbContext : DbContext
        {
            var dbContextOptions = new DbContextOptionsBuilder<TDbContext>()
                                    .UseSqlite(sqliteConnection).Options;

            var parametersTypeList =
                constructorParametersDetail
                    .Keys.Prepend(dbContextOptions.GetType()).ToArray();
            var ParameterValueList =
                constructorParametersDetail.Values
                    .Prepend(dbContextOptions).ToArray();

            var constructor =
                FindSuitableConstructor<TDbContext>(parametersTypeList);

            if (constructor == null)
            {
                throw new Exception(
                    $"no constructor found on '{typeof(TDbContext).Name}' " +
                    "with one parameter of type " +
                    $"DbContextOptions" +
                    $"<{typeof(TDbContext).Name}>/DbContextOptions");
            }

            return () =>
                constructor
                .Invoke(ParameterValueList)
                as TDbContext;
        }
        /// <summary>
        /// This Method Find The Suitable Specific DbContext To Use It For Create Instance With SqlLite
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="constructorParameterTypes"></param>
        /// <returns></returns>
        private ConstructorInfo?
                FindSuitableConstructor<TDbContext>(
                Type[]? constructorParameterTypes = null)
                where TDbContext : DbContext
        {
            var flags = BindingFlags.Instance |
                        BindingFlags.Public |
                        BindingFlags.NonPublic |
                        BindingFlags.InvokeMethod;

            var constructor =
                typeof(TDbContext).GetConstructor(
                    flags,
                    binder: null,
                    new[] { typeof(DbContextOptions<TDbContext>) },
                    modifiers: null);

            if (constructor == null)
            {
                constructor =
                     typeof(TDbContext).GetConstructor(
                          flags,
                          null,
                          constructorParameterTypes,
                          null);
            }

            return constructor;
        }
    }
}
