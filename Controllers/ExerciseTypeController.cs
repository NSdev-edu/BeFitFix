
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeFit.Models;
using BeFit.Data;

public class ExerciseTypeController : Controller
{
    private readonly ApplicationDbContext _context;

    public ExerciseTypeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: EXERCISETYPES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.ExerciseType.ToListAsync());
    }

    // GET: EXERCISETYPES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var exercisetype = await _context.ExerciseType
            .FirstOrDefaultAsync(m => m.Id == id);
        if (exercisetype == null)
        {
            return NotFound();
        }

        return View(exercisetype);
    }

    // GET: EXERCISETYPES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: EXERCISETYPES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name")] ExerciseType exercisetype)
    {
        if (ModelState.IsValid)
        {
            _context.Add(exercisetype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(exercisetype);
    }

    // GET: EXERCISETYPES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var exercisetype = await _context.ExerciseType.FindAsync(id);
        if (exercisetype == null)
        {
            return NotFound();
        }
        return View(exercisetype);
    }

    // POST: EXERCISETYPES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Name")] ExerciseType exercisetype)
    {
        if (id != exercisetype.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(exercisetype);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseTypeExists(exercisetype.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(exercisetype);
    }

    // GET: EXERCISETYPES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var exercisetype = await _context.ExerciseType
            .FirstOrDefaultAsync(m => m.Id == id);
        if (exercisetype == null)
        {
            return NotFound();
        }

        return View(exercisetype);
    }

    // POST: EXERCISETYPES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var exercisetype = await _context.ExerciseType.FindAsync(id);
        if (exercisetype != null)
        {
            _context.ExerciseType.Remove(exercisetype);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ExerciseTypeExists(int? id)
    {
        return _context.ExerciseType.Any(e => e.Id == id);
    }
}
