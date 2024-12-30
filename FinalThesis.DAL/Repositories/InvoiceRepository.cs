using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

public class InvoiceRepository : IRepository<Invoice>
{
    private readonly FinalThesisContext _dbContext;

    public InvoiceRepository(FinalThesisContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Invoice>> GetAllAsync()
    {
        return await _dbContext.Invoices
            .Include(i => i.InvoiceProducts)
                .ThenInclude(ip => ip.Product)
            .Include(i => i.Partner)
            .ToListAsync();
    }

    public async Task<Invoice?> GetByIdAsync(int id)
    {
        return await _dbContext.Invoices
            .Include(i => i.InvoiceProducts)
                .ThenInclude(ip => ip.Product)
            .Include(i => i.Partner)
            .FirstOrDefaultAsync(i => i.IDInvoice == id);
    }

    public async Task AddAsync(Invoice invoice)
    {
        await _dbContext.Invoices.AddAsync(invoice);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Invoice invoice)
    {
        var existingInvoice = await GetByIdAsync(invoice.IDInvoice);
        if (existingInvoice == null)
            throw new Exception("Invoice not found.");

        var productsToRemove = existingInvoice.InvoiceProducts
            .Where(ep => !invoice.InvoiceProducts.Any(p => p.IDInvoiceProduct == ep.IDInvoiceProduct))
            .ToList();

        foreach (var product in productsToRemove)
        {
            _dbContext.InvoiceProducts.Remove(product);
        }

        foreach (var product in invoice.InvoiceProducts)
        {
            var existingProduct = existingInvoice.InvoiceProducts
                .FirstOrDefault(ep => ep.IDInvoiceProduct == product.IDInvoiceProduct);

            if (existingProduct != null)
            {
                _dbContext.Entry(existingProduct).CurrentValues.SetValues(product);
            }
            else
            {
                existingInvoice.InvoiceProducts.Add(product);
            }
        }

        _dbContext.Entry(existingInvoice).CurrentValues.SetValues(invoice);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var invoice = await GetByIdAsync(id);
        if (invoice == null)
            throw new Exception("Invoice not found.");

        _dbContext.Invoices.Remove(invoice);
        await _dbContext.SaveChangesAsync();
    }
}
