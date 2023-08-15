using InMemoryDB.Service;
using InMemoryDB.Service.dto;
using Microsoft.AspNetCore.Mvc;

namespace InMemoryDB.Controller
{
    [ApiController]
    [Route("/api/authors", Name = "Autor")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public ActionResult<List<AuthorDTO>> GetAll()
        {
            return Ok(_authorService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<AuthorDTO> GetById(int id)
        {
            return Ok(_authorService.GetById(id));
        }

        [HttpPost]
        public ActionResult<AuthorDTO> Create(AuthorDTO data)
        {
            return new ObjectResult(_authorService.Create(data)) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut("{id}")]
        public ActionResult<AuthorDTO> Update(int id, AuthorDTO data)
        {
            return Ok(_authorService.Update(id, data));
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authorService.Delete(id);
            return NoContent();
        }
    }
}