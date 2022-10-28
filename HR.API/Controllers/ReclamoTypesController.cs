using HR.API.Data;
using HR.API.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReclamoTypesController : Controller
    {
        private readonly DataContext _context;

        public ReclamoTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: ReclamoTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReclamoTypes.ToListAsync());
        }

        // GET: ReclamoTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReclamoTypes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReclamoType reclamoType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(reclamoType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya Existe este Tipo de Reclamo");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(reclamoType);
        }

        // GET: ReclamoTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReclamoTypes == null)
            {
                return NotFound();
            }

            ReclamoType? reclamoType = await _context.ReclamoTypes.FindAsync(id);
            if (reclamoType == null)
            {
                return NotFound();
            }
            return View(reclamoType);
        }

        // POST: ReclamoTypes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReclamoType reclamoType)
        {
            if (id != reclamoType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reclamoType);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya Existe este Tipo de Reclamo");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

            }
            return View(reclamoType);
        }

        // GET: ReclamoTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReclamoTypes == null)
            {
                return NotFound();
            }

            ReclamoType? reclamoType = await _context.ReclamoTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reclamoType == null)
            {
                return NotFound();
            }
            _context.ReclamoTypes.Remove(reclamoType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
