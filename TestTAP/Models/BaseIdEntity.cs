namespace TestTAP.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Сущность с ID.
    /// </summary>
    public abstract class BaseIdEntity
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
    }
}
