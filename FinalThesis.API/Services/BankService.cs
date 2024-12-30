using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class BankService(IRepository<Bank> bankRepository, IMapper mapper)
{
    private readonly IRepository<Bank> _bankRepository = bankRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLBank>> GetAllBanksAsync()
    {
        var banks = await _bankRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLBank>>(banks);
    }

    public async Task<BLBank?> GetBankByIdAsync(int id)
    {
        var bank = await _bankRepository.GetByIdAsync(id);
        return _mapper.Map<BLBank>(bank);
    }

    public async Task AddBankAsync(BLBank blBank)
    {
        var existingBanks = await _bankRepository.GetAllAsync();
        if (existingBanks.Any(b => b.BankOIB == blBank.BankOIB))
        {
            throw new InvalidOperationException("Bank with this OIB already exists.");
        }

        var bank = _mapper.Map<Bank>(blBank);
        await _bankRepository.AddAsync(bank);
        blBank.IDBank = bank.IDBank;
    }

    public async Task UpdateBankAsync(BLBank blBank)
    {
        var bank = _mapper.Map<Bank>(blBank);
        await _bankRepository.UpdateAsync(bank);
    }

    public async Task DeleteBankAsync(int id)
    {
        await _bankRepository.DeleteAsync(id);
    }
}