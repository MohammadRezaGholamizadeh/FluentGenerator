using Autofac;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Transactions;

namespace FluentGenerator
{
    /* Developer : MohammadReza Gholamizadeh [Phoenix]*/
    public abstract class AutoServiceConfiguration : IDisposable
    {
        #region [Fields]
        private ContainerBuilder _serviceContainer;
        private SqliteConnection _connection;
        private TransactionScope _transactionScope;
        #endregion

        #region [Properties]
        private string? DbConnectionString { get; set; }
        public virtual Dictionary<Type, object> MockedObjects { get; set; }
        private DbContext Context { get; set; }
        #endregion

        /// <summary>
        /// This Methode Take Your Service Configuration That You Implemented and Use Them To Configure Your Service Instance
        /// </summary>
        /// <param name="container">ServiceContainer That Register Your Service With Your Implemented Configuration</param>
        /// <param name="mockedServiceParameters">Take your Mocked Constructor Parameters That You Want To Make Service Instances With Them</param>
        /// <param name="context"> Your DbContext That Your Services Contain</param>
        public abstract void ServicesConfiguration(
            ContainerBuilder container,
            Dictionary<Type, object> mockedServiceParameters,
            DbContext context);
        /// <summary>
        /// This Method Take Your Configuration To Register In Memory Data Base With Useing SqlLite
        /// You Must Use InMemoryDataBase class To Implement Your Configuration
        /// This Method Needs Your DbContext Constructor Parameters To Register SqlLite DbContext With InMemoryDataBase Class                   
        ///    
        /// </summary>
        /// <param name="sqliteConnection">SqlLite Connection Options</param>
        /// <returns>DbContext With SqlLite</returns>
        public abstract DbContext SqlLiteConfiguration(
                                  SqliteConnection sqliteConnection);
        /// <summary>
        /// This Method Take Your Configuration To Register DataBase With Useing SqlServer                 
        /// You Must Return Your Created DbContext Instance With Ypur Configuration
        /// </summary>
        /// <returns>DbContext With SqlServer</returns>
        public abstract DbContext SqlServerConfiguration();

        /// <summary>
        /// You Can Take Your Created DataBase Instance That Used In Your Services
        /// </summary>
        /// <typeparam name="T">Specific DbContext Type</typeparam>
        /// <returns>DbContext As Specific Type</returns>
        public T GetContext<T>() where T : DbContext
        {
            return Context as T;
        }
        protected AutoServiceConfiguration()
        {
            _serviceContainer = new ContainerBuilder();
            MockedObjects = new Dictionary<Type, object>();
            _connection = new SqliteConnection("filename=:memory:");
            _connection.Open();
        }

        /// <summary>
        /// This Method Create Your Servies By Your Configurations
        /// </summary>
        /// <typeparam name="T">Specific Service Type That You Want To Created Instance With</typeparam>
        /// <param name="dataBase">DataBase Type That You Want To Use For Services</param>
        /// <returns> T as Specific Service That Created</returns>
        public T? CreateService<T>(
                 DataBaseType dataBase = DataBaseType.SqlLiteDataBase)
                 where T : class
        {
            if (dataBase == DataBaseType.SqlLiteDataBase)
            {
                Context = SqlLiteConfiguration(_connection);
            }
            else
            {
                Dispose();
                _transactionScope =
                   new TransactionScope(
                       TransactionScopeOption.Required,
                       TransactionScopeAsyncFlowOption.Enabled);
                Context = SqlServerConfiguration();
            }
            ServicesConfiguration(_serviceContainer, MockedObjects, Context);
            return _serviceContainer.Build()
                                    .BeginLifetimeScope()
                                    .ResolveOptional<T>();
        }

        /// <summary>
        /// This Method Return Your Connection String That Defined In Specific Json File  
        /// </summary>
        /// <param name="jsonFileName"></param>
        /// <param name="connectionStringName"></param>
        /// <returns>Connection String</returns>
        public string? GetConnectionString(
            string jsonFileName = "dataBaseSettings.json",
            string connectionStringName = "DbConnectionString")
        {
            var settings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                    jsonFileName,
                    optional: true,
                    reloadOnChange: false)
                .AddEnvironmentVariables()
                .AddCommandLine(Environment.GetCommandLineArgs())
                .Build();

            DbConnectionString =
                settings.GetSection(connectionStringName).Get<string>();
            return DbConnectionString;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _connection?.Dispose();
                _transactionScope?.Dispose();
                Context?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public enum DataBaseType
    {
        SqlLiteDataBase,
        SqlServerDataBase
    }
}
