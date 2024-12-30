using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

public class AdvanceInvoicePaymentRepository(FinalThesisContext dbContext) : IRepository<AdvanceInvoicePayment>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<AdvanceInvoicePayment>> GetAllAsync()
        => await _dbContext.AdvanceInvoicePayments.Include(aip => aip.AdvanceInvoice).ToListAsync();

    public async Task<AdvanceInvoicePayment?> GetByIdAsync(int id)
        => await _dbContext.AdvanceInvoicePayments.Include(aip => aip.AdvanceInvoice)
                                                  .FirstOrDefaultAsync(aip => aip.IDAdvanceInvoicePayment == id);

    public async Task AddAsync(AdvanceInvoicePayment advanceInvoicePayment)
    {
        await _dbContext.AdvanceInvoicePayments.AddAsync(advanceInvoicePayment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(AdvanceInvoicePayment advanceInvoicePayment)
    {
        _dbContext.AdvanceInvoicePayments.Update(advanceInvoicePayment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var advanceInvoicePayment = await GetByIdAsync(id);
        if (advanceInvoicePayment != null)
        {
            _dbContext.AdvanceInvoicePayments.Remove(advanceInvoicePayment);
            await _dbContext.SaveChangesAsync();
        }
    }
}