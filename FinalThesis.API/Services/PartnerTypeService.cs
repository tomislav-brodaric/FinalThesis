using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class PartnerTypeService(IRepository<PartnerType> partnerTypeRepository, IMapper mapper)
{
    private readonly IRepository<PartnerType> _partnerTypeRepository = partnerTypeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLPartnerType>> GetAllPartnerTypesAsync()
    {
        var partnerTypes = await _partnerTypeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLPartnerType>>(partnerTypes);
    }

    public async Task<BLPartnerType?> GetPartnerTypeByIdAsync(int id)
    {
        var partnerType = await _partnerTypeRepository.GetByIdAsync(id);
        return _mapper.Map<BLPartnerType>(partnerType);
    }

    public async Task AddPartnerTypeAsync(BLPartnerType blPartnerType)
    {
        var partnerType = _mapper.Map<PartnerType>(blPartnerType);
        await _partnerTypeRepository.AddAsync(partnerType);
        blPartnerType.IDPartnerType = partnerType.IDPartnerType;
    }

    public async Task UpdatePartnerTypeAsync(BLPartnerType blPartnerType)
    {
        var partnerType = _mapper.Map<PartnerType>(blPartnerType);
        await _partnerTypeRepository.UpdateAsync(partnerType);
    }

    public async Task DeletePartnerTypeAsync(int id)
    {
        await _partnerTypeRepository.DeleteAsync(id);
    }
}
