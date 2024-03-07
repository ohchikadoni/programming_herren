using System.ComponentModel.DataAnnotations;

namespace Potaso.ViewModels;

/**
 * Dies ist ein View Model welches für die Eingabe und Ausgabe des Post verwendet wird.
 */
public class PostViewModel
{
    public Guid? Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Content is required")]
    public string Content { get; set; } = null!;

    public string? Tags { get; set; } = null!;
}
