using System.ComponentModel.DataAnnotations;

namespace Pottum.Models;

public class Diary
{
    public int Id { get; set; }

    public List<Post> Posts { get; set; }
}

