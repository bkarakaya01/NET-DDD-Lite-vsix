using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Aggregates.Product;

namespace $rootnamespace$.Persistence;

public sealed class YourAppDbContext : DbContext, $safeprojectname$.Abstractions.IUnitOfWork
{
    public DbSet<Product> Products => Set<Product>();

    public YourAppDbContext(DbContextOptions<YourAppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(YourAppDbContext).Assembly);
}
