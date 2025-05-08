using System;

namespace ComparerBasic.Domain;

/// <summary>
/// A group or files with the same hashsum
/// </summary>
public class GroupOfEquals
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Files
    /// </summary>
    public List<SingleFileInfo>? FileInfos { get; init; }
    
    /// <summary>
    /// Hash sum
    /// </summary>
    public string? HashSum { get; init; }
}
