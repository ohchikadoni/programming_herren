using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Potaso.Models;

public class User: IdentityUser
{
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
