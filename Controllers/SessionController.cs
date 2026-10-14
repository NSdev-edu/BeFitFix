
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeFit.Models;
using BeFit.Data;

public class SessionController : Controller
{
    private readonly ApplicationDbContext _context;

    public SessionController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: SESSIONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Session.ToListAsync());
    }

    // GET: SESSIONS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var session = await _context.Session
            .FirstOrDefaultAsync(m => m.Id == id);
        if (session == null)
        {
            return NotFound();
        }

        return View(session);
    }

    // GET: SESSIONS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SESSIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Start,Stop")] Session session)
    {
        if (ModelState.IsValid)
        {
            _context.Add(session);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(session);
    }

    // GET: SESSIONS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var session = await _context.Session.FindAsync(id);
        if (session == null)
        {
            return NotFound();
        }
        return View(session);
    }

    // POST: SESSIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Start,Stop")] Session session)
    {
        if (id != session.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(session);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(session.Id))
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
        return View(session);
    }

    // GET: SESSIONS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var session = await _context.Session
            .FirstOrDefaultAsync(m => m.Id == id);
        if (session == null)
        {
            return NotFound();
        }

        return View(session);
    }

    // POST: SESSIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var session = await _context.Session.FindAsync(id);
        if (session != null)
        {
            _context.Session.Remove(session);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SessionExists(int? id)
    {
        return _context.Session.Any(e => e.Id == id);
    }
}
