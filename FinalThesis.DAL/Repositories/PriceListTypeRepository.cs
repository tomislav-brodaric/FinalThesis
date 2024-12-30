using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class PriceListTypeRepository(FinalThesisContext dbContext) : IRepository<PriceListType>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<PriceListType>> GetAllAsync()
        => await _dbContext.PriceListTypes.ToListAsync();

    public async Task<PriceListType?> GetByIdAsync(int id)
        => await _dbContext.PriceListTypes.FirstOrDefaultAsync(pt => pt.IDPriceListType == id);

    public async Task AddAsync(PriceListType priceListType)
    {
        await _dbContext.PriceListTypes.AddAsync(priceListType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(PriceListType priceListType)
    {
        _dbContext.PriceListTypes.Update(priceListType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var priceListType = await GetByIdAsync(id);
        if (priceListType != null)
        {
            _dbContext.PriceListTypes.Remove(priceListType);
            await _dbContext.SaveChangesAsync();
        }
    }
}
