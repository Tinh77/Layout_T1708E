﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T1708ENewWeb.Models;

namespace T1708ENewWeb.Controllers
{
    public class MarksController : Controller
    {
        private readonly T1708ENewWebContext _context;

        public MarksController(T1708ENewWebContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            var t1708ENewWebContext = _context.Mark.Include(m => m.Student);
            return View(await t1708ENewWebContext.ToListAsync());
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark
                .Include(m => m.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewData["StudentRollNumber"] = new SelectList(_context.Student, "RollNumber", "RollNumber");
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubjectName,SubjectMark,StudentRollNumber")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentRollNumber"] = new SelectList(_context.Student, "RollNumber", "RollNumber", mark.StudentRollNumber);
            return View(mark);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }
            ViewData["StudentRollNumber"] = new SelectList(_context.Student, "RollNumber", "RollNumber", mark.StudentRollNumber);
            return View(mark);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubjectName,SubjectMark,StudentRollNumber")] Mark mark)
        {
            if (id != mark.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkExists(mark.Id))
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
            ViewData["StudentRollNumber"] = new SelectList(_context.Student, "RollNumber", "RollNumber", mark.StudentRollNumber);
            return View(mark);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var mark = _context.Mark.Find(id);
            if (mark == null)
            {
                return NotFound();
            }
            _context.Mark.Remove(mark);
            _context.SaveChanges();
            return Redirect("Index");
        }

        [HttpDelete]
        public IActionResult DeleteMany(string ids)
        {
            var stringMarkIds = ids.Split(",");

            foreach (var markId in stringMarkIds)
            {
                var mark = _context.Mark.Find(Convert.ToInt32(markId));
                if (mark == null)
                {
                    return NotFound();
                }
                _context.Mark.Remove(mark);

            }
            _context.SaveChanges();
            TempData["message"] = "Delete all success";

            return Redirect("Index");
        }


        private bool MarkExists(int id)
        {
            return _context.Mark.Any(e => e.Id == id);
        }
    }
}
