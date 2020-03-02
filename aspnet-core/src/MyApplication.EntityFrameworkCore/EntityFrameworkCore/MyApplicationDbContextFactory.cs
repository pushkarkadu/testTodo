using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyApplication.Configuration;
using MyApplication.Web;

namespace MyApplication.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyApplicationDbContextFactory : IDesignTimeDbContextFactory<MyApplicationDbContext>
    {
        public MyApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyApplicationDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyApplicationDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyApplicationConsts.ConnectionStringName));

            return new MyApplicationDbContext(builder.Options);
        }
    }
}
