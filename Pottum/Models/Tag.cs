using System.ComponentModel.DataAnnotations;

namespace Pottum.Models;

public class Tag
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }
}

