using ComparerBasic.Domain;

namespace ComparerBasic.DTOs;

/// <summary>
/// FolderLog
/// </summary>
public class FolderLogDto
{
    /// <summary>
    /// FolderName
    /// </summary>
    public string FolderName { get; init; } = string.Empty;
    
    /// <summary>
    /// Folder status
    /// </summary>
    public FolderStatuses FolderStatus { get; set; }

    /// <summary>
    /// Subfolders
    /// </summary>
    public List<string> SubFolderNames { get; init; } = null!;
    
    /// <summary>
    /// Errors
    /// </summary>
    public List<string> Errors { get; init; } = null!;

}