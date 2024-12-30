using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

public class OfferProductRepository(FinalThesisContext dbContext) : IRepository<OfferProduct>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<OfferProduct>> GetAllAsync()
        => await _dbContext.OfferProducts.Include(op => op.Offer)
                                         .Include(op => op.Product)
                                         .ToListAsync();

    public async Task<OfferProduct?> GetByIdAsync(int id)
        => await _dbContext.OfferProducts.Include(op => op.Offer)
                                         .Include(op => op.Product)
                                         .FirstOrDefaultAsync(op => op.IDOfferProduct == id);

    public async Task AddAsync(OfferProduct offerProduct)
    {
        await _dbContext.OfferProducts.AddAsync(offerProduct);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(OfferProduct offerProduct)
    {
        _dbContext.OfferProducts.Update(offerProduct);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var offerProduct = await GetByIdAsync(id);
        if (offerProduct != null)
        {
            _dbContext.OfferProducts.Remove(offerProduct);
            await _dbContext.SaveChangesAsync();
        }
    }
}