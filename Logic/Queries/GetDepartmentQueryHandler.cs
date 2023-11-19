// using ComparerBasic.Domain;
// using ComparerBasic.Infrastructure;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
//
// namespace ComparerBasic.Logic.Queries;
//
// public class GetDepartmentQuery : IRequest<SingleFileInfo>
// {
//     public Guid Id { get; init; }
// }
//
// public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, SingleFileInfo>
// {
//     private readonly IComparerContext _dbContext;
//     
//     public GetDepartmentQueryHandler(IComparerContext dbContext)
//     {
//         _dbContext = dbContext;
//     }
//     
//     public async Task<SingleFileInfo> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
//     {
//         var entity = await _dbContext.SingleFileInfos.FirstOrDefaultAsync(department => department.Id == request.Id, cancellationToken);
//
//         if (entity == null)
//         {
//             throw new Exception($"SingleFileInfo not found {request.Id}");
//         }
//             
//         return entity; 
//     } 
// }
//
