using System.ComponentModel.DataAnnotations;

namespace Pottum.Models;

public class Post
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Content is required")]
    public string? Content { get; set; }

    public List<Tag> Tags { get; set; }
}

