// using ComparerBasic.Domain;
// using ComparerBasic.Infrastructure;
// using MediatR;
//
// namespace ComparerBasic.Logic.Commands
// {
//     public record CreateDepartmentCommand(
//         string Name ,
//         int Floor 
//         ) : IRequest<SingleFileInfo>;
//
//     public class CreateDepartmentHandler :
//         IRequestHandler<CreateDepartmentCommand, SingleFileInfo>
//     {
//         // private readonly IGuidGenerator _guidGenerator;
//         private readonly IComparerContext _dbContext;
//         
//         public CreateDepartmentHandler(IComparerContext dbContext)
//         {
//             _dbContext = dbContext;
//         }
//
//         public async Task<SingleFileInfo> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
//         {
//             var department = new SingleFileInfo()
//             {
//                 Id = Guid.NewGuid(),
//                 Name = request.Name,
//                 Floor = request.Floor
//             };
//             
//             await _dbContext.SingleFileInfos.AddAsync(department, cancellationToken);
//
//             try
//             {
//                 await _dbContext.SaveChangesAsync(cancellationToken);
//             }
//             catch (Exception ex)
//             {
//                 throw new Exception(ex.InnerException?.Message, ex);
//             }
//
//             return department;
//         }
//     }
// }
