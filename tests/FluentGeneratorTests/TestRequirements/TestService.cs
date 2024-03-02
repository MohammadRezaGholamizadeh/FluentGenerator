using FluentGeneratorTests.TestRequirements.EFDataContexts;

namespace FluentGeneratorTests.TestRequirements
{
    public class TestService : ServiceInterface
    {
        private readonly EFDataContext _context;

        public TestService(EFDataContext context)
        {
            _context = context;
        }

        public string GetEFDataContextTestPropertyValue()
        {
            return _context.TestProperty;
        }

        public string SayHello()
        {
            return "Hello World !!!";
        }
    }
}
