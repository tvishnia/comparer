using System.Security.Cryptography;
using ComparerBasic.Domain;
using ComparerBasic.DTOs;
using ComparerBasic.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Logic.Commands
{
    public record GetFolderDataFromDiskCommand(
        string FolderName
        ) : IRequest<FolderLogDto>;

    public class GetFolderDataFromDiskHandler :
        IRequestHandler<GetFolderDataFromDiskCommand, FolderLogDto>
    {
        // private readonly IGuidGenerator _guidGenerator;
        private readonly IComparerContext _dbContext;
        
        public GetFolderDataFromDiskHandler(IComparerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FolderLogDto> Handle(GetFolderDataFromDiskCommand request, CancellationToken cancellationToken)
        {
            var dirs = new Stack<DirectoryInfo>();
            dirs.Push(new DirectoryInfo(request.FolderName));
            var folderLog = new FolderLogDto()
            {
                FolderName = request.FolderName,
                SubFolderNames = new List<string>(),
                FolderStatus = FolderStatuses.ToRead,
                Errors = new List<string>()
            };
            
            //ToDo: check that the folder is not id db in status Processed

            var folderInfos = new List<FolderInfo>();
            var files = new List<FileInfo>();
            var existingFolders =  _dbContext.FolderInfos.Select(f => f.FolderName).ToHashSet();
            while (dirs.Count != 0)
            {
                var dir = dirs.Pop();
                if (!dir.Exists)
                {
                    folderLog.Errors.Add($"{dir.FullName} does not exist.\n");
                    continue;
                }
                if (existingFolders.Contains(dir.FullName))
                {
                    folderLog.Errors.Add($"{dir.FullName} already in db.\n");
                    continue;
                } 
                folderLog.SubFolderNames.Add(dir.FullName);

                folderInfos.Add(new FolderInfo()
                {
                    Id = Guid.NewGuid(),
                    FolderName = dir.FullName,
                    FolderStatus = FolderStatuses.Processed
                });
                 
                files.AddRange(dir.GetFiles());
                foreach (var newDir in dir.GetDirectories())
                {
                    dirs.Push(newDir);
                }
            }
            var existingFiles = _dbContext.SingleFileInfos.Select(f => f.FileName).ToHashSet();
            var fileInfos = files
                .Where(f => f.Exists && !string.IsNullOrEmpty(f.FullName) && !existingFiles.Contains(f.FullName))
                .Select(f => new SingleFileInfo()
                {
                    Id = Guid.NewGuid(),
                    FileName = f.FullName,
                    FileStatus = FileStatuses.ToCount
                });
            
            await _dbContext.SingleFileInfos.AddRangeAsync(fileInfos, cancellationToken);
            await _dbContext.FolderInfos.AddRangeAsync(folderInfos, cancellationToken);
            
            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message, ex);
            }

            return folderLog;
        }
        /// <summary>
        /// Calculate hash (SHA256) for a given file
        /// </summary>
        /// <param name="file">FileInfo</param>
        /// <returns></returns>
        private static string? GetHash(FileInfo file)
        {
            var sha256Hash = SHA256.Create();
            return BitConverter.ToString(sha256Hash.ComputeHash(file.OpenRead()));
        }
    }
}
