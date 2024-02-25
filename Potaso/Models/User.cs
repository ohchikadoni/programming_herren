using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Potaso.Models;

public class User: IdentityUser
{
    public ICollection<Post> Posts { get; } = new List<Post>();
}
