using System;
using System.Security.Cryptography;

namespace ComparerBasic.Domain;

/// <summary>
/// SingleFileInfo
/// </summary>
public class SingleFileInfo
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// FileName
    /// </summary>
    public string FileName { get; init; } = string.Empty;

    /// <summary>
    /// Hash sum
    /// </summary>
    public string? HashSum { get; set; }

    /// <summary>
    /// File status
    /// </summary>
    public FileStatuses FileStatus { get; set; }

    /// <summary>
    /// GroupId
    /// </summary>
    public Guid? GroupId { get; set; }
    
    /// <summary>
    /// Calculate hash (SHA256) for a given file
    /// </summary>
    /// <param name="file">FileInfo</param>
    /// <returns></returns>
    public bool SetHash()
    {
        var file = new FileInfo(FileName);
        var sha256Hash = SHA256.Create();
        HashSum = BitConverter.ToString(sha256Hash.ComputeHash(file.OpenRead()));
        return true;
    }
}

public enum FileStatuses
{
    Active,
    Missing,
    Deleted
}
