using Microsoft.AspNetCore.Mvc;
using Pottum.Data;
using Pottum.Models;
using System.Diagnostics;

namespace Pottum.Controllers;

public class TagsController : Controller
{
    private readonly PottumContext _context;

    public TagsController(PottumContext context)
    {
        _context = context;
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Logout([FromBody] Tag tag)
    {
        _context.Tags.Add(tag);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
