using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class ProductTypeRepository(FinalThesisContext dbContext) : IRepository<ProductType>
{
    public async Task<IEnumerable<ProductType>> GetAllAsync()
        => await dbContext.ProductTypes.ToListAsync();

    public async Task<ProductType?> GetByIdAsync(int id)
        => await dbContext.ProductTypes.FirstOrDefaultAsync(p => p.IDProductType == id);

    public async Task AddAsync(ProductType productType)
    {
        await dbContext.ProductTypes.AddAsync(productType);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductType productType)
    {
        dbContext.ProductTypes.Update(productType);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var productType = await GetByIdAsync(id);
        if (productType != null)
        {
            dbContext.ProductTypes.Remove(productType);
            await dbContext.SaveChangesAsync();
        }
    }
}
