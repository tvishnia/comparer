namespace ComparerBasic.DTOs;

/// <summary>
/// SingleFileInfo
/// </summary>
public class CreateDepartmentDto
{
    /// <summary>
    /// FileName
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Floor
    /// </summary>
    public int Floor { get; init; }
}
