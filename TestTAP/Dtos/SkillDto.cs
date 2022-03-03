namespace TestTAP.Dtos;

using System.ComponentModel.DataAnnotations;

/// <summary>
///     DTO скиллов сотрудника.
/// </summary>
public class SkillDto
{
    /// <summary>
    ///     Индентификатор скилла.
    /// </summary>
    public long? Id { get; set; }

    /// <summary>
    ///     Уровень владения сотрудника скиллом.
    /// </summary>
    [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public byte Level { get; set; }

    /// <summary>
    ///     Название скилла.
    /// </summary>
    [MaxLength(256)]
    public string Name { get; set; }

    /// <summary>
    ///     Внешний ключ для связи с сотрудником.
    /// </summary>
    public long? PersonId { get; set; }
}