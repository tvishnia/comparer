using ComparerBasic.Domain;
using ComparerBasic.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Logic.Queries;

public record GetDepartmentListQuery() : IRequest<IQueryable<Department>>;

public class GetDepartmentListQueryHandler : IRequestHandler<GetDepartmentListQuery, IQueryable<Department>>
{
    private readonly IComparerContext _dbContext;
    
    public GetDepartmentListQueryHandler(IComparerContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IQueryable<Department>> Handle(GetDepartmentListQuery query, CancellationToken cancellationToken)
    {
        var list = _dbContext.Departments;
        
        return await Task.FromResult(list); 
    } 
}

