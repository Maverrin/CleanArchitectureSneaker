using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data;

public class SneakerDbContext : IdentityDbContext<ApplicationUser>
{
    public SneakerDbContext(DbContextOptions<SneakerDbContext> options) : base(options){}
    public DbSet<Sneaker> Sneakers => Set<Sneaker>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
