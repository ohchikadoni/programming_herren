using System.ComponentModel.DataAnnotations;

namespace Potaso.Models;

public class Tag
{
    public string Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }

    public ICollection<Post> Posts { get; } = [];
}

