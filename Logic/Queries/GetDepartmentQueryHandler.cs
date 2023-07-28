using ComparerBasic.Domain;
using ComparerBasic.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Logic.Queries;

public class GetDepartmentQuery : IRequest<Department>
{
    public Guid Id { get; init; }
}

public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, Department>
{
    private readonly IComparerContext _dbContext;
    
    public GetDepartmentQueryHandler(IComparerContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Department> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Departments.FirstOrDefaultAsync(department => department.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new Exception($"Department not found {request.Id}");
        }
            
        return entity; 
    } 
}

