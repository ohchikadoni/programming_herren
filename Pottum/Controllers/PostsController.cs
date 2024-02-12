using Microsoft.AspNetCore.Mvc;
using Pottum.Data;
using Pottum.Models;
using System.Diagnostics;

namespace Pottum.Controllers;

public class PostsController : Controller
{
    private readonly PottumContext _context;

    public PostsController(PottumContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Store([FromBody] Post post)
    {
        _context.Post.Add(post);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Show(int id)
    {
        var staff = _context.Post.FirstOrDefault(e => e.Id == id);
        return View();
    }

    public IActionResult Edit(int id)
    {
        var post = _context.Post.FirstOrDefault(e => e.Id == id);
        return View(post);
    }

    public IActionResult Update([FromBody] Post post)
    {
        var oldPost = _context.Post.FirstOrDefault(e => e.Id == post.Id);

        _context.Entry(oldPost).CurrentValues.SetValues(post);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Destroy(int id)
    {
        var post = _context.Post.FirstOrDefault(e => e.Id == id);

        _context.Post.Remove(post);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
