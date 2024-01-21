using System;

namespace ComparerBasic.Domain;

/// <summary>
/// FolderInfo
/// </summary>
public class FolderInfo
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// FileName
    /// </summary>
    public string FolderName { get; init; } = string.Empty;
    
    /// <summary>
    /// Folder status
    /// </summary>
    public FolderStatuses FolderStatus { get; set; }
}

public enum FolderStatuses
{
    Missing,
    ToRead,
    Processed
}