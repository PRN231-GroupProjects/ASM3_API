using Service.Models;
using Service.Models.Dtos;
using Service.Models.Payload.Requests.Member;
using Service.Models.Payload.Requests.Order;

namespace Service.Interfaces;

public interface IOrderService
{
    Task<PaginatedList<OrderDto>> GetOrders(GetOrdersRequest request);
    Task<OrderDto> GetOrderById(int id);
    Task<OrderDto> CreateOrder(CreateOrderRequest request);
    Task<OrderDto> UpdateOrder(int id, UpdateOrderRequest request);
    Task<OrderDto> DeleteOrder(int id);
}