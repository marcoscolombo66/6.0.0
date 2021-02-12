using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Futbol3.Authorization.Roles;
using Futbol3.Authorization.Users;
using Futbol3.MultiTenancy;
using Futbol3.Equipos;

namespace Futbol3.EntityFrameworkCore
{
    public class Futbol3DbContext : AbpZeroDbContext<Tenant, Role, User, Futbol3DbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Equipo> Equipos { get; set; }
        public Futbol3DbContext(DbContextOptions<Futbol3DbContext> options)
            : base(options)
        {
        }
    }
}
