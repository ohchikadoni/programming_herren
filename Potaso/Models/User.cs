using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Potaso.Models;

/**
 * Für das Model des Users wird der IdentityUser vom Identity Framework verwendet.
 * Wir haben ihn erweitert mit dem Posts Attribut.
 */
public class User: IdentityUser
{
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
