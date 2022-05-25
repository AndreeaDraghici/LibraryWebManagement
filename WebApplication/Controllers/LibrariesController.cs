#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class LibrariesController : Controller
    {
        private readonly LibraryService _libraryService;

        public LibrariesController(LibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        // GET: Libraries
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Index()
        {
            var library=_libraryService.GetLibraries();
            return View(library);
        }

        // GET: Libraries/Details/5
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = _libraryService.GetLibraries().FirstOrDefault(m => m.stock_id == id);
            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }

        // GET: Libraries/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create([Bind("stock_id,total_nr_of_books,borrowed_books")] Library library)
        {
            if (ModelState.IsValid)
            {
                _libraryService.AddLibrary(library);
                _libraryService.Save();
                return RedirectToAction("Index", "Books");
            }
            return View(library);


        }

        // GET: Libraries/Edit/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = _libraryService.GetLibraries().FirstOrDefault(m=>m.stock_id==id);
            if (library == null)
            {
                return NotFound();
            }
            return View(library);
        }

        // POST: Libraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public IActionResult Edit(int id, [Bind("stock_id,total_nr_of_books,borrowed_books")] Library library)
        {
            if (id != library.stock_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _libraryService.UpdateLibrary(library);
                    _libraryService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryExists(library.stock_id))
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
            return View(library);
        }

        // GET: Libraries/Delete/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = _libraryService.GetLibraries().FirstOrDefault(m => m.stock_id == id);
            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }

        // POST: Libraries/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {
            var library = _libraryService.GetLibrariesByCondition(b=>b.stock_id==id).FirstOrDefault();
            _libraryService.DeleteLibrary(library);
            _libraryService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryExists(int id)
        {
            return _libraryService.GetLibraries().Any(e => e.stock_id == id);
        }
    }
}
