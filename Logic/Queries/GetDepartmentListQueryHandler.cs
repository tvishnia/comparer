// using ComparerBasic.Domain;
// using ComparerBasic.Infrastructure;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
//
// namespace ComparerBasic.Logic.Queries;
//
// public record GetDepartmentListQuery() : IRequest<IQueryable<ComparedFileInfo>>;
//
// public class GetDepartmentListQueryHandler : IRequestHandler<GetDepartmentListQuery, IQueryable<ComparedFileInfo>>
// {
//     private readonly IComparerContext _dbContext;
//     
//     public GetDepartmentListQueryHandler(IComparerContext dbContext)
//     {
//         _dbContext = dbContext;
//     }
//     
//     public async Task<IQueryable<ComparedFileInfo>> Handle(GetDepartmentListQuery query, CancellationToken cancellationToken)
//     {
//         var list = _dbContext.Departments;
//         
//         return await Task.FromResult(list); 
//     } 
// }
//
