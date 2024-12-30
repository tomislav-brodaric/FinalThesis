using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class TaxNumberRepository(FinalThesisContext dbContext)  : IRepository<TaxNumber>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<TaxNumber>> GetAllAsync()
        => await _dbContext.TaxNumbers.Include(tn => tn.TaxRate).ToListAsync();

    public async Task<TaxNumber?> GetByIdAsync(int id)
        => await _dbContext.TaxNumbers.Include(tn => tn.TaxRate).FirstOrDefaultAsync(tn => tn.IDTaxNumber == id);

    public async Task AddAsync(TaxNumber taxNumber)
    {
        await _dbContext.TaxNumbers.AddAsync(taxNumber);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaxNumber taxNumber)
    {
        _dbContext.TaxNumbers.Update(taxNumber);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var taxNumber = await GetByIdAsync(id);
        if (taxNumber != null)
        {
            _dbContext.TaxNumbers.Remove(taxNumber);
            await _dbContext.SaveChangesAsync();
        }
    }
}