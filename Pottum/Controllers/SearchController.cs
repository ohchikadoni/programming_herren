using Microsoft.AspNetCore.Mvc;
using Pottum.Data;
using Pottum.Models;
using System.Diagnostics;

namespace Pottum.Controllers;

public class SearchController : Controller
{
    private readonly PottumContext _context;

    public SearchController(PottumContext context)
    {
        _context = context;
    }

    public IActionResult Index([FromQuery(Name = "q")] string query)
    {
        return View();
    }
}
