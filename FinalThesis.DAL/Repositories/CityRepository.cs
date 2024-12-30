using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class CityRepository(FinalThesisContext dbContext) : IRepository<City>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<City>> GetAllAsync()
        => await _dbContext.Cities.Include(c => c.Country).ToListAsync();

    public async Task<City?> GetByIdAsync(int id)
        => await _dbContext.Cities.Include(c => c.Country).FirstOrDefaultAsync(c => c.IDCity == id);

    public async Task AddAsync(City city)
    {
        await _dbContext.Cities.AddAsync(city);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(City city)
    {
        _dbContext.Update(city);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var city = await GetByIdAsync(id);
        if (city != null)
        {
            _dbContext.Cities.Remove(city);
            await _dbContext.SaveChangesAsync();
        }
    }
}
