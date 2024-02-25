using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Potaso.Data;
using Potaso.Models;

namespace Potaso.Controllers;

public class PostsController : Controller
{
    private readonly ApplicationDbContext _context;

    public PostsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var posts = HttpContext.User.Identity.Posts;

        return View(await posts.ToListAsync());
    }
}
