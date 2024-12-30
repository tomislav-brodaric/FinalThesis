using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class PartnerContactRepository(FinalThesisContext dbContext) : IRepository<PartnerContact>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<PartnerContact>> GetAllAsync()
        => await _dbContext.PartnerContacts
            .Include(pc => pc.Partner)
            .ToListAsync();

    public async Task<PartnerContact?> GetByIdAsync(int id)
        => await _dbContext.PartnerContacts
            .Include(pc => pc.Partner)
            .FirstOrDefaultAsync(pc => pc.IDContact == id);

    public async Task AddAsync(PartnerContact partnerContact)
    {
        await _dbContext.PartnerContacts.AddAsync(partnerContact);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(PartnerContact partnerContact)
    {
        _dbContext.PartnerContacts.Update(partnerContact);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var partnerContact = await GetByIdAsync(id);
        if (partnerContact != null)
        {
            _dbContext.PartnerContacts.Remove(partnerContact);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<PartnerContact?> FindByDetailsAsync(string firstName, string lastName, int partnerId)
    {
        return await _dbContext.PartnerContacts
            .FirstOrDefaultAsync(pc => pc.FirstName == firstName && pc.LastName == lastName && pc.PartnerID == partnerId);
    }
}
