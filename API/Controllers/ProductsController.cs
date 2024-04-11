using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;
using Service.Models.Dtos;
using Service.Models.Payload.Requests.Products;
using Service.Models.Payload.Responses;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<ProductDto>>>> GetProducts([FromQuery]GetProductsRequest request)
        {
            var products = await _service.GetProducts(request);
            return Ok(Result<PaginatedList<ProductDto>>.Succeed(products));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Result<ProductDto>>> GetProductById([FromRoute]int id)
        {
            var product = await _service.GetProductById(id);
            return Ok(Result<ProductDto>.Succeed(product));
        }

        [HttpPost]
        public async Task<ActionResult<Result<ProductDto>>> CreateProduct([FromBody]CreateProductRequest request)
        {
            var product = await _service.CreateProduct(request);
            return Ok(Result<ProductDto>.Succeed(product));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Result<ProductDto>>> UpdateProduct([FromBody] UpdateProductRequest request, [FromRoute] int id)
        {
            var product = await _service.UpdateProduct(id, request);
            return Ok(Result<ProductDto>.Succeed(product));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Result<ProductDto>>> DeleteProduct([FromRoute] int id)
        {
            var product = await _service.DeleteProduct(id);
            return Ok(Result<ProductDto>.Succeed(product));
        }
    }
}
