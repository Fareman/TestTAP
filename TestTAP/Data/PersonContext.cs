namespace TestTAP.Data;

using Microsoft.EntityFrameworkCore;

using TestTAP.Models;

/// <summary>
///     Контекст приложения.
/// </summary>
public class PersonContext : DbContext
{
    /// <summary>
    ///     Конструктор контекста.
    /// </summary>
    /// <param name="options"> Настройки контекста. </param>
    public PersonContext(DbContextOptions options)
        : base(options)
    {
        Database.Migrate();
    }

    /// <summary>
    ///     Сотрудники.
    /// </summary>
    public DbSet<Person> Persons { get; set; }

    /// <summary>
    ///     Скилы.
    /// </summary>
    public DbSet<Skill> Skills { get; set; }
}