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
    public class CatalogoProductoesController : Controller
    {
        private readonly DevelopmentAs1Context _context;

        public CatalogoProductoesController(DevelopmentAs1Context context)
        {
            _context = context;
        }

        // GET: CatalogoProductoes
        public async Task<IActionResult> Index()
        {
            var developmentAs1Context = _context.CatalogoProductos.Include(c => c.IdFichaTecnicaNavigation);
            return View(await developmentAs1Context.ToListAsync());
        }

        // GET: CatalogoProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoProducto = await _context.CatalogoProductos
                .Include(c => c.IdFichaTecnicaNavigation)
                .FirstOrDefaultAsync(m => m.IdcatalogoProducto == id);
            if (catalogoProducto == null)
            {
                return NotFound();
            }

            return View(catalogoProducto);
        }

        // GET: CatalogoProductoes/Create
        public IActionResult Create()
        {
            ViewData["IdFichaTecnica"] = new SelectList(_context.FichasTecnicas, "IdFicha", "IdFicha");
            return View();
        }

        // POST: CatalogoProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdcatalogoProducto,IdFichaTecnica,FechaRegistro,TipoEstampado,Color,Stock,TamañoEstampado,PrecioProducto,TipoCatalogo,ImagenProducto")] CatalogoProducto catalogoProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalogoProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFichaTecnica"] = new SelectList(_context.FichasTecnicas, "IdFicha", "IdFicha", catalogoProducto.IdFichaTecnica);
            return View(catalogoProducto);
        }

        // GET: CatalogoProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoProducto = await _context.CatalogoProductos.FindAsync(id);
            if (catalogoProducto == null)
            {
                return NotFound();
            }
            ViewData["IdFichaTecnica"] = new SelectList(_context.FichasTecnicas, "IdFicha", "IdFicha", catalogoProducto.IdFichaTecnica);
            return View(catalogoProducto);
        }

        // POST: CatalogoProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdcatalogoProducto,IdFichaTecnica,FechaRegistro,TipoEstampado,Color,Stock,TamañoEstampado,PrecioProducto,TipoCatalogo,ImagenProducto")] CatalogoProducto catalogoProducto)
        {
            if (id != catalogoProducto.IdcatalogoProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalogoProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogoProductoExists(catalogoProducto.IdcatalogoProducto))
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
            ViewData["IdFichaTecnica"] = new SelectList(_context.FichasTecnicas, "IdFicha", "IdFicha", catalogoProducto.IdFichaTecnica);
            return View(catalogoProducto);
        }

        // GET: CatalogoProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalogoProducto = await _context.CatalogoProductos
                .Include(c => c.IdFichaTecnicaNavigation)
                .FirstOrDefaultAsync(m => m.IdcatalogoProducto == id);
            if (catalogoProducto == null)
            {
                return NotFound();
            }

            return View(catalogoProducto);
        }

        // POST: CatalogoProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalogoProducto = await _context.CatalogoProductos.FindAsync(id);
            if (catalogoProducto != null)
            {
                _context.CatalogoProductos.Remove(catalogoProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogoProductoExists(int id)
        {
            return _context.CatalogoProductos.Any(e => e.IdcatalogoProducto == id);
        }
    }
}
