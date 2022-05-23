using LibraryLog.Models;
using LibraryLog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryLog.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5066/book
    public class BookController : ControllerBase
    {
        private readonly ICrudService<Book, int> _BookService;
        public BookController(ICrudService<Book, int> bookService)
        {
            _BookService = bookService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<Book>> GetAll() => _BookService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var todo = _BookService.Get(id);
            if (todo is null) return NotFound();
            else return todo;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Book todo)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _BookService.Add(todo);
                return CreatedAtAction(nameof(Create), new { id = todo.Id }, todo);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Book todo)
        {
            var existingBook = _BookService.Get(id);
            if (existingBook is null || existingBook.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _BookService.Update(existingBook, todo);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _BookService.Get(id);
            if (todo is null) return NotFound();
            _BookService.Delete(id);
            return NoContent();
        }
    }

}
