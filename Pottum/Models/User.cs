using System.ComponentModel.DataAnnotations;

namespace Pottum.Models;

public class User
{
    public int Id { get; set; }

    public Diary Diary { get; set; }

    [Required(ErrorMessage = "User Name is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}

