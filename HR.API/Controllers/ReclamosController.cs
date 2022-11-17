using HR.API.Data;
using HR.API.Data.Entities;
using HR.API.Helpers;
using HR.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HR.API.Controllers
{
        [Authorize(Roles = "Admin")]
        public class ReclamosController : Controller
        {
            private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ReclamosController(DataContext context,ICombosHelper combosHelper)
            {
                _context = context;
                _combosHelper = combosHelper;
        }
            // GET: ReclamoTypes
            public async Task<IActionResult> Index()
            {
                return View(await _context.Reclamos
                    .Include(x=>x.Abonado)
                    .Include(x=>x.ReclamoMateriales)
                    .ThenInclude(c=>c.Material)
                    .Include(x=>x.ReclamoTecnicos)
                    .ThenInclude(v=>v.User)
                    .Include(x=>x.TipoReclamo)
                    .ToListAsync());
            }

            // GET: ReclamoTypes/Create
            public IActionResult Create()
            {
                 ReclamoViewModel model = new ReclamoViewModel
                 {
                     Materiales=_combosHelper.GetComboMateriales(),
                     Tecnicos=_combosHelper.GetComboTecnicos(),
                     TipoReclamos=_combosHelper.GetComboTipodeReclamos()


                 };

                return View(model);
            }

            // POST: ReclamoTypes/Create

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(ReclamoViewModel reclamo)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Add(reclamo);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException dbUpdateException)
                    {

                        if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                        {
                            ModelState.AddModelError(string.Empty, "Ya Existe este Reclamo");
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
                return View(reclamo);
            }

            // GET: ReclamoTypes/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null || _context.Materiales == null)
                {
                    return NotFound();
                }

                Reclamo? reclamo = await _context.Reclamos.FindAsync(id);
                if (reclamo == null)
                {
                    return NotFound();
                }
                return View(reclamo);
            }

            // POST: ReclamoTypes/Edit/5

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Reclamo reclamo)
            {
                if (id != reclamo.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(reclamo);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException dbUpdateException)
                    {

                        if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                        {
                            ModelState.AddModelError(string.Empty, "Ya Existe este Reclamo");
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
                return View(reclamo);
            }

            // GET: Funciones/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null || _context.Reclamos == null)
                {
                    return NotFound();
                }

                Reclamo? reclamo = await _context.Reclamos
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (reclamo == null)
                {
                    return NotFound();
                }
                _context.Reclamos.Remove(reclamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


       
    }
}
