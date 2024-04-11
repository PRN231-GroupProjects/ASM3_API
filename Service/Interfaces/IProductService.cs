using Service.Models;
using Service.Models.Dtos;
using Service.Models.Payload.Requests.Products;

namespace Service.Interfaces;

public interface IProductService
{
    Task<PaginatedList<ProductDto>> GetProducts(GetProductsRequest request);
    Task<ProductDto> GetProductById(int id);
    Task<ProductDto> CreateProduct(CreateProductRequest request);
    Task<ProductDto> UpdateProduct(int id, UpdateProductRequest request);
    Task<ProductDto> DeleteProduct(int id);
    
}