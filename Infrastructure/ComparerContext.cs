using ComparerBasic.Domain;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Infrastructure;

public class ComparerContext : 
    DbContext, 
    IComparerContext
{
    public DbSet<SingleFileInfo> SingleFileInfos => Set<SingleFileInfo>();
    public DbSet<FileInGroup> FilesInGroups => Set<FileInGroup>
    
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
