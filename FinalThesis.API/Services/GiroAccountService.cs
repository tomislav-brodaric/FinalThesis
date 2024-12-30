using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class GiroAccountService(IRepository<GiroAccount> giroAccountRepository, IMapper mapper)
{
    private readonly IRepository<GiroAccount> _giroAccountRepository = giroAccountRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLGiroAccount>> GetAllGiroAccountsAsync()
    {
        var giroAccounts = await _giroAccountRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLGiroAccount>>(giroAccounts);
    }

    public async Task<BLGiroAccount?> GetGiroAccountByIdAsync(int id)
    {
        var giroAccount = await _giroAccountRepository.GetByIdAsync(id);
        return _mapper.Map<BLGiroAccount>(giroAccount);
    }

    public async Task AddGiroAccountAsync(BLGiroAccount blGiroAccount)
    {
        var existingAccounts = await _giroAccountRepository.GetAllAsync();
        if (existingAccounts.Any(a => a.IBAN == blGiroAccount.IBAN))
        {
            throw new InvalidOperationException("A GiroAccount with this IBAN already exists.");
        }

        var giroAccount = _mapper.Map<GiroAccount>(blGiroAccount);
        await _giroAccountRepository.AddAsync(giroAccount);
        blGiroAccount.IDGiroAccount = giroAccount.IDGiroAccount;
    }

    public async Task UpdateGiroAccountAsync(BLGiroAccount blGiroAccount)
    {
        var giroAccount = _mapper.Map<GiroAccount>(blGiroAccount);
        await _giroAccountRepository.UpdateAsync(giroAccount);
    }

    public async Task DeleteGiroAccountAsync(int id)
    {
        await _giroAccountRepository.DeleteAsync(id);
    }
}