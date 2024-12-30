using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class PartnerPriceListRepository(FinalThesisContext dbContext) : IRepository<PartnerPriceList>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<PartnerPriceList>> GetAllAsync()
        => await _dbContext.PartnerPriceLists
            .Include(p => p.Partner)
            .Include(p => p.PriceListType)
            .ToListAsync();

    public async Task<PartnerPriceList?> GetByIdAsync(int id)
        => await _dbContext.PartnerPriceLists
            .Include(p => p.Partner)
            .Include(p => p.PriceListType)
            .FirstOrDefaultAsync(p => p.IDPriceList == id);

    public async Task AddAsync(PartnerPriceList partnerPriceList)
    {
        await _dbContext.PartnerPriceLists.AddAsync(partnerPriceList);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(PartnerPriceList partnerPriceList)
    {
        _dbContext.PartnerPriceLists.Update(partnerPriceList);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var partnerPriceList = await GetByIdAsync(id);
        if (partnerPriceList != null)
        {
            _dbContext.PartnerPriceLists.Remove(partnerPriceList);
            await _dbContext.SaveChangesAsync();
        }
    }
}
