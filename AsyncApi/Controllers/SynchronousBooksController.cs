using AsyncApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AsyncApi.Controllers
{
    [ApiController]
    [Route("api/synchronousbooks")]
    public class SynchronousBooksController: ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public SynchronousBooksController(IBooksRepository booksRepository) =>
            _booksRepository = booksRepository ?? throw new ArgumentNullException(nameof(booksRepository));

        [HttpGet]
        public IActionResult GetBooks()
        {
            var bookEntities = _booksRepository.GetBooks();
            return Ok(bookEntities);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(Guid id)
        {
            var bookEntity = _booksRepository.GetBook(id);
            if (bookEntity == null)
            {
                return NotFound();
            }

            return Ok(bookEntity);
        }
    }
}
