using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Potaso.Data;
using Potaso.Models;
using Potaso.ViewModels;
using System.Diagnostics;

namespace Potaso.Controllers;

[Authorize]
public class PostsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    public PostsController(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    /**
     * Diese Methode zeigt die Ansicht mit allen Posts vom Benutzer an.
     */
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var posts = user!.Posts.Select(p => new PostViewModel() {
            Id = p.Id,
            Title = p.Title,
            Content = p.Content,
            Tags = string.Join(',', p.Tags.Select(t => t.Title))
        });

        return View(posts);
    }

    /**
     * Diese Methode zeigt die Create Ansicht an
     */
    public IActionResult Create()
    {
        return View();
    }

    /**
     * Diese Methode erstellt einen Post.
     */
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PostViewModel postVM)
    {
        if (ModelState.IsValid)
        {
            var userId = (await _userManager.GetUserAsync(HttpContext.User))!.Id; // Gibt den Eingelogten User zurück

            var tags = postVM.Tags!.Split(',').Select(t => t.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToList(); // Split
            var existingTags = _context.Tags.Where(t => tags.Contains(t.Title)).ToList();
            var newTags = tags.Except(existingTags.Select(t => t.Title));

            foreach (var newTag in newTags)
            {
                var tag = new Tag() {
                    Title = newTag
                };
                _context.Tags.Add(tag);
                existingTags.Add(tag);
            }

            var post = new Post() {
                Title = postVM.Title,
                Content = postVM.Content,
                Tags = existingTags,
                UserId = userId
            };
            _context.Add(post);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
        }

        return View(postVM);
    }

        /**
     * Diese Methode zeigt die Edit Ansicht an
     */
    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var post = await _context.Posts.FindAsync(new Guid(id));
        if (post == null)
        {
            return NotFound();
        }

        var postVM = new PostViewModel() {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            Tags = string.Join(',', post.Tags.Select(t => t.Title))
        };

        return View(postVM);
    }

    /**
     * Diese Methode zeigt die Edit Ansicht an
     */
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var post = await _context.Posts.FindAsync(new Guid(id));
        if (post == null)
        {
            return NotFound();
        }

        var postVM = new PostViewModel() {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            Tags = string.Join(',', post.Tags.Select(t => t.Title))
        };

        return View(postVM);
    }

    /**
     * Diese Methode ändert den Post
     */
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, PostViewModel postVM)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userId = (await _userManager.GetUserAsync(HttpContext.User))!.Id;
        var postToUpdate = await _context.Posts.FirstOrDefaultAsync(p => p.Id == new Guid(id) && p.UserId == userId);

        if (postToUpdate == null)
        {
            return NotFound();
        }

        if(ModelState.IsValid)
        {
            postToUpdate.Title = postVM.Title;
            postToUpdate.Content = postVM.Content;

            var tags = postVM.Tags!.Split(',').Select(t => t.Trim()).Where(t => !string.IsNullOrEmpty(t)).ToList();
            var existingTagsInDB = _context.Tags.Where(t => tags.Contains(t.Title)).ToList();
            var newTags = tags.Except(existingTagsInDB.Select(t => t.Title));

            foreach (var newTag in newTags)
            {
                var tag = new Tag() {
                    Title = newTag
                };
                _context.Tags.Add(tag);
                existingTagsInDB.Add(tag);
            }

            postToUpdate.Tags.Clear();
            postToUpdate.Tags = existingTagsInDB;

            var cleanExcludes = existingTagsInDB.Select(t => t.Id).ToList();
            var tagsToClean = _context.Tags.Where(t => !t.Posts.Any() && !cleanExcludes.Contains(t.Id));
            _context.Tags.RemoveRange(tagsToClean);

            try
            {
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

        return View(postVM);
    }

    /**
     * Diese Methode löscht den Post
     */
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userId = (await _userManager.GetUserAsync(HttpContext.User))!.Id;
        var postToDelete = await _context.Posts.FirstOrDefaultAsync(p => p.Id == new Guid(id) && p.UserId == userId);

        if (postToDelete == null)
        {
            return NotFound();
        }

        _context.Posts.Remove(postToDelete);

        var tagsToClean = _context.Tags.Where(t => t.Posts.Count(p => p.Id != postToDelete.Id) == 0);
        _context.Tags.RemoveRange(tagsToClean);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists, " +
                "see your system administrator.");
        }

        return RedirectToAction(nameof(Index));
    }
}
