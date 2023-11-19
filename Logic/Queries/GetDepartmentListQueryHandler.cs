// using ComparerBasic.Domain;
// using ComparerBasic.Infrastructure;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
//
// namespace ComparerBasic.Logic.Queries;
//
// public record GetDepartmentListQuery() : IRequest<IQueryable<SingleFileInfo>>;
//
// public class GetDepartmentListQueryHandler : IRequestHandler<GetDepartmentListQuery, IQueryable<SingleFileInfo>>
// {
//     private readonly IComparerContext _dbContext;
//     
//     public GetDepartmentListQueryHandler(IComparerContext dbContext)
//     {
//         _dbContext = dbContext;
//     }
//     
//     public async Task<IQueryable<SingleFileInfo>> Handle(GetDepartmentListQuery query, CancellationToken cancellationToken)
//     {
//         var list = _dbContext.SingleFileInfos;
//         
//         return await Task.FromResult(list); 
//     } 
// }
//
