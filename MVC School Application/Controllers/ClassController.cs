using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_School_Application;
using MVC_School_Application.Models;

namespace MVC_School_Application.Controllers
{
    public class ClassController : Controller
    {
        private readonly Appcontext _context;

        public ClassController(Appcontext context)
        {
            _context = context;
        }

        // GET: Class
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassModel.ToListAsync());
        }

        // GET: Class/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classModel = await _context.ClassModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (classModel == null)
            {
                return NotFound();
            }

            return View(classModel);
        }

        // GET: Class/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Class/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,cls,section,starttime,endtime")] ClassModel classModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classModel);
        }

        // GET: Class/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classModel = await _context.ClassModel.FindAsync(id);
            if (classModel == null)
            {
                return NotFound();
            }
            return View(classModel);
        }

        // POST: Class/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,cls,section,starttime,endtime")] ClassModel classModel)
        {
            if (id != classModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassModelExists(classModel.id))
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
            return View(classModel);
        }

        // GET: Class/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classModel = await _context.ClassModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (classModel == null)
            {
                return NotFound();
            }

            return View(classModel);
        }

        // POST: Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var classModel = await _context.ClassModel.FindAsync(id);
            _context.ClassModel.Remove(classModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassModelExists(string id)
        {
            return _context.ClassModel.Any(e => e.id == id);
        }
    }
}
