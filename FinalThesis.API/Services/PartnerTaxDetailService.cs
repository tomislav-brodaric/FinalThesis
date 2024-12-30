using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class PartnerTaxDetailService(IRepository<PartnerTaxDetail> taxDetailRepository, IMapper mapper)
{
    private readonly IRepository<PartnerTaxDetail> _taxDetailRepository = taxDetailRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLPartnerTaxDetail>> GetAllTaxDetailsAsync()
    {
        var taxDetails = await _taxDetailRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLPartnerTaxDetail>>(taxDetails);
    }

    public async Task<BLPartnerTaxDetail?> GetTaxDetailByIdAsync(int id)
    {
        var taxDetail = await _taxDetailRepository.GetByIdAsync(id);
        return _mapper.Map<BLPartnerTaxDetail>(taxDetail);
    }

    public async Task AddTaxDetailAsync(BLPartnerTaxDetail blTaxDetail)
    {
        var taxDetail = _mapper.Map<PartnerTaxDetail>(blTaxDetail);
        await _taxDetailRepository.AddAsync(taxDetail);
        blTaxDetail.IDTaxDetail = taxDetail.IDTaxDetail;
    }

    public async Task UpdateTaxDetailAsync(BLPartnerTaxDetail blTaxDetail)
    {
        var taxDetail = _mapper.Map<PartnerTaxDetail>(blTaxDetail);
        await _taxDetailRepository.UpdateAsync(taxDetail);
    }

    public async Task DeleteTaxDetailAsync(int id)
    {
        await _taxDetailRepository.DeleteAsync(id);
    }
}
