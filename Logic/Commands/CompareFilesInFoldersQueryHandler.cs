using ComparerBasic.Domain;
using ComparerBasic.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace ComparerBasic.Logic.Commands;

public record CompareFilesInFoldersQuery(
    List<string> FolderNames
) : IRequest<List<GroupOfEquals>>;

public class CompareFilesInFoldersQueryHandler : IRequestHandler<CompareFilesInFoldersQuery, List<GroupOfEquals>>
{
    // public CompareFilesInFoldersQueryHandler()
    // {
    // }
    
    public async Task<List<GroupOfEquals>> Handle(CompareFilesInFoldersQuery request, CancellationToken cancellationToken)
    {
        var filesGroups = new List<GroupOfEquals>();
        if (request.FolderNames.Count == 0)
        {
            return new List<GroupOfEquals>();;
        }

        var filesInfos = request.FolderNames
            .Where(folderName => !string.IsNullOrEmpty(folderName))
            .SelectMany(folderName => Directory.EnumerateFiles(
                path: folderName,
                searchPattern: "*",
                searchOption: SearchOption.AllDirectories))
            .Select(filename => new SingleFileInfo
            {
                FileName = filename,
                FileStatus = FileStatuses.Active,
                GroupId = null,
                Id = Guid.NewGuid()
            }).ToList();
        filesInfos.ForEach(fileInfo => fileInfo.SetHash());
        var groups = filesInfos.GroupBy(fileInfo => fileInfo.HashSum);
        filesGroups.AddRange(groups
            .Where(group => group.Key != null)
            .Select(group =>
                new GroupOfEquals()
                {
                    Id = Guid.NewGuid(),
                    HashSum = group.Key,
                    FileInfos = group.ToList()
                }));
        filesGroups.ForEach(group => 
            group.FileInfos?.ForEach(file => file.GroupId = group.Id));
        return await Task.FromResult(filesGroups);
    } 
}

