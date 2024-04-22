using Service.Models;
using Service.Models.Models;
using Service.Models.Payload.Requests.Book;
using Service.Models.Payload.Requests.Publisher;

namespace Service.Interfaces;

public interface IPublisherService
{
    Task<PaginatedList<ProductModel>> GetPublishers(GetPublisherRequest request);
    Task<ProductModel> GetPublisherById(int id);
    Task<ProductModel> CreatePublisher(CreatePublisherRequest request);
    Task<ProductModel> UpdatePublisher(int id, UpdatePublisherRequest request);
    Task<ProductModel> DeletePublisher(int id);
}