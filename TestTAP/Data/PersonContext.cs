namespace TestTAP.Data
{
    using Microsoft.EntityFrameworkCore;
    using TestTAP.Models;

    /// <summary>
    /// Контекст приложения.
    /// </summary>
    public class PersonContext: DbContext
    {
        /// <summary>
        /// Сотрудники.
        /// </summary>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        /// Скилы.
        /// </summary>
        public DbSet<Skill> Skills { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="options"> Настройки контекста. </param>
        public PersonContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
