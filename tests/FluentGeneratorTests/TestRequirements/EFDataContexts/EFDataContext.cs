using Microsoft.EntityFrameworkCore;

namespace FluentGeneratorTests.TestRequirements.EFDataContexts
{
    public class EFDataContext : DbContext
    {
        public string TestProperty { get; set; }
        public EFDataContext(
            DbContextOptions<EFDataContext> options) : base(options)
        {
        }

        public EFDataContext(
            string connectionString) : this(
            new DbContextOptionsBuilder<EFDataContext>()
            .UseSqlServer(connectionString).Options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
