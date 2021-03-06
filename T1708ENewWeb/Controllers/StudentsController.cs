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
    public class StudentsController : Controller
    {
        private readonly T1708ENewWebContext _context;

        public StudentsController(T1708ENewWebContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.Include(m => m.Marks)
                .FirstOrDefaultAsync(m => m.RollNumber == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RollNumber,FirstName,LastName,Email,CreatedAt,UpdatedAt,Status")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RollNumber,FirstName,LastName,Email,CreatedAt,UpdatedAt,Status")] Student student)
        {
            if (id != student.RollNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.RollNumber))
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
            return View(student);
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var student = _context.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Student.Remove(student);
            _context.SaveChanges();
            return Redirect("Index");
        }

        [HttpDelete]
        public IActionResult DeleteMany(string ids)
        {
            var stringStudentIds = ids.Split(",");

            foreach (var studentId in stringStudentIds)
            {
                var student = _context.Student.Find(studentId);
                if (student == null)
                {
                    return NotFound();
                }
                _context.Student.Remove(student);

            }
            _context.SaveChanges();
            TempData["message"] = "Delete all success";

            return Redirect("Index");
        }

        private bool StudentExists(string id)
        {
            return _context.Student.Any(e => e.RollNumber == id);
        }
    }
}
