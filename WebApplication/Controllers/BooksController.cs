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
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class BooksController : Controller
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Books
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Index()
        {
            var book=_bookService.GetBooks();
            return View(book);
        }

        // GET: Books/Details/5
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetBooks().FirstOrDefault(m => m.book_id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create([Bind("book_id,name,publisher,category_type,stock_id,message_id")] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(book);
                _bookService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetBooks().FirstOrDefault(m => m.book_id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public IActionResult Edit(int id, [Bind("book_id,name,publisher,category_type,stock_id,message_id")] Book book)
        {
            if (id != book.book_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.UpdateBook(book);
                    _bookService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.book_id))
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
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetBooks()
                .FirstOrDefault(m => m.book_id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = _bookService.GetBooksByCondition(b=>b.book_id==id).FirstOrDefault();
            _bookService.DeleteBook(book);
            _bookService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _bookService.GetBooks().Any(e => e.book_id == id);
        }
    }
}
