namespace FinalThesis.API.Services;

using AutoMapper;
using global::FinalThesis.API.BLModels;
using global::FinalThesis.DAL.DALModels;
using global::FinalThesis.DAL.Repositories;

public class AdvanceInvoiceService(IRepository<AdvanceInvoice> advanceInvoiceRepository, IMapper mapper)
{
    private readonly IRepository<AdvanceInvoice> _advanceInvoiceRepository = advanceInvoiceRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLAdvanceInvoice>> GetAllAdvanceInvoicesAsync()
    {
        var advanceInvoices = await _advanceInvoiceRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLAdvanceInvoice>>(advanceInvoices);
    }

    public async Task<BLAdvanceInvoice?> GetAdvanceInvoiceByIdAsync(int id)
    {
        var advanceInvoice = await _advanceInvoiceRepository.GetByIdAsync(id);
        return _mapper.Map<BLAdvanceInvoice>(advanceInvoice);
    }

    public async Task AddAdvanceInvoiceAsync(BLAdvanceInvoice blAdvanceInvoice)
    {
        var advanceInvoice = _mapper.Map<AdvanceInvoice>(blAdvanceInvoice);
        await _advanceInvoiceRepository.AddAsync(advanceInvoice);
        blAdvanceInvoice.IDAdvanceInvoice = advanceInvoice.IDAdvanceInvoice;
    }

    public async Task UpdateAdvanceInvoiceAsync(BLAdvanceInvoice blAdvanceInvoice)
    {
        var advanceInvoice = _mapper.Map<AdvanceInvoice>(blAdvanceInvoice);
        await _advanceInvoiceRepository.UpdateAsync(advanceInvoice);
    }

    public async Task DeleteAdvanceInvoiceAsync(int id)
    {
        await _advanceInvoiceRepository.DeleteAsync(id);
    }
}
