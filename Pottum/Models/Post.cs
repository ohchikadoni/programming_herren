using System.ComponentModel.DataAnnotations;

namespace Pottum.Models;

public class Post
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public List<Tag> Tags { get; set; }
}

