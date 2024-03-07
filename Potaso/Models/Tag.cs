using System.ComponentModel.DataAnnotations;

namespace Potaso.Models;

/**
 * Das Model des Tags
 */
public class Tag
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}

