using System.ComponentModel.DataAnnotations;

namespace ApiTasking.Data.DTOs
{
    public class TaskingUpdateDto
    {
        [Required]
        [StringLength(256)]
        public string? Description { get; set; }

        [Required]
        public bool Done { get; set; }

        [Required]
        public DateTime DtDone { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
