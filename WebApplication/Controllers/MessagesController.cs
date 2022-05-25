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
    public class MessagesController : Controller
    {
        private readonly MessageService _messageService;

        public MessagesController(MessageService messageService)
        {
            _messageService = messageService;
        }

        // GET: Messages
        public IActionResult Index()
        {
            var messages = _messageService.GetMessages();
            return View(messages);
        }

        // GET: Messages/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = _messageService.GetMessages().FirstOrDefault(m => m.message_id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            return View();
        }

        
        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("message_id,user_id,subject")] Message message)
        {
            if (ModelState.IsValid)
            {
                _messageService.AddMessage(message);
                _messageService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(message);
        }

        // GET: Messages/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = _messageService.GetMessages().FirstOrDefault(m=>m.message_id==id);
            if (message == null)
            {
                return NotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("message_id,user_id,subject")] Message message)
        {
            if (id != message.message_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _messageService.UpdateMessage(message);
                    _messageService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.message_id))
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
            return View(message);
        }

        // GET: Messages/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = _messageService.GetMessages().FirstOrDefault(m => m.message_id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var message = _messageService.GetMessagesByCondition(b=>b.message_id==id).FirstOrDefault();
            _messageService.DeleteMessage(message);
            _messageService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExists(int id)
        {
            return _messageService.GetMessages().Any(e => e.message_id == id);
        }
    }
}
