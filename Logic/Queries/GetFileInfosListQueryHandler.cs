using ComparerBasic.Domain;
using ComparerBasic.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Logic.Queries;

public record GetFileInfosListQuery(
    int PageNum,
    int PageSize
) : IRequest<IQueryable<SingleFileInfo>>;
public class GetFileInfosListQueryHandler : IRequestHandler<GetFileInfosListQuery, IQueryable<SingleFileInfo>>
{
    private readonly IComparerContext _dbContext;
    
    public GetFileInfosListQueryHandler(IComparerContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IQueryable<SingleFileInfo>> Handle(GetFileInfosListQuery query, CancellationToken cancellationToken)
    {
        var list = _dbContext.SingleFileInfos.Skip(query.PageNum * query.PageSize).Take(query.PageSize);
        
        return await Task.FromResult(list); 
    } 
}

