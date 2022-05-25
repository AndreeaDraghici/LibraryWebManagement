#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService=authorService;
        }

        // GET: Authors
        public IActionResult Index()
        {
            var author=_authorService.GetAuthors();
            return View(author);
        }

        // GET: Authors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _authorService.GetAuthors().FirstOrDefault(m => m.author_id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("author_id,name")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorService.AddAuthor(author);
                _authorService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _authorService.GetAuthors().FirstOrDefault(m => m.author_id == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("author_id,name")] Author author)
        {
            if (id != author.author_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _authorService.UpdateAuthor(author);
                    _authorService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.author_id))
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
            return View(author);
        }

        // GET: Authors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _authorService.GetAuthors().FirstOrDefault(m => m.author_id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _authorService.GetAuthorsByCondition(b=>b.author_id==id).FirstOrDefault();
            _authorService.DeleteAuthor(author);
            _authorService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
            return _authorService.GetAuthors().Any(e => e.author_id == id);
        }
    }
}
