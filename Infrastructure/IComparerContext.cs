using System.Threading;
using System.Threading.Tasks;
using ComparerBasic.Domain;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Infrastructure;

public interface IComparerContext
{
    DbSet<SingleFileInfo> SingleFileInfos { get; }
    DbSet<GroupsOfEquals> FilesInGroups { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
