using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Futbol3.Configuration;
using Futbol3.Web;

namespace Futbol3.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class Futbol3DbContextFactory : IDesignTimeDbContextFactory<Futbol3DbContext>
    {
        public Futbol3DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Futbol3DbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            Futbol3DbContextConfigurer.Configure(builder, configuration.GetConnectionString(Futbol3Consts.ConnectionStringName));

            return new Futbol3DbContext(builder.Options);
        }
    }
}
