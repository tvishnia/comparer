using ComparerBasic.Domain;
using ComparerBasic.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Logic.Queries;

public record GetFileInfosListQuery(
    int PageNum = 1,
    int PageSize = 100
) : IRequest<IReadOnlyCollection<SingleFileInfo>>;
public class GetFileInfosListQueryHandler : IRequestHandler<GetFileInfosListQuery, IReadOnlyCollection<SingleFileInfo>>
{
    private readonly IComparerContext _dbContext;
    
    public GetFileInfosListQueryHandler(IComparerContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IReadOnlyCollection<SingleFileInfo>> Handle(GetFileInfosListQuery query, CancellationToken cancellationToken)
    {
        var list = await _dbContext.SingleFileInfos
            .OrderBy(x => x.FileName)
            .Skip((query.PageNum - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync(cancellationToken);
        
        return list; 
    } 
}

