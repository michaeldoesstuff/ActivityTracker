using System.Diagnostics;
using ActivityTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActivityTracker.Controllers;

public class ActivityController : Controller
{
    private readonly ApplicationDbContext _context;

    public ActivityController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Activities.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ActivityModel activity)
    {
        if (ModelState.IsValid)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View(activity);
        }
    }
    
    public IActionResult Delete(int id)
    {
        var activity = _context.Activities.Find(id);
        if (activity == null)
        {
            return NotFound();
        }
        else
        {
            _context.Activities.Remove(activity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}