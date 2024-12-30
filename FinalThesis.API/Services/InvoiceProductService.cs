using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class InvoiceProductService(IRepository<InvoiceProduct> invoiceProductRepository, IMapper mapper)
{
    private readonly IRepository<InvoiceProduct> _invoiceProductRepository = invoiceProductRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLInvoiceProduct>> GetAllInvoiceProductsAsync()
    {
        var invoiceProducts = await _invoiceProductRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLInvoiceProduct>>(invoiceProducts);
    }

    public async Task<BLInvoiceProduct?> GetInvoiceProductByIdAsync(int id)
    {
        var invoiceProduct = await _invoiceProductRepository.GetByIdAsync(id);
        return _mapper.Map<BLInvoiceProduct>(invoiceProduct);
    }

    public async Task AddInvoiceProductAsync(BLInvoiceProduct blInvoiceProduct)
    {
        var invoiceProduct = _mapper.Map<InvoiceProduct>(blInvoiceProduct);
        await _invoiceProductRepository.AddAsync(invoiceProduct);
        blInvoiceProduct.IDInvoiceProduct = invoiceProduct.IDInvoiceProduct;
    }

    public async Task UpdateInvoiceProductAsync(BLInvoiceProduct blInvoiceProduct)
    {
        var invoiceProduct = _mapper.Map<InvoiceProduct>(blInvoiceProduct);
        await _invoiceProductRepository.UpdateAsync(invoiceProduct);
    }

    public async Task DeleteInvoiceProductAsync(int id)
    {
        await _invoiceProductRepository.DeleteAsync(id);
    }
}
