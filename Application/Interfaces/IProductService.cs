using Application.DTOs;

namespace Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync(int pageNumber, int pageSize);
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto);
    Task<ProductDto> UpdateProductAsync(UpdateProductDto updateProductDto);
    Task<ProductDto?> DeleteProductAsync(int id);
}