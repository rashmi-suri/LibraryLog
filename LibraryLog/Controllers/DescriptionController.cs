using LibraryLog.Models;
using LibraryLog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryLog.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5066/desc
    public class DescriptionController : ControllerBase
    {
        private readonly ICrudService<BookDescription, int> _DescriptionService;
        public DescriptionController(ICrudService<BookDescription, int> DescriptionService)
        {
            _DescriptionService = DescriptionService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<BookDescription>> GetAll() => _DescriptionService.GetAll().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<BookDescription> Get(int id)
        {
            var desc = _DescriptionService.Get(id);
            if (desc is null) return NotFound();
            else return desc;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(BookDescription desc)
        {
            // Runs validation against model using data validation attributes
            if (ModelState.IsValid)
            {
                _DescriptionService.Add(desc);
                return CreatedAtAction(nameof(Create), new { id = desc.Id }, desc);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, BookDescription desc)
        {
            var existingBookDescription = _DescriptionService.Get(id);
            if (existingBookDescription is null || existingBookDescription.Id != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _DescriptionService.Update(existingBookDescription, desc);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var desc = _DescriptionService.Get(id);
            if (desc is null) return NotFound();
            _DescriptionService.Delete(id);
            return NoContent();
        }
    }

}
