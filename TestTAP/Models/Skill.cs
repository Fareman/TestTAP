namespace TestTAP.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>
///     Скилл.
/// </summary>
public class Skill : BaseIdEntity
{
    /// <summary>
    ///     Уровень владения скиллом.
    /// </summary>
    [Required]
    public byte Level { get; set; }

    /// <summary>
    ///     Название скилла.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    ///     Внешний ключ для связи с сотрудником.
    /// </summary>
    [Required]
    public long PersonId { get; set; }
}