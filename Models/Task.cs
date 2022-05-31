using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectEF.Models;

public class Task
{
    //[Key]
    public Guid Id { get; set; }

    //[ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }

    // [Required]
    // [MaxLength(200)]
    public string Title { get; set; }

    public string Description { get; set; }

    public Priority Priority {get; set;}

    public DateTime CreateDate { get; set; }

    public virtual Category Category { get; set; }

    //[NotMapped]
    public string Summary {get; set;}
}

public enum Priority
{
    Down,
    Medium,
    High
}