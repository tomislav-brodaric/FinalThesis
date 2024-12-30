using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class ProductGroupRepository(FinalThesisContext dbContext) : IRepository<ProductGroup>
{
    public async Task<IEnumerable<ProductGroup>> GetAllAsync()
        => await dbContext.ProductGroups.ToListAsync();

    public async Task<ProductGroup?> GetByIdAsync(int id)
        => await dbContext.ProductGroups.FirstOrDefaultAsync(pg => pg.IDProductGroup == id);

    public async Task AddAsync(ProductGroup productGroup)
    {
        await dbContext.ProductGroups.AddAsync(productGroup);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductGroup productGroup)
    {
        dbContext.ProductGroups.Update(productGroup);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var productGroup = await GetByIdAsync(id);
        if (productGroup != null)
        {
            dbContext.Products.RemoveRange(productGroup.Products);
            dbContext.ProductGroups.Remove(productGroup);
            await dbContext.SaveChangesAsync();
        }
    }
}