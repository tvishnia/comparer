using System.Windows.Input;
using ComparerBasic.Domain;
using ComparerBasic.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Logic.Commands;

public class SetGroupsForFilesCommandHandler 
{
    private readonly IComparerContext _dbContext;
    
    public SetGroupsForFilesCommandHandler(IComparerContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> Handle(CancellationToken cancellationToken)
    {
        var entitiesGroups = await _dbContext.SingleFileInfos
            .GroupBy(x => x.HashSum)
            .Where(x => x.Any(a => a.GroupId == null) || x.DistinctBy(a => a.GroupId).Count() > 1)
            .ToListAsync(cancellationToken);

        if (!entitiesGroups.Any())
        {
            throw new Exception("No info in database");
        }
        
        foreach (var group in entitiesGroups)
        {
            
            var element = group.FirstOrDefault(a => a.GroupId != null);
            var groupId = element?.GroupId ?? Guid.NewGuid();

            foreach (var g in group)
            {
                g.GroupId = groupId;
            }

            _dbContext.SingleFileInfos.UpdateRange(group);
        }

        var count = await _dbContext.SaveChangesAsync(cancellationToken);
        
        return count;
    } 
}

