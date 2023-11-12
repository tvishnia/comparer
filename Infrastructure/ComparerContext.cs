using ComparerBasic.Domain;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Infrastructure;

public class ComparerContext : 
    DbContext, 
    IComparerContext

{
    public DbSet<ComparedFileInfo> Departments => Set<ComparedFileInfo>();
    
    public ComparerContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}