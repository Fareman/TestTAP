namespace TestTAP.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Сотрудник.
    /// </summary>
    public class Person: BaseIdEntity
    {
        /// <summary>
        /// Полное имя сотрудника.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Отображаемое имя сотрудника.
        /// </summary>
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// Перечень скилов.
        /// </summary>
        public List<Skill> Skills { get; set; }
    }
}
