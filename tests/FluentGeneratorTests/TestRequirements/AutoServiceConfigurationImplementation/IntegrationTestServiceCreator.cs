using FluentGenerator;
using FluentGeneratorTests.TestRequirements.EFDataContexts;

namespace FluentGeneratorTests.TestRequirements.AutoServiceConfigurationImplementation
{
    public class IntegrationTestServiceCreator<T> : AutoServiceCreator<T> where T : class
    {
        public IntegrationTestServiceCreator()
        {
            Sut = CreateService<T>(dataBase: DataBaseType.SqlServerDataBase);
            Context = GetContext<EFDataContext>();
        }
        public IntegrationTestServiceCreator(Dictionary<Type, object> mockedObjects)
        {
            MockedObjects = mockedObjects;
            Sut = CreateService<T>(dataBase: DataBaseType.SqlServerDataBase);
            Context = GetContext<EFDataContext>();
        }

        public T Sut { get; set; }
        public EFDataContext Context { get; set; }
    }
}
