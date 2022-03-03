namespace TestTAP.Models;

using System.ComponentModel.DataAnnotations;

/// <summary>
///     Сотрудник.
/// </summary>
public class Person : BaseIdEntity
{
    /// <summary>
    ///     Отображаемое имя сотрудника.
    /// </summary>
    [Required]
    public string DisplayName { get; set; }

    /// <summary>
    ///     Полное имя сотрудника.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    ///     Перечень скилов.
    /// </summary>
    public List<Skill> Skills { get; set; }
}