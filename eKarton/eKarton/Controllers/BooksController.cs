using eKarton.Services;
using eKarton.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKarton.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class BooksController : ControllerBase
        {
            private readonly BookService _bookService;

            public BooksController(BookService bookService)
            {
                _bookService = bookService;
            }

            [HttpGet]
            public ActionResult<List<Book>> Get() =>
                _bookService.Get();

            [HttpGet("{id:length(24)}", Name = "GetBook")]
            public ActionResult<Book> Get(string id)
            {
                var book = _bookService.Get(id);

                if (book == null)
                {
                    return NotFound();
                }

                return book;
            }

            [HttpPost]
            public ActionResult<Book> Create(Book book)
            {
            Book book1 = new Book();
            book1.Author = "sdsadsa";
            book1.BookName = "sdsadsa";
            book1.Category = "sdsad";
            book1.Id = "321";
            book1.Price = 34.22M;
            

                _bookService.Create(book1);

                return CreatedAtRoute("GetBook", new { id = book1.Id.ToString() }, book1);
            }

            [HttpPut("{id:length(24)}")]
            public IActionResult Update(string id, Book bookIn)
            {
                var book = _bookService.Get(id);

                if (book == null)
                {
                    return NotFound();
                }

                _bookService.Update(id, bookIn);

                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            public IActionResult Delete(string id)
            {
                var book = _bookService.Get(id);

                if (book == null)
                {
                    return NotFound();
                }

                _bookService.Remove(book.Id);

                return NoContent();
            }
        }
}

