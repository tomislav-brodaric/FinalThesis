using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

public class InvoiceProductRepository(FinalThesisContext dbContext) : IRepository<InvoiceProduct>
{
    private readonly FinalThesisContext _dbContext = dbContext;

    public async Task<IEnumerable<InvoiceProduct>> GetAllAsync()
        => await _dbContext.InvoiceProducts.Include(ip => ip.Invoice)
                                           .Include(ip => ip.Product)
                                           .ToListAsync();

    public async Task<InvoiceProduct?> GetByIdAsync(int id)
        => await _dbContext.InvoiceProducts.Include(ip => ip.Invoice)
                                           .Include(ip => ip.Product)
                                           .FirstOrDefaultAsync(ip => ip.IDInvoiceProduct == id);

    public async Task AddAsync(InvoiceProduct invoiceProduct)
    {
        await _dbContext.InvoiceProducts.AddAsync(invoiceProduct);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(InvoiceProduct invoiceProduct)
    {
        _dbContext.InvoiceProducts.Update(invoiceProduct);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var invoiceProduct = await GetByIdAsync(id);
        if (invoiceProduct != null)
        {
            _dbContext.InvoiceProducts.Remove(invoiceProduct);
            await _dbContext.SaveChangesAsync();
        }
    }
}