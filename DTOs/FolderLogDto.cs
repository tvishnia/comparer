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
    /// File status
    /// </summary>
    public FolderStatuses FolderStatus { get; set; }

    /// <summary>
    /// Floor
    /// </summary>
    public List<string> SubFolderName { get; init; } = null!;
}