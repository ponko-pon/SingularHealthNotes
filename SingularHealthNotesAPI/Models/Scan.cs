using System.ComponentModel.DataAnnotations;

namespace SingularHealthNotesAPI.Models
{
    public class Scan
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        public Note[]? Notes { get; set; }

        [Required]
        public string? ImageUrl { get; set; }
    }
}
