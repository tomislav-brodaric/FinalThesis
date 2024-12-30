using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class ConnectionTypeRepository(FinalThesisContext dbContext) : IRepository<ConnectionType>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<ConnectionType>> GetAllAsync()
        => await _dbContext.ConnectionTypes.ToListAsync();

    public async Task<ConnectionType?> GetByIdAsync(int id)
        => await _dbContext.ConnectionTypes.FirstOrDefaultAsync(c => c.IDConnectionType == id);

    public async Task AddAsync(ConnectionType connectionType)
    {
        await _dbContext.ConnectionTypes.AddAsync(connectionType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ConnectionType connectionType)
    {
        _dbContext.ConnectionTypes.Update(connectionType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var connectionType = await GetByIdAsync(id);
        if (connectionType != null)
        {
            _dbContext.ConnectionTypes.Remove(connectionType);
            await _dbContext.SaveChangesAsync();
        }
    }
}
