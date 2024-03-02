using Autofac;
using FluentGenerator;
using FluentGeneratorTests.TestRequirements.EFDataContexts;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace FluentGeneratorTests.TestRequirements.AutoServiceConfigurationImplementation
{
    public class AutoServiceCreator<T> : AutoServiceConfiguration
        where T : class
    {
        public override void ServicesConfiguration(
            ContainerBuilder container,
            Dictionary<Type, object> mockedServiceParameters,
            DbContext context)
        {
            container.RegisterType<TestService>()
                .As<ServiceInterface>()
                .WithConstructorParameters(mockedServiceParameters)
                .WithDbContext(context as EFDataContext)
                .SingleInstance();
        }

        public override DbContext SqlLiteConfiguration(SqliteConnection sqliteConnection)
        {
            return new InMemoryDataBase()
                       .CreateInMemoryDataContext<EFDataContext>(
                        sqliteConnection, null);
        }

        public override DbContext SqlServerConfiguration()
        {
            return new EFDataContext(GetConnectionString());
        }
    }
}
