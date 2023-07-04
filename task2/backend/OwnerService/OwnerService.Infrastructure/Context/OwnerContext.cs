using Microsoft.EntityFrameworkCore;
using OwnerService.Domain;


namespace OwnerService.Infrastructure.Context
{
    public sealed class OwnerContext : DbContext
    {
        /// <summary>
        ///     Пользователи
        /// </summary>
        public DbSet<Owner> Owners => Set<Owner>();

        public OwnerContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
    }
}
