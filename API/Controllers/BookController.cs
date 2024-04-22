using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;
using Service.Models.Models;
using Service.Models.Payload.Requests.Book;
using Service.Models.Payload.Responses;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<OrderDetailModel>>>> GetAuthors([FromQuery] GetBooksRequest request)
        {
            var books = await _service.GetBooks(request);
            return Ok(Result<PaginatedList<OrderDetailModel>>.Succeed(books));
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Result<OrderDetailModel>>> GetAuthorById([FromRoute]int id)
        {
            var book = await _service.GetBookById(id);
            return Ok(Result<OrderDetailModel>.Succeed(book));
        }

        [HttpPost]
        public async Task<ActionResult<Result<OrderDetailModel>>> CreateMember([FromBody]CreateBookRequest request)
        {
            var book = await _service.CreateBook(request);
            return Ok(Result<OrderDetailModel>.Succeed(book));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Result<OrderDetailModel>>> UpdateMember([FromBody] UpdateBookRequest request, [FromRoute] int id)
        {
            var book = await _service.UpdateBook(id, request);
            return Ok(Result<OrderDetailModel>.Succeed(book));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Result<OrderDetailModel>>> DeleteMember([FromRoute] int id)
        {
            var book = await _service.DeleteBook(id);
            return Ok(Result<OrderDetailModel>.Succeed(book));
        }
    }
}
