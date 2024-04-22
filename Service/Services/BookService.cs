using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using Service.Extensions;
using Service.Interfaces;
using Service.Models;
using Service.Models.Models;
using Service.Models.Payload.Requests.Book;

namespace Service.Services;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Order> _bookRepository;
    private readonly IRepository<OrderDetail> _publisherRepository;
    
    private readonly IRepository<Product> _bookAuthorRepository;

    public BookService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _publisherRepository = _unitOfWork.GetRequiredRepository<OrderDetail>();
        _bookRepository = _unitOfWork.GetRequiredRepository<Order>();        
        _bookAuthorRepository = _unitOfWork.GetRequiredRepository<Product>();
    }

    public Task<PaginatedList<OrderDetailModel>> GetBooks(GetBooksRequest request)
    {
    //    var books = _bookRepository.GetAll()
    //        .Include(x => x.BookAuthors)
    //        .Include(x => x.Publisher)
    //        .AsQueryable();
        
    //    if (request.SearchTerm is not null)
    //    {
    //        books = books.Where(x => x.Title.Contains(request.SearchTerm));
    //    }

    //    if (request.Price > 0)
    //    {
    //        books.Where(x => x.Price == request.Price);
    //    }
        
    //    return books.ListPaginateWithSortAsync<Order, OrderDetailModel>(
    //        request.Page,
    //        request.Size,
    //        request.SortBy,
    //        request.SortOrder,
    //        _mapper.ConfigurationProvider
    //    );
        return null;
    }

    public async Task<OrderDetailModel> GetBookById(int id)
    {
        //var book = await _bookRepository.FindByCondition(x => x.Id == id).Include(x => x.BookAuthors)
        //    .Include(x => x.Publisher)
        //    .FirstOrDefaultAsync();
        //if (book is null)
        //{
        //    throw new KeyNotFoundException("Book does not exist!");
        //}

        //return _mapper.Map<OrderDetailModel>(book);
        return null;
    }

    public async Task<OrderDetailModel> CreateBook(CreateBookRequest request)
    {
        //var date = request.PublishedDate.ToDateTime("PublishedDate");
        //var publisher = await _publisherRepository.GetByIdAsync(request.PublisherId);
        //if (publisher is null)
        //{
        //    throw new KeyNotFoundException("Publisher does not exist!");
        //}

        //var bookAuthors = new List<Product>();

        //var exist = _bookRepository.GetAll().ToList().Count > 0;
        //var bookId = 1;
        //if (exist)
        //{
        //    bookId = _bookRepository.GetAll().Max(x => x.Id) + 1;
        //}

        //var book = new Order()
        //{
        //    Id = bookId,
        //    PublishedDate = date,
        //    Advance = request.Advance,
        //    Notes = request.Notes,
        //    Price = request.Price,
        //    Royalty = request.Royalty,
        //    Title = request.Title,
        //    Type = request.Type,
        //    ytdSales = request.ytdSales,
        //    PublisherId = request.PublisherId
        //};


        //await _bookRepository.AddAsync(book);

        //foreach (var id in request.AuthorIds)
        //{
        //    var author = await _authorRepository.GetByIdAsync(id);
        //    if (author is null)
        //    {
        //        throw new KeyNotFoundException("Author does not exist!");
        //    }

        //    var bookAuthor = new Product()
        //    {
        //        AuthorId = id,
        //        BookId = bookId,
        //        RoyaltyPercentage = request.Royalty,
        //        AuthorOrder = "Something"
        //    };

        //    await _bookAuthorRepository.AddAsync(bookAuthor);
        //}

        //await _unitOfWork.CommitAsync();

        //var result = await _bookRepository.FindByCondition(x => x.Id == bookId)
        //    .Include(x => x.BookAuthors)
        //    .Include(x => x.Publisher).FirstOrDefaultAsync();

        //return _mapper.Map<OrderDetailModel>(result);
        return null;
    }

    public async Task<OrderDetailModel> UpdateBook(int id, UpdateBookRequest request)
    {
        //var book = await _bookRepository.GetByIdAsync(id);
        //if (book is null)
        //{
        //    throw new KeyNotFoundException("Book does not exist!");
        //}

        //book.Title = request.Title;
        //book.Type = request.Type;
        //book.Price = request.Price;
        //book.Advance = request.Advance;
        //book.Royalty = request.Royalty;
        //book.Notes = request.Notes;

        //var result = _bookRepository.Update(book);
        //await _unitOfWork.CommitAsync();

        //return _mapper.Map<OrderDetailModel>(result);
        return null;
    }

    public async Task<OrderDetailModel> DeleteBook(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book is null)
        {
            throw new KeyNotFoundException("Book does not exist");
        }

        var result = _bookRepository.Remove(id);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<OrderDetailModel>(result);
    }
}