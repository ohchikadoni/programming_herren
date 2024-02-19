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

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Store([FromBody] Tag tag)
    {
        _context.Tags.Add(tag);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Show(int id)
    {
        var tag = _context.Tags.FirstOrDefault(e => e.Id == id);
        return View(tag);
    }

    public IActionResult Edit(int id)
    {
        var tag = _context.Tags.FirstOrDefault(e => e.Id == id);
        return View(tag);
    }

    public IActionResult Update([FromBody] Tag tag)
    {
        var oldTag = _context.Tags.FirstOrDefault(e => e.Id == tag.Id);

        _context.Entry(oldTag).CurrentValues.SetValues(tag);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Destroy(int id)
    {
        var tag = _context.Tags.FirstOrDefault(e => e.Id == id);

        _context.Tags.Remove(tag);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
