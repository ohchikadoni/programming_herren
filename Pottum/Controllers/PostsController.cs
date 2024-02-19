using Microsoft.AspNetCore.Mvc;
using Pottum.Data;
using Pottum.Models;
using Microsoft.EntityFrameworkCore;
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title,Content,Tags")] Post post)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
        }

        return View(post);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var post = await _context.Posts
            .Include(s => s.Tags)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (post == null)
        {
            return NotFound();
        }

        return View(post);

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Content,Tags")] Post post)
    {
        if (id != post.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
        }

        return View(post);
    }

    public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
    {
        if (id == null)
        {
            return NotFound();
        }

        var post = await _context.Posts
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (post == null)
        {
            return NotFound();
        }

        if (saveChangesError.GetValueOrDefault())
        {
            ViewData["ErrorMessage"] =
                "Delete failed. Try again, and if the problem persists " +
                "see your system administrator.";
        }

        return View(post);
    }
}
