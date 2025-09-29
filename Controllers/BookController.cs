using System.Threading.Tasks;
using AutoMapper;
using BAUST_Book_Store.Models.Domain;
using BAUST_Book_Store.Models.Dtos;
using BAUST_Book_Store.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BAUST_Book_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository repository;
        private readonly IMapper mapper;

        public BookController(IBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var booksDomain = await repository.GetAllBookAsync();
            var booksDto = mapper.Map<List<BookDto>>(booksDomain);
            return Ok(booksDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var bookDomain = await repository.GetBookByIdAsync(id);
            var bookDto = mapper.Map<BookDto>(bookDomain);
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto newBook)
        {
            var bookDomain = mapper.Map<Book>(newBook);
            bookDomain = await repository.CreateBookAsync(bookDomain);
            var bookDto = mapper.Map<BookDto>(bookDomain);
            return CreatedAtAction(nameof(GetBookById), new { id = bookDomain.Id }, bookDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] UpdateBookDto updateBook)
        {
            var bookDomain = mapper.Map<Book>(updateBook);
            bookDomain = await repository.UpdateBookAsync(id, bookDomain);
            if (bookDomain is null)
            {
                return NotFound();
            }
            var bookDto = mapper.Map<BookDto>(bookDomain);
            return CreatedAtAction(nameof(GetBookById), new { id = bookDomain.Id }, bookDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            try
            {
                await repository.DeleteBookByIdAsync(id);
                return NoContent(); // 204
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // 404
            }
        }

    }


}
