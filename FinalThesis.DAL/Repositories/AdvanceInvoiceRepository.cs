using FinalThesis.DAL.DALModels;
using Microsoft.EntityFrameworkCore;

namespace FinalThesis.DAL.Repositories;

public class AdvanceInvoiceRepository(FinalThesisContext dbContext) : IRepository<AdvanceInvoice>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<AdvanceInvoice>> GetAllAsync()
        => await _dbContext.AdvanceInvoices.Include(ai => ai.AdvanceInvoicePayments)
                                           //.Include(ai => ai.Exemption)
                                           .Include(ai => ai.Partner)
                                           .ToListAsync();

    public async Task<AdvanceInvoice?> GetByIdAsync(int id)
        => await _dbContext.AdvanceInvoices.Include(ai => ai.AdvanceInvoicePayments)
                                           //.Include(ai => ai.Exemption)
                                           .Include(ai => ai.Partner)
                                           .FirstOrDefaultAsync(ai => ai.IDAdvanceInvoice == id);

    public async Task AddAsync(AdvanceInvoice advanceInvoice)
    {
        await _dbContext.AdvanceInvoices.AddAsync(advanceInvoice);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(AdvanceInvoice advanceInvoice)
    {
        _dbContext.AdvanceInvoices.Update(advanceInvoice);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var advanceInvoice = await GetByIdAsync(id);
        if (advanceInvoice != null)
        {
            _dbContext.AdvanceInvoices.Remove(advanceInvoice);
            await _dbContext.SaveChangesAsync();
        }
    }
}