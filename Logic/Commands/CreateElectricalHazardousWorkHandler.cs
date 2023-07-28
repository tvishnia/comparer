using ComparerBasic.Domain;
using ComparerBasic.Infrastructure;
using MediatR;

namespace ComparerBasic.Logic.Commands
{
    public record CreateDepartmentCommand(
        string Name ,
        int Floor 
        ) : IRequest<Department>;

    public class CreateDepartmentHandler :
        IRequestHandler<CreateDepartmentCommand, Department>
    {
        // private readonly IGuidGenerator _guidGenerator;
        private readonly IComparerContext _dbContext;
        
        public CreateDepartmentHandler(IComparerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = new Department()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Floor = request.Floor
            };
            
            await _dbContext.Departments.AddAsync(department, cancellationToken);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message, ex);
            }

            return department;
        }
    }
}
