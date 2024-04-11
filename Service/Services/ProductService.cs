using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using Service.Extensions;
using Service.Interfaces;
using Service.Models;
using Service.Models.Dtos;
using Service.Models.Payload.Requests.Products;

namespace Service.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Product> _productRepository;

    public ProductService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
        _categoryRepository = _uow.GetRequiredRepository<Category>();
        _productRepository = _uow.GetRequiredRepository<Product>();
    }

    public async Task<PaginatedList<ProductDto>> GetProducts(GetProductsRequest request)
    {
        var products = _productRepository
            .GetAll()
            .Include(x => x.Category)
            .AsQueryable();

        if (request.SearchTerm is not null)
        {
            products = products.Where(x => x.ProductName.Contains(request.SearchTerm));
        }

        return await products
            .ListPaginateWithSortAsync<Product, ProductDto>(
                request.Page, 
                request.Size, 
                request.SortBy, 
                request.SortOrder, 
                _mapper.ConfigurationProvider);
    }

    public async Task<ProductDto> GetProductById(int id)
    {
        var product = await _productRepository.FindByCondition(x => x.Id == id)
            .Include(x => x.Category)
            .FirstOrDefaultAsync();

        if (product is null)
        {
            throw new KeyNotFoundException("Product does not exist!");
        }

        var result = _mapper.Map<ProductDto>(product);
        return result;
    }

    public async Task<ProductDto> CreateProduct(CreateProductRequest request)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        if (category is null)
        {
            throw new KeyNotFoundException("Category does not exist!");
        }

        var product = await _productRepository.FindByCondition(x => x.ProductName == request.ProductName)
            .FirstOrDefaultAsync();
        if (product is not null)
        {
            throw new InvalidOperationException("Name already exist!");
        }

        if (request.Weight < 0)
        {
            throw new InvalidOperationException("Weight cannot negative!");
        }
        
        if (request.UnitPrice < 0)
        {
            throw new InvalidOperationException("Unit price cannot negative!");
        }
        
        if (request.UnitInStock < 0)
        {
            throw new InvalidOperationException("Unit in stock cannot negative!");
        }

        var entity = new Product()
        {
            ProductName = request.ProductName,
            Weight = request.Weight,
            CategoryId = request.CategoryId,
            UnitPrice = request.UnitPrice,
            UnitInStock = request.UnitInStock
        };

        var result = await _productRepository.AddAsync(entity);
        await _uow.CommitAsync();

        return _mapper.Map<ProductDto>(result);
    }

    public async Task<ProductDto> UpdateProduct(int id, UpdateProductRequest request)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
        {
            throw new KeyNotFoundException("Product does not exist!");
        }
        
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
        if (category is null)
        {
            throw new KeyNotFoundException("Category does not exist!");
        }

        var existedProduct = await _productRepository.FindByCondition(x => x.ProductName == request.ProductName)
            .FirstOrDefaultAsync();

        if (existedProduct is not null)
        {
            throw new InvalidOperationException("Product name already exist");
        }
        
        if (request.Weight < 0)
        {
            throw new InvalidOperationException("Weight cannot negative!");
        }
        
        if (request.UnitPrice < 0)
        {
            throw new InvalidOperationException("Unit price cannot negative!");
        }
        
        if (request.UnitInStock < 0)
        {
            throw new InvalidOperationException("Unit in stock cannot negative!");
        }

        product.CategoryId = request.CategoryId;
        product.ProductName = request.ProductName;
        product.Weight = request.Weight;
        product.UnitPrice = request.UnitPrice;
        product.UnitInStock = request.UnitInStock;

        var result = _productRepository.Update(product);
        await _uow.CommitAsync();

        return _mapper.Map<ProductDto>(result);
    }

    public async Task<ProductDto> DeleteProduct(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
        {
            throw new KeyNotFoundException("Product already exist!");
        }

        var result = _productRepository.Remove(id);
        await _uow.CommitAsync();

        return _mapper.Map<ProductDto>(result);
    }
}