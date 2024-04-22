using Service.Models;
using Service.Models.Models;
using Service.Models.Payload.Requests.Book;

namespace Service.Interfaces;

public interface IBookService
{
    Task<PaginatedList<OrderDetailModel>> GetBooks(GetBooksRequest request);
    Task<OrderDetailModel> GetBookById(int id);
    Task<OrderDetailModel> CreateBook(CreateBookRequest request);
    Task<OrderDetailModel> UpdateBook(int id, UpdateBookRequest request);
    Task<OrderDetailModel> DeleteBook(int id);
}