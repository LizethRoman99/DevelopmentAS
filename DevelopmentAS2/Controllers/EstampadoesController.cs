﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevelopmentAS2.Models;

namespace DevelopmentAS2.Controllers
{
    public class EstampadoesController : Controller
    {
        private readonly DevelopmentAs1Context _context;

        public EstampadoesController(DevelopmentAs1Context context)
        {
            _context = context;
        }

        // GET: Estampadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estampados.ToListAsync());
        }

        // GET: Estampadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estampado = await _context.Estampados
                .FirstOrDefaultAsync(m => m.IdEstampado == id);
            if (estampado == null)
            {
                return NotFound();
            }

            return View(estampado);
        }

        // GET: Estampadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estampadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstampado,NombreEstampado,DescripcionEstampado,EstadoEstampado")] Estampado estampado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estampado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estampado);
        }

        // GET: Estampadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estampado = await _context.Estampados.FindAsync(id);
            if (estampado == null)
            {
                return NotFound();
            }
            return View(estampado);
        }

        // POST: Estampadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstampado,NombreEstampado,DescripcionEstampado,EstadoEstampado")] Estampado estampado)
        {
            if (id != estampado.IdEstampado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estampado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstampadoExists(estampado.IdEstampado))
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
            return View(estampado);
        }

        // GET: Estampadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estampado = await _context.Estampados
                .FirstOrDefaultAsync(m => m.IdEstampado == id);
            if (estampado == null)
            {
                return NotFound();
            }

            return View(estampado);
        }

        // POST: Estampadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estampado = await _context.Estampados.FindAsync(id);
            if (estampado != null)
            {
                _context.Estampados.Remove(estampado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstampadoExists(int id)
        {
            return _context.Estampados.Any(e => e.IdEstampado == id);
        }
    }
}
