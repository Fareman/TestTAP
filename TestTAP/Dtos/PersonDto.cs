namespace TestTAP.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using TestTAP.Models;
    /// <summary>
    /// DTO сотрудников.
    /// </summary>
    public class PersonDto
    {
        /// <summary>
        /// Идентификатор сотрудника.
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// Полное имя сотрудника.
        /// </summary>
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "The value is incorrect.")]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "Value for {0} must be from {1} to {2} symbols.")]
        public string Name { get; set; }

        /// <summary>
        /// Отображаемое имя сотрудника.
        /// </summary>
        [StringLength(256, MinimumLength = 1, ErrorMessage = "Value for {0} must be from {1} to {2} symbols.")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Список скилов сотрудника.
        /// </summary>
        public List<SkillDto> Skills { get; set; }
    }
}
