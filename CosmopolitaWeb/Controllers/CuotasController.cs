using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CosmopolitaWeb.Data;
using CosmopolitaWeb.Models;

namespace CosmopolitaWeb.Controllers
{
    public class CuotasController : Controller
    {
        private readonly CosmopolitaWebContext _context;

        public CuotasController(CosmopolitaWebContext context)
        {
            _context = context;
        }

        // GET: Cuotas
        public async Task<IActionResult> Index()
        {
            var cosmopolitaWebContext = _context.Cuotas.Include(c => c.Actividad).Include(c => c.Cobrador).Include(c => c.Socio);
            return View(await cosmopolitaWebContext.ToListAsync());
        }

        // GET: Cuotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuota = await _context.Cuotas
                .Include(c => c.Actividad)
                .Include(c => c.Cobrador)
                .Include(c => c.Socio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuota == null)
            {
                return NotFound();
            }

            return View(cuota);
        }

        // GET: Cuotas/Create
        public IActionResult Create()
        {
            ViewData["ActividadId"] = new SelectList(_context.Actividades, "Id", "Horarios");
            ViewData["CobradorId"] = new SelectList(_context.Cobradores, "Id", "Apellido_Nombre");
            ViewData["SocioId"] = new SelectList(_context.Socios, "Id", "Apellido_Nombre");
            return View();
        }

        // POST: Cuotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mes,Año,Monto,Cobrada,Vencimiento,SocioId,ActividadId,CobradorId")] Cuota cuota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActividadId"] = new SelectList(_context.Actividades, "Id", "Horarios", cuota.ActividadId);
            ViewData["CobradorId"] = new SelectList(_context.Cobradores, "Id", "Apellido_Nombre", cuota.CobradorId);
            ViewData["SocioId"] = new SelectList(_context.Socios, "Id", "Apellido_Nombre", cuota.SocioId);
            return View(cuota);
        }

        // GET: Cuotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuota = await _context.Cuotas.FindAsync(id);
            if (cuota == null)
            {
                return NotFound();
            }
            ViewData["ActividadId"] = new SelectList(_context.Actividades, "Id", "Horarios", cuota.ActividadId);
            ViewData["CobradorId"] = new SelectList(_context.Cobradores, "Id", "Apellido_Nombre", cuota.CobradorId);
            ViewData["SocioId"] = new SelectList(_context.Socios, "Id", "Apellido_Nombre", cuota.SocioId);
            return View(cuota);
        }

        // POST: Cuotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mes,Año,Monto,Cobrada,Vencimiento,SocioId,ActividadId,CobradorId")] Cuota cuota)
        {
            if (id != cuota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuotaExists(cuota.Id))
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
            ViewData["ActividadId"] = new SelectList(_context.Actividades, "Id", "Horarios", cuota.ActividadId);
            ViewData["CobradorId"] = new SelectList(_context.Cobradores, "Id", "Apellido_Nombre", cuota.CobradorId);
            ViewData["SocioId"] = new SelectList(_context.Socios, "Id", "Apellido_Nombre", cuota.SocioId);
            return View(cuota);
        }

        // GET: Cuotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuota = await _context.Cuotas
                .Include(c => c.Actividad)
                .Include(c => c.Cobrador)
                .Include(c => c.Socio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuota == null)
            {
                return NotFound();
            }

            return View(cuota);
        }

        // POST: Cuotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuota = await _context.Cuotas.FindAsync(id);
            _context.Cuotas.Remove(cuota);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuotaExists(int id)
        {
            return _context.Cuotas.Any(e => e.Id == id);
        }
    }
}
