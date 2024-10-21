using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace self_promo_dawson.Data;

public class Experience
{
    [Key]
    public int ExperienceId { get; set; } 
    [Required]
    [MaxLength(100)]
    public string Company { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string JobTitle { get; set; } = default!;

    [Required]
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }

    [Required]
    [MaxLength(5000)]
    public string Description { get; set; } = default!;
    public bool IsProfessional { get; set; }

    // Navigation property to access "children"
    public ICollection<Responsibility> Responsibilities { get; set; } = new List<Responsibility>();
}