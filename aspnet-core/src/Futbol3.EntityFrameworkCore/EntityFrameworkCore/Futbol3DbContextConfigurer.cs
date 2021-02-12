using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Futbol3.EntityFrameworkCore
{
    public static class Futbol3DbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Futbol3DbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Futbol3DbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
