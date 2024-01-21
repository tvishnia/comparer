using System;

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
    public string? HashSum { get; init; }

    /// <summary>
    /// File status
    /// </summary>
    public FileStatuses FileStatus { get; set; }
}

public enum FileStatuses
{
    Active,
    Missing,
    Deleted,
    DontExist,
    ToCount
}