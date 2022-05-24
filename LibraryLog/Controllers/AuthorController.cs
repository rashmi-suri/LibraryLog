using LibraryLog.Models;
using LibraryLog.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]//URL: http://localhost:5066/auth
public class AuthorController : ControllerBase
{
    private readonly ICrudService<Author, int> _AuthorService;
    public AuthorController(ICrudService<Author, int> AuthorService)
    {
        _AuthorService = AuthorService;
    }

    // GET all action
    [HttpGet] // auto returns data with a Content-Type of application/json
    public ActionResult<List<Author>> GetAll() => _AuthorService.GetAll().ToList();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Author> Get(int id)
    {
        var auth = _AuthorService.Get(id);
        if (auth is null) return NotFound();
        else return auth;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Author auth)
    {
        // Runs validation against model using data validation attributes
        if (ModelState.IsValid)
        {
            _AuthorService.Add(auth);
            return CreatedAtAction(nameof(Create), new { id = auth.Id }, auth);
        }
        return BadRequest();
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Author auth)
    {
        var existingAuthor = _AuthorService.Get(id);
        if (existingAuthor is null || existingAuthor.Id != id)
        {
            return BadRequest();
        }
        if (ModelState.IsValid)
        {
            _AuthorService.Update(existingAuthor, auth);
            return NoContent();
        }
        return BadRequest();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var auth = _AuthorService.Get(id);
        if (auth is null) return NotFound();
        _AuthorService.Delete(id);
        return NoContent();
    }
}
