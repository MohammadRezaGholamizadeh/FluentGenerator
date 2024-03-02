using FluentAssertions;
using FluentGenerator;
using FluentGeneratorTests.TestRequirements;
using FluentGeneratorTests.TestRequirements.AutoServiceConfigurationImplementation;
using FluentGeneratorTests.TestRequirements.EFDataContexts;
using Moq;
using Xunit;

namespace FluentGeneratorTests
{
    public class AutoServiceConfigurationTests :
                 AutoServiceCreator<ServiceInterface>
    {
        [Fact]
        public void Get_get_connectionSring_properly()
        {
            var expected = GetConnectionString();
            expected.Should()
                .Be("server=.;database=Test;Trusted_connection = True;");
        }

        [Fact]
        public void CreateService_properly()
        {
            var service = CreateService<ServiceInterface>(DataBaseType.SqlServerDataBase);
            var serviceMethodOupPut = service.SayHello();

            service.Should().NotBeNull();
            serviceMethodOupPut.Should().NotBeNull();
            serviceMethodOupPut.Should().Be("Hello World !!!");
        }

        [Fact]
        public void Get_get_dbContext_properly()
        {
            CreateService<ServiceInterface>(DataBaseType.SqlLiteDataBase);

            var expected = GetContext<EFDataContext>();

            expected.Should().NotBeNull();
            expected.Should().BeOfType<EFDataContext>();
            expected.ContextId.Should().NotBeNull();
            expected.Database.EnsureCreated().Should().BeTrue();
        }

        [Fact]
        public void CreateService_withMockedObject_properly()
        {
            var mockedEFDataContext = new Mock<EFDataContext>(GetConnectionString());
            mockedEFDataContext.Object.TestProperty = "Hello World !!!";
            MockedObjects.AddMockedParameter(
                            typeof(EFDataContext),
                            mockedEFDataContext.Object);
            var service =
                CreateService<ServiceInterface>(
                    DataBaseType.SqlLiteDataBase);

            var serviceMethodOupPut =
                service.GetEFDataContextTestPropertyValue();

            service.Should().NotBeNull();
            serviceMethodOupPut.Should().NotBeNull();
            serviceMethodOupPut.Should().Be("Hello World !!!");
        }
    }
}