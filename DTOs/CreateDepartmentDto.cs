namespace ComparerBasic.DTOs;

/// <summary>
/// Department
/// </summary>
public class CreateDepartmentDto
{
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// Floor
    /// </summary>
    public int Floor { get; init; }
}
