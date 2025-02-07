using System;

namespace ComparerBasic.Domain;

/// <summary>
/// FileInGroup
/// </summary>
public class FileInGroup
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// FileId
    /// </summary>
    public Guid? FileId { get; init; }

    /// <summary>
    /// GroupId
    /// </summary>
    public Guid GroupId { get; init; }
}
