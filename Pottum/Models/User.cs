using System.ComponentModel.DataAnnotations;

namespace Pottum.Models;

public class User
{
    public int Id { get; set; }

    public Diary Diary { get; set; }
}

