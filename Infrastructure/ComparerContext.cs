using ComparerBasic.Domain;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Infrastructure;

public class ComparerContext : 
    DbContext, 
    IComparerContext
{
    public DbSet<SingleFileInfo> SingleFileInfos => Set<SingleFileInfo>();
    public DbSet<FolderInfo> FolderInfos => Set<FolderInfo>();
    
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