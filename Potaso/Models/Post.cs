using System.ComponentModel.DataAnnotations;

namespace Potaso.Models;

public class Post
{
    public string Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Content is required")]
    public string? Content { get; set; }

    public string UserId { get; set; }

    public User User { get; set; } = null!;

    public ICollection<Tag> Tags { get; } = [];
}

