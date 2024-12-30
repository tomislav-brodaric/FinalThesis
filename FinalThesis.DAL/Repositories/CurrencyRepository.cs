using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class CurrencyRepository(FinalThesisContext dbContext) : IRepository<Currency>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<Currency>> GetAllAsync()
        => await _dbContext.Currencies.Include(c => c.Countries).ToListAsync();

    public async Task<Currency?> GetByIdAsync(int id)
        => await _dbContext.Currencies.Include(c => c.Countries).FirstOrDefaultAsync(c => c.IDCurrency == id);

    public async Task AddAsync(Currency currency)
    {
        await _dbContext.Currencies.AddAsync(currency);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Currency currency)
    {
        _dbContext.Currencies.Update(currency);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var currency = await GetByIdAsync(id);
        if (currency != null)
        {
            _dbContext.Currencies.Remove(currency);
            await _dbContext.SaveChangesAsync();
        }
    }
}