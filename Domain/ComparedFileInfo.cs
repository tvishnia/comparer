using System;

namespace ComparerBasic.Domain;

/// <summary>
/// ComparedFileInfo
/// </summary>
public class ComparedFileInfo
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Name
    /// </summary>
    public string FileName { get; init; } = string.Empty;

    /// <summary>
    /// Floor
    /// </summary>
    public int Floor { get; init; }
}