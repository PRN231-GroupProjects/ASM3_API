using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using Service.Extensions;
using Service.Interfaces;
using Service.Models;
using Service.Models.Dtos;
using Service.Models.Payload.Requests.Order;

namespace Service.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<Member> _memberRepository;
    private readonly IRepository<Order> _orderRepository;
    private readonly IRepository<OrderDetail> _orderDetailRepository;
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _memberRepository = _uow.GetRequiredRepository<Member>();
        _orderRepository = _uow.GetRequiredRepository<Order>();
        _orderDetailRepository = _uow.GetRequiredRepository<OrderDetail>();
        _productRepository = _uow.GetRequiredRepository<Product>();
        _mapper = mapper;
    }

    public async Task<PaginatedList<OrderDto>> GetOrders(GetOrdersRequest request)
    {
        var orders = _orderRepository.GetAll()
            .Include(x => x.Member)
            .Include(x => x.OrderDetails)
            .ThenInclude(x => x.Product)
            .ThenInclude(x => x.Category)
            .AsQueryable();

        return await orders.ListPaginateWithSortAsync<Order, OrderDto>(
            request.Page, 
            request.Size, 
            request.SortBy,
            request.SortOrder, 
            _mapper.ConfigurationProvider);
    }

    public async Task<OrderDto> GetOrderById(int id)
    {
        var order = await _orderRepository.FindByCondition(x => x.Id == id)
            .Include(x => x.Member)
            .Include(x => x.OrderDetails)
            .ThenInclude(x => x.Product)
            .ThenInclude(x => x.Category)
            .FirstOrDefaultAsync();

        if (order is null)
        {
            throw new KeyNotFoundException("Order does not exist!");
        }

        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> CreateOrder(CreateOrderRequest request)
    {
        var requiredDate = request.RequiredDate.ToDateTime("RequiredDate");
        var shippedDate = request.ShippedDate.ToDateTime("ShippedDate");

        var member = await _memberRepository.GetByIdAsync(request.MemberId);
        if (member is null)
        {
            throw new KeyNotFoundException("Member does not exist!");
        }

        var product = await _productRepository.GetByIdAsync(request.ProductId);
        if (product is null)
        {
            throw new KeyNotFoundException("Product does not exist");
        }

        var exist = _orderRepository.GetAll().ToList().Count > 0;
        var id = 1;
        if (exist)
        {
            id = _orderRepository.GetAll().Max(x => x.Id) + 1;
        }

        var order = new Order
        {
            OrderDate = DateTime.Now,
            RequiredDate = requiredDate,
            ShippedDate = shippedDate,
            MemberId = member.Id,
            Freight = request.Freight,
            Id = id
        };
        
        var orderDetail = new OrderDetail
        {
            ProductId = product.Id,
            Discount = request.Discount,
            UnitPrice = request.UnitPrice,
            Quantity = request.Quantity,
            OrderId = order.Id,
        };
        
        var result  = await _orderRepository.AddAsync(order);
        await _orderDetailRepository.AddAsync(orderDetail);
        await _uow.CommitAsync();
        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> UpdateOrder(int id, UpdateOrderRequest request)
    {
        var order = await _orderRepository.FindByCondition(x => x.Id == id)
            .Include(x => x.Member)
            .Include(x => x.OrderDetails)
            .ThenInclude(x => x.Product)
            .ThenInclude(x => x.Category)
            .FirstOrDefaultAsync();

        if (order is null)
        {
            throw new KeyNotFoundException("Order does not exist");
        }

        var orderDetail = order.OrderDetails.FirstOrDefault(x => x.Id == request.OrderDetailId);
        if (orderDetail is null)
        {
            throw new KeyNotFoundException("Order detail does not exist!");
        }

        if (orderDetail.ProductId != request.ProductId)
        {
            throw new InvalidOperationException("Product id is not the same!");
        }

        if (order.MemberId != request.MemberId)
        {
            throw new InvalidOperationException("Unauthorized");
        }
        
        var requiredDate = request.RequiredDate.ToDateTime("RequiredDate");
        var shippedDate = request.ShippedDate.ToDateTime("ShippedDate");

        order.RequiredDate = requiredDate;
        order.ShippedDate = shippedDate;
        order.Freight = request.Freight;
        
        orderDetail.Discount = request.Discount;
        orderDetail.Quantity = request.Quantity;
        orderDetail.UnitPrice = request.UnitPrice;

        var result = _orderRepository.Update(order);
        _orderDetailRepository.Update(orderDetail);
        await _uow.CommitAsync();

        return _mapper.Map<OrderDto>(order);
    }

    public async Task<OrderDto> DeleteOrder(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order is null)
        {
            throw new KeyNotFoundException("Order does not exist");
        }

        var result = _orderRepository.Remove(id);
        await _uow.CommitAsync();
        return _mapper.Map<OrderDto>(result);
    }
}