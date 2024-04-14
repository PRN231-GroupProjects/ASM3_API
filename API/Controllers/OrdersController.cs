using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;
using Service.Models.Dtos;
using Service.Models.Payload.Requests.Order;
using Service.Models.Payload.Responses;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<OrderDto>>>> GetMembers([FromQuery]GetOrdersRequest request)
        {
            var products = await _service.GetOrders(request);
            return Ok(Result<PaginatedList<OrderDto>>.Succeed(products));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Result<OrderDto>>> GetMemberById([FromRoute]int id)
        {
            var product = await _service.GetOrderById(id);
            return Ok(Result<OrderDto>.Succeed(product));
        }

        [HttpPost]
        [Role(Role = 1)]
        public async Task<ActionResult<Result<OrderDto>>> CreateMember([FromBody]CreateOrderRequest request)
        {
            var product = await _service.CreateOrder(request);
            return Ok(Result<OrderDto>.Succeed(product));
        }

        [HttpPut("{id:int}")]
        [Role(Role = 1)]
        public async Task<ActionResult<Result<OrderDto>>> UpdateMember([FromBody] UpdateOrderRequest request, [FromRoute] int id)
        {
            var product = await _service.UpdateOrder(id, request);
            return Ok(Result<OrderDto>.Succeed(product));
        }

        [HttpDelete("{id:int}")]
        [Role(Role = 1)]
        public async Task<ActionResult<Result<OrderDto>>> DeleteMember([FromRoute] int id)
        {
            var product = await _service.DeleteOrder(id);
            return Ok(Result<OrderDto>.Succeed(product));
        }
    }
}
