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
    public class SubjectController : Controller
    {
        private readonly Appcontext _context;

        public SubjectController(Appcontext context)
        {
            _context = context;
        }

        // GET: Subject
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubjectModel.ToListAsync());
        }

        // GET: Subject/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectModel = await _context.SubjectModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (subjectModel == null)
            {
                return NotFound();
            }

            return View(subjectModel);
        }

        // GET: Subject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,subname")] SubjectModel subjectModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjectModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subjectModel);
        }

        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectModel = await _context.SubjectModel.FindAsync(id);
            if (subjectModel == null)
            {
                return NotFound();
            }
            return View(subjectModel);
        }

        // POST: Subject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,subname")] SubjectModel subjectModel)
        {
            if (id != subjectModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectModelExists(subjectModel.id))
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
            return View(subjectModel);
        }

        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectModel = await _context.SubjectModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (subjectModel == null)
            {
                return NotFound();
            }

            return View(subjectModel);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var subjectModel = await _context.SubjectModel.FindAsync(id);
            _context.SubjectModel.Remove(subjectModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectModelExists(string id)
        {
            return _context.SubjectModel.Any(e => e.id == id);
        }
    }
}
