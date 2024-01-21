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
    /// Floor
    /// </summary>
    public List<string> SubFolderName { get; init; } = null!;
}
public enum FolderStatuses
{
    Ok,
    Missing,
}