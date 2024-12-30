using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class TaxNumberTypeRepository(FinalThesisContext dbContext) : IRepository<TaxNumberType>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<TaxNumberType>> GetAllAsync()
        => await _dbContext.TaxNumberTypes.ToListAsync();

    public async Task<TaxNumberType?> GetByIdAsync(int id)
        => await _dbContext.TaxNumberTypes.FirstOrDefaultAsync(tt => tt.IDTaxNumberType == id);

    public async Task AddAsync(TaxNumberType taxNumberType)
    {
        await _dbContext.TaxNumberTypes.AddAsync(taxNumberType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaxNumberType taxNumberType)
    {
        _dbContext.TaxNumberTypes.Update(taxNumberType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var taxNumberType = await GetByIdAsync(id);
        if (taxNumberType != null)
        {
            _dbContext.TaxNumberTypes.Remove(taxNumberType);
            await _dbContext.SaveChangesAsync();
        }
    }
}
