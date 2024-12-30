using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class PartnerContactService(PartnerContactRepository partnerContactRepository, IMapper mapper)
{
    private readonly PartnerContactRepository _partnerContactRepository = partnerContactRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLPartnerContact>> GetAllPartnerContactsAsync()
    {
        var partnerContacts = await _partnerContactRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLPartnerContact>>(partnerContacts);
    }

    public async Task<BLPartnerContact?> GetPartnerContactByIdAsync(int id)
    {
        var partnerContact = await _partnerContactRepository.GetByIdAsync(id);
        return _mapper.Map<BLPartnerContact>(partnerContact);
    }

    public async Task AddPartnerContactAsync(BLPartnerContact blPartnerContact)
    {
        var partnerContact = _mapper.Map<PartnerContact>(blPartnerContact);
        await _partnerContactRepository.AddAsync(partnerContact);
        blPartnerContact.IDContact = partnerContact.IDContact;
    }

    public async Task UpdatePartnerContactAsync(BLPartnerContact blPartnerContact)
    {
        var partnerContact = _mapper.Map<PartnerContact>(blPartnerContact);
        await _partnerContactRepository.UpdateAsync(partnerContact);
    }

    public async Task DeletePartnerContactAsync(int id)
    {
        await _partnerContactRepository.DeleteAsync(id);
    }

    public async Task<BLPartnerContact?> GetContactByDetailsAsync(string firstName, string lastName, int partnerId)
    {
        var existingContact = await _partnerContactRepository.FindByDetailsAsync(firstName, lastName, partnerId);
        return _mapper.Map<BLPartnerContact>(existingContact);
    }
}