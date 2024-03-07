using System.ComponentModel.DataAnnotations;

namespace Potaso.Models;

/**
 * Das Model des Post hat Attributte für Id, Title, Content und UserId.
 * Es verlinkt den Benutzer und Tag mit dem Post.
 */
public class Post
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? UserId { get; set; } = null!;

    public virtual User? User { get; set; } = null!;

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}

