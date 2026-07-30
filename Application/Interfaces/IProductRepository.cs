using Domain.Entities;

namespace Application.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize);
    Task<Product?> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task<Product?> DeleteAsync(int id);
}