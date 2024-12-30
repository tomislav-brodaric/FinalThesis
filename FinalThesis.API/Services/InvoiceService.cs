using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

public class InvoiceService
{
    private readonly IRepository<Invoice> _invoiceRepository;
    private readonly IMapper _mapper;

    public InvoiceService(IRepository<Invoice> invoiceRepository, IMapper mapper)
    {
        _invoiceRepository = invoiceRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BLInvoice>> GetAllInvoicesAsync()
    {
        var invoices = await _invoiceRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLInvoice>>(invoices);
    }

    public async Task<BLInvoice?> GetInvoiceByIdAsync(int id)
    {
        var invoice = await _invoiceRepository.GetByIdAsync(id);
        return _mapper.Map<BLInvoice>(invoice);
    }

    public async Task AddInvoiceAsync(BLInvoice blInvoice)
    {
        var invoice = _mapper.Map<Invoice>(blInvoice);
        await _invoiceRepository.AddAsync(invoice);

        blInvoice.IDInvoice = invoice.IDInvoice;
    }

    public async Task UpdateInvoiceAsync(BLInvoice blInvoice)
    {
        var existingInvoice = await _invoiceRepository.GetByIdAsync(blInvoice.IDInvoice);
        if (existingInvoice == null)
            throw new Exception("Invoice not found.");

        // Ukloni duplikate prije ažuriranja
        blInvoice.InvoiceProducts = blInvoice.InvoiceProducts
            .GroupBy(p => new { p.ProductID, p.Price })
            .Select(g => g.First())
            .ToList();

        _mapper.Map(blInvoice, existingInvoice);

        var productsToRemove = existingInvoice.InvoiceProducts
            .Where(ep => !blInvoice.InvoiceProducts.Any(p => p.IDInvoiceProduct == ep.IDInvoiceProduct))
            .ToList();

        foreach (var product in productsToRemove)
        {
            existingInvoice.InvoiceProducts.Remove(product);
        }

        foreach (var product in blInvoice.InvoiceProducts)
        {
            var existingProduct = existingInvoice.InvoiceProducts
                .FirstOrDefault(ep => ep.IDInvoiceProduct == product.IDInvoiceProduct);

            if (existingProduct != null)
            {
                _mapper.Map(product, existingProduct);
            }
            else
            {
                var newProduct = _mapper.Map<InvoiceProduct>(product);
                existingInvoice.InvoiceProducts.Add(newProduct);
            }
        }

        await _invoiceRepository.UpdateAsync(existingInvoice);
    }


    public async Task DeleteInvoiceAsync(int id)
    {
        await _invoiceRepository.DeleteAsync(id);
    }
}
