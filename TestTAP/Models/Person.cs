namespace TestTAP.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Person: BaseIdEntity
    {
        /// <summary>
        /// Имя сотрудника.
        /// </summary>
        [Required]
        [RegularExpression(@"^[A-Za-z0-9]+$", ErrorMessage = "The value is incorrect.")]
        [StringLength(256, MinimumLength = 1, ErrorMessage = "Value for {0} must be from {1} to {2} simbols.")]
        public string Name { get; set; }

        /// <summary>
        /// Ник сотрудника.
        /// </summary>
        [StringLength(256, MinimumLength = 1, ErrorMessage = "Value for {0} must be from {1} to {2} simbols.")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Перечень скилов.
        /// </summary>
        public List<Skill> Skills { get; set; }
    }
}
