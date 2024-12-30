using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class PartnerRepository(FinalThesisContext dbContext) : IRepository<Partner>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<Partner>> GetAllAsync()
        => await _dbContext.Partners
            .Include(p => p.Country)
            .Include(p => p.PartnerType)
            .Include(p => p.PartnerPriceLists)
            .Include(p => p.PartnerTaxDetails)
            .Include(p => p.PartnerContacts)
            .Include(p => p.BillingCity)
            .ToListAsync();

    public async Task<Partner?> GetByIdAsync(int id)
        => await _dbContext.Partners
            .Include(p => p.Country)
            .Include(p => p.PartnerType)
            .Include(p => p.PartnerPriceLists)
            .Include(p => p.PartnerTaxDetails)
            .Include(p => p.PartnerContacts)
            .Include(p => p.BillingCity)
            .FirstOrDefaultAsync(p => p.IDPartner == id);

    public async Task AddAsync(Partner partner)
    {
        await _dbContext.Partners.AddAsync(partner);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Partner partner)
    {
        _dbContext.Partners.Update(partner);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var partner = await GetByIdAsync(id);
        if (partner != null)
        {
            _dbContext.PartnerPriceLists.RemoveRange(partner.PartnerPriceLists);
            _dbContext.PartnerTaxDetails.RemoveRange(partner.PartnerTaxDetails);
            _dbContext.PartnerContacts.RemoveRange(partner.PartnerContacts);
            _dbContext.Partners.Remove(partner);
            await _dbContext.SaveChangesAsync();
        }
    }
}