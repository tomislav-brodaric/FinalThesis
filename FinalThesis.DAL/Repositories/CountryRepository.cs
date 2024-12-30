using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class CountryRepository(FinalThesisContext dbContext) : IRepository<Country>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<Country>> GetAllAsync()
        => await _dbContext.Countries
            .Include(c => c.Cities)
            .Include(c => c.Currency)
            .ToListAsync();

    public async Task<Country?> GetByIdAsync(int id)
        => await _dbContext.Countries
            .Include(c => c.Cities)
            .Include(c => c.Currency)
            .FirstOrDefaultAsync(c => c.IDCountry == id);

    public async Task AddAsync(Country country)
    {
        await _dbContext.Countries.AddAsync(country);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Country country)
    {
        _dbContext.Update(country);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var country = await GetByIdAsync(id);
        if (country != null)
        {
            _dbContext.Cities.RemoveRange(country.Cities);
            _dbContext.Countries.Remove(country);
            await _dbContext.SaveChangesAsync();
        }
    }
}
