using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;
using Service.Models.Models;
using Service.Models.Payload.Requests.Publisher;
using Service.Models.Payload.Responses;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _service;

        public PublisherController(IPublisherService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<ProductModel>>>> GetAuthors([FromQuery] GetPublisherRequest request)
        {
            var publishers = await _service.GetPublishers(request);
            return Ok(Result<PaginatedList<ProductModel>>.Succeed(publishers));
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Result<ProductModel>>> GetAuthorById([FromRoute]int id)
        {
            var publisher = await _service.GetPublisherById(id);
            return Ok(Result<ProductModel>.Succeed(publisher));
        }

        [HttpPost]
        public async Task<ActionResult<Result<ProductModel>>> CreateMember([FromBody]CreatePublisherRequest request)
        {
            var publisher = await _service.CreatePublisher(request);
            return Ok(Result<ProductModel>.Succeed(publisher));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Result<ProductModel>>> UpdateMember([FromBody] UpdatePublisherRequest request, [FromRoute] int id)
        {
            var publisher = await _service.UpdatePublisher(id, request);
            return Ok(Result<ProductModel>.Succeed(publisher));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Result<ProductModel>>> DeleteMember([FromRoute] int id)
        {
            var publisher = await _service.DeletePublisher(id);
            return Ok(Result<ProductModel>.Succeed(publisher));
        }
    }
}
