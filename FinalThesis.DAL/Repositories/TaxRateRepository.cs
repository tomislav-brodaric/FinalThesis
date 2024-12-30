using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class TaxRateRepository(FinalThesisContext dbContext) : IRepository<TaxRate>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<TaxRate>> GetAllAsync()
        => await _dbContext.TaxRates.Include(tr => tr.TaxNumbers).ToListAsync();

    public async Task<TaxRate?> GetByIdAsync(int id)
        => await _dbContext.TaxRates.Include(tr => tr.TaxNumbers).FirstOrDefaultAsync(t => t.IDTaxRate == id);

    public async Task AddAsync(TaxRate taxRate)
    {
        await _dbContext.TaxRates.AddAsync(taxRate);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaxRate taxRate)
    {
        _dbContext.TaxRates.Update(taxRate);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var taxRate = await GetByIdAsync(id);
        if (taxRate != null)
        {
            _dbContext.TaxRates.Remove(taxRate);
            await _dbContext.SaveChangesAsync();
        }
    }
}