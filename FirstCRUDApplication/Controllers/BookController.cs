﻿using FirstCRUDApplication.DbEntities;
using FirstCRUDApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstCRUDApplication.Controllers
{
    public class BookController : Controller
    {
        private CoffeeContext context;

        public BookController(CoffeeContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<BookViewModel> model = new List<BookViewModel>
            {
                {
                    new BookViewModel{Author = "test", Id = 1, ISBN = "test", Name = "test", Publisher = "test"}
                },
                {
                    new BookViewModel{Author = "test2", Id = 2, ISBN = "test2", Name = "test2", Publisher = "test2"}
                }
            };

            return View("Index", model);
        }

        [HttpGet]
        public IActionResult AddEditBook(long? id)
        {
            BookViewModel model = new BookViewModel();
            if (id.HasValue)
            {
                Book book = context.Set<Book>().SingleOrDefault(c => c.Id == id.Value);
                if (book != null)
                {
                    model.Id = book.Id;
                    model.Name = book.Name;
                    model.ISBN = book.ISBN;
                    model.Author = book.Author;
                    model.Publisher = book.Publisher;
                }
            }
            return PartialView("~/Views/Book/_AddEditBook.cshtml", model);
        }

        [HttpPost]
        public IActionResult AddEditBook(long? id, BookViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Book book = isNew ? new Book
                    {
                        AddedDate = DateTime.UtcNow
                    } : context.Set<Book>().SingleOrDefault(s => s.Id == id.Value);
                    book.Name = model.Name;
                    book.ISBN = model.ISBN;
                    book.Author = model.Author;
                    book.Publisher = model.Publisher;
                    if (isNew)
                    {
                        context.Add(book);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteBook(long id)
        {
            Book book = context.Set<Book>().SingleOrDefault(c => c.Id == id);
            string bookName = book.Name;
            return PartialView("~/Views/Book/_DeleteBook.cshtml", model: bookName);
        }
        [HttpPost]
        public IActionResult DeleteBook(long id, IFormCollection form)
        {
            Book book = context.Set<Book>().SingleOrDefault(c => c.Id == id);
            context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
