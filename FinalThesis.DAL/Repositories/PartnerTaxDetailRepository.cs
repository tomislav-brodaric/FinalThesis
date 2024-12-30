using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class PartnerTaxDetailRepository(FinalThesisContext dbContext) : IRepository<PartnerTaxDetail>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<PartnerTaxDetail>> GetAllAsync()
        => await _dbContext.PartnerTaxDetails
            .Include(p => p.Partner)
            .Include(p => p.TaxNumberType)
            .Include(p => p.VATPaymentMethod)
            .ToListAsync();

    public async Task<PartnerTaxDetail?> GetByIdAsync(int id)
        => await _dbContext.PartnerTaxDetails
            .Include(p => p.Partner)
            .Include(p => p.TaxNumberType)
            .Include(p => p.VATPaymentMethod)
            .FirstOrDefaultAsync(p => p.IDTaxDetail == id);

    public async Task AddAsync(PartnerTaxDetail partnerTaxDetail)
    {
        await _dbContext.PartnerTaxDetails.AddAsync(partnerTaxDetail);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(PartnerTaxDetail partnerTaxDetail)
    {
        _dbContext.PartnerTaxDetails.Update(partnerTaxDetail);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var partnerTaxDetail = await GetByIdAsync(id);
        if (partnerTaxDetail != null)
        {
            _dbContext.PartnerTaxDetails.Remove(partnerTaxDetail);
            await _dbContext.SaveChangesAsync();
        }
    }
}
