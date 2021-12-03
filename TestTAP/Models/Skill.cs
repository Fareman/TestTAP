namespace TestTAP.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Скилл
    /// </summary>
    public class Skill: BaseIdEntity
    {
        /// <summary>
        /// Уровень сотрудника.
        /// </summary>
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public byte Level { get; set; }

        /// <summary>
        /// Название скила.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        public long PersonId { get; set; }
    }
}
