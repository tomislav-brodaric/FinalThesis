using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class ProductRepository(FinalThesisContext dbContext) : IRepository<Product>
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    => await dbContext.Products.ToListAsync();

    public async Task<Product?> GetByIdAsync(int id)
        => await dbContext.Products.FirstOrDefaultAsync(p => p.IDProduct == id);

    public async Task AddAsync(Product product)
    {
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await GetByIdAsync(id);
        if (product != null)
        {
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<bool> DoesProductExistAsync(int productId)
    {
        return await dbContext.Products.AnyAsync(p => p.IDProduct == productId);
    }

}