using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class CurrencyService(IRepository<Currency> currencyRepository, IMapper mapper)
{
    private readonly IRepository<Currency> _currencyRepository = currencyRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLCurrency>> GetAllCurrenciesAsync()
    {
        var currencies = await _currencyRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLCurrency>>(currencies);
    }

    public async Task<BLCurrency?> GetCurrencyByIdAsync(int id)
    {
        var currency = await _currencyRepository.GetByIdAsync(id);
        return _mapper.Map<BLCurrency>(currency);
    }

    public async Task AddCurrencyAsync(BLCurrency blCurrency)
    {
        var existingCurrencies = await _currencyRepository.GetAllAsync();
        if (existingCurrencies.Any(c => c.CurrencyCode == blCurrency.CurrencyCode))
        {
            throw new InvalidOperationException("Currency with this code already exists.");
        }

        var currency = _mapper.Map<Currency>(blCurrency);
        await _currencyRepository.AddAsync(currency);
        blCurrency.IDCurrency = currency.IDCurrency;
    }

    public async Task UpdateCurrencyAsync(BLCurrency blCurrency)
    {
        var currency = _mapper.Map<Currency>(blCurrency);
        await _currencyRepository.UpdateAsync(currency);
    }

    public async Task DeleteCurrencyAsync(int id)
    {
        await _currencyRepository.DeleteAsync(id);
    }
}