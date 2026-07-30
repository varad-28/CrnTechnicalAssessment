using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(int pageNumber, int pageSize)
    {
        var products = await _repository.GetAllAsync(pageNumber, pageSize);

        return products.Select(p => new ProductDto
        {
            Id = p.Id,
            ProductName = p.ProductName,
            CreatedBy = p.CreatedBy,
            CreatedOn = p.CreatedOn
        }).ToList();
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null)
            return null;

        return new ProductDto
        {
            Id = product.Id,
            ProductName = product.ProductName,
            CreatedBy = product.CreatedBy,
            CreatedOn = product.CreatedOn
        };
    }

    public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto)
    {
        var product = new Product
        {
            ProductName = createProductDto.ProductName,
            CreatedBy = createProductDto.CreatedBy,
            CreatedOn = DateTime.UtcNow
        };

        var createdProduct = await _repository.AddAsync(product);

        return new ProductDto
        {
            Id = createdProduct.Id,
            ProductName = createdProduct.ProductName,
            CreatedBy = createdProduct.CreatedBy,
            CreatedOn = createdProduct.CreatedOn
        };
    }

    public async Task<ProductDto> UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var existingProduct = await _repository.GetByIdAsync(updateProductDto.Id);

        if (existingProduct == null)
            throw new Exception("Product not found.");

        existingProduct.ProductName = updateProductDto.ProductName;
        existingProduct.ModifiedBy = updateProductDto.ModifiedBy;
        existingProduct.ModifiedOn = DateTime.UtcNow;

        var updatedProduct = await _repository.UpdateAsync(existingProduct);

        return new ProductDto
        {
            Id = updatedProduct.Id,
            ProductName = updatedProduct.ProductName,
            CreatedBy = updatedProduct.CreatedBy,
            CreatedOn = updatedProduct.CreatedOn
        };
    }

    public async Task<ProductDto?> DeleteProductAsync(int id)
    {
        var deletedProduct = await _repository.DeleteAsync(id);

        if (deletedProduct == null)
            return null;

        return new ProductDto
        {
            Id = deletedProduct.Id,
            ProductName = deletedProduct.ProductName,
            CreatedBy = deletedProduct.CreatedBy,
            CreatedOn = deletedProduct.CreatedOn
        };
    }
}