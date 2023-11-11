using System.Threading;
using System.Threading.Tasks;
using ComparerBasic.Domain;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Infrastructure;

public interface IComparerContext
{
    DbSet<ComparedFileInfo> Departments { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}