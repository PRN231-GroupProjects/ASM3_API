using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using Service.Extensions;
using Service.Interfaces;
using Service.Models;
using Service.Models.Models;
using Service.Models.Payload.Requests.Publisher;

namespace Service.Services;

public class PublisherService : IPublisherService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<OrderDetail> _publisherRepository;
    private readonly IMapper _mapper;

    public PublisherService(IUnitOfWork uow, IRepository<OrderDetail> publisherRepository, IMapper mapper)
    {
        _uow = uow;
        _publisherRepository = _uow.GetRequiredRepository<OrderDetail>();
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductModel>> GetPublishers(GetPublisherRequest request)
    {
        //var publishers = _publisherRepository.GetAll().Include(x => x.Books).AsQueryable();

        //return await publishers.ListPaginateWithSortAsync<OrderDetail, ProductModel>(
        //    request.Page,
        //    request.Size,
        //    request.SortBy,
        //    request.SortOrder,
        //    _mapper.ConfigurationProvider
        //);
        return null;
    }

    public async Task<ProductModel> GetPublisherById(int id)
    {
        //var publisher = await _publisherRepository
        //    .FindByCondition(x => x.Id == id)
        //    .Include(x => x.Books).FirstOrDefaultAsync();

        //if (publisher is null)
        //{
        //    throw new KeyNotFoundException("Publisher does not exist!");
        //}

        //return _mapper.Map<ProductModel>(publisher);
        return null;
    }

    public async Task<ProductModel> CreatePublisher(CreatePublisherRequest request)
    {
        //var entity = new OrderDetail()
        //{
        //    City = request.City,
        //    Country = request.Country,
        //    State = request.State,
        //    Name = request.Name,
        //};

        //var result = await _publisherRepository.AddAsync(entity);
        //await _uow.CommitAsync();

        //return _mapper.Map<ProductModel>(result);
        return null;
    }

    public async Task<ProductModel> UpdatePublisher(int id, UpdatePublisherRequest request)
    {
        //var publisher = await _publisherRepository.GetByIdAsync(id);
        //if (publisher is null)
        //{
        //    throw new KeyNotFoundException("Publisher does not exist!");
        //}

        //publisher.City = request.City;
        //publisher.Country = request.Country;
        //publisher.State = request.State;
        //publisher.Name = request.Name;

        //var result = _publisherRepository.Update(publisher);
        //await _uow.CommitAsync();

        //return _mapper.Map<ProductModel>(result);
        return null;
    }

    public async Task<ProductModel> DeletePublisher(int id)
    {
        //var publisher = await _publisherRepository.GetByIdAsync(id);
        //if (publisher is null)
        //{
        //    throw new KeyNotFoundException("Publisher does not exists");
        //}

        //var result = _publisherRepository.Remove(id);
        //await _uow.CommitAsync();

        //return _mapper.Map<ProductModel>(result);
        return null;
    }
}