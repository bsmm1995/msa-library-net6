using InMemoryDB.Service;
using InMemoryDB.Service.dto;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryDB.Controller
{
    [ApiController]
    [Route("/api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<List<BookDTO>> GetAll()
        {
            return Ok(_bookService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<BookDTO> GetById(int id)
        {
            return Ok(_bookService.GetById(id));
        }

        [HttpPost]
        public ActionResult<BookDTO> Create(BookDTO data)
        {
            return new ObjectResult(_bookService.Create(data)) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut("{id}")]
        public ActionResult<BookDTO> Update(int id, BookDTO data)
        {
            return Ok(_bookService.Update(id, data));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}