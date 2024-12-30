using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class PartnerTypeRepository(FinalThesisContext dbContext) : IRepository<PartnerType>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<PartnerType>> GetAllAsync()
        => await _dbContext.PartnerTypes.ToListAsync();

    public async Task<PartnerType?> GetByIdAsync(int id)
        => await _dbContext.PartnerTypes.FirstOrDefaultAsync(pt => pt.IDPartnerType == id);

    public async Task AddAsync(PartnerType partnerType)
    {
        await _dbContext.PartnerTypes.AddAsync(partnerType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(PartnerType partnerType)
    {
        _dbContext.PartnerTypes.Update(partnerType);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var partnerType = await GetByIdAsync(id);
        if (partnerType != null)
        {
            _dbContext.PartnerTypes.Remove(partnerType);
            await _dbContext.SaveChangesAsync();
        }
    }
}
