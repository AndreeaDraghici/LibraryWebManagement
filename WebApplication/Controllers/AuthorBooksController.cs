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
    public class AuthorBooksController : Controller
    {
        private readonly AuthorBookService _authorBookService;

        public AuthorBooksController(AuthorBookService authorBookService)
        {
            _authorBookService = authorBookService;
        }

        // GET: AuthorBooks
        public IActionResult Index()
        {
            var authorBooks=_authorBookService.GetAuthorBooks();
            return View(authorBooks);
        }

        // GET: AuthorBooks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorBook =  _authorBookService.GetAuthorBooks().FirstOrDefault(m => m.id == id);
            if (authorBook == null)
            {
                return NotFound();
            }

            return View(authorBook);
        }

        // GET: AuthorBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthorBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("id,author_id,book_id")] AuthorBook authorBook)
        {
            if (ModelState.IsValid)
            {
                _authorBookService.AddAuthorBook(authorBook);
                _authorBookService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(authorBook);
        }

        // GET: AuthorBooks/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorBook = _authorBookService.GetAuthorBooks().FirstOrDefault(m=>m.id == id);
            if (authorBook == null)
            {
                return NotFound();
            }
            return View(authorBook);
        }

        // POST: AuthorBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("id,author_id,book_id")] AuthorBook authorBook)
        {
            if (id != authorBook.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _authorBookService.UpdateAuthorBook(authorBook);
                    _authorBookService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorBookExists(authorBook.id))
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
            return View(authorBook);
        }

        // GET: AuthorBooks/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authorBook = _authorBookService.GetAuthorBooks().FirstOrDefault(m => m.id == id);
            if (authorBook == null)
            {
                return NotFound();
            }

            return View(authorBook);
        }

        // POST: AuthorBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var authorBook = _authorBookService.GetAuthorBooksByCondition(b=>b.id==id).FirstOrDefault();
            _authorBookService.DeleteAuthorBook(authorBook);
            _authorBookService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorBookExists(int id)
        {
            return _authorBookService.GetAuthorBooks().Any(e => e.id == id);
        }
    }
}
