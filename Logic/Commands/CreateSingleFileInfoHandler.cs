using System.Security.Cryptography;
using ComparerBasic.Domain;
using ComparerBasic.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ComparerBasic.Logic.Commands
{
    public record CreateSingleFileInfoCommand(
        string FileName
        ) : IRequest<SingleFileInfo>;

    public class CreateSingleFileInfoHandler :
        IRequestHandler<CreateSingleFileInfoCommand, SingleFileInfo>
    {
        // private readonly IGuidGenerator _guidGenerator;
        private readonly IComparerContext _dbContext;
        
        public CreateSingleFileInfoHandler(IComparerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SingleFileInfo> Handle(CreateSingleFileInfoCommand request, CancellationToken cancellationToken)
        {
            if (String.IsNullOrEmpty(request.FileName))
            {
                Console.WriteLine("File name should not be empty.");
                return null;
            }

            var fileName = request.FileName.TrimStart();
            // add check in db if file already exists
            var exists = await _dbContext.SingleFileInfos
                .FirstOrDefaultAsync(fileInfo => fileInfo.FileName.Equals(fileName), cancellationToken);
            if (exists != null)
            {
                Console.WriteLine("File name already in database: " + fileName);
                return null;
            }

            var file= new FileInfo(request.FileName);
            if (!file.Exists)
            {
                Console.WriteLine("File does not exist: " + file.FullName);
                return null;
            }

            var fileHash = GetHash(file);
            var singleFileInfo = new SingleFileInfo()
            {
                Id = Guid.NewGuid(),
                FileName = request.FileName,
                HashSum = fileHash, // change here
                FileStatus = FileStatuses.Active
            };
            
            await _dbContext.SingleFileInfos.AddAsync(singleFileInfo, cancellationToken);

            try
            {
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message, ex);
            }

            return singleFileInfo;
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
