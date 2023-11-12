using ComparerBasic.Domain;
using ComparerBasic.Infrastructure;
using Files.Comparator;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Logic.Queries;

public record CompareTwoFilesQuery(
    string FileName1,
    string FileName2
) : IRequest<bool>;

public class CompareTwoFilesQueryHandler : IRequestHandler<CompareTwoFilesQuery, bool>
{
    public CompareTwoFilesQueryHandler()
    {
    }
    
    public async Task<bool> Handle(CompareTwoFilesQuery request, CancellationToken cancellationToken)
    {
        var file1 = new FileInfo(request.FileName1);
        var file2 = new FileInfo(request.FileName2);
        var fileComparer = new FileComparer();
        return await Task.FromResult(fileComparer.Equals(file1, file2));
    } 
}

