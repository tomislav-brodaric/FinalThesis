using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class PartnerService(IRepository<Partner> partnerRepository, PartnerContactRepository partnerContactRepository, IMapper mapper)
{
    private readonly IRepository<Partner> _partnerRepository = partnerRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLPartner>> GetAllPartnersAsync()
    {
        var partners = await _partnerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLPartner>>(partners);
    }

    public async Task<BLPartner?> GetPartnerByIdAsync(int id)
    {
        var partner = await _partnerRepository.GetByIdAsync(id);
        return _mapper.Map<BLPartner>(partner);
    }

    public async Task AddPartnerAsync(BLPartner blPartner)
    {
        var partner = _mapper.Map<Partner>(blPartner);
        await _partnerRepository.AddAsync(partner);
        blPartner.IDPartner = partner.IDPartner;
    }

    public async Task UpdatePartnerAsync(BLPartner blPartner)
    {
        var partner = _mapper.Map<Partner>(blPartner);
        await _partnerRepository.UpdateAsync(partner);
    }

    public async Task DeletePartnerAsync(int id)
    {
        await _partnerRepository.DeleteAsync(id);
    }

    public async Task AddContactAsync(BLPartnerContact contact)
    {
        var dalContact = _mapper.Map<PartnerContact>(contact);
        await partnerContactRepository.AddAsync(dalContact);
    }
}
