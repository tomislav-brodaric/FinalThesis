using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class VATPaymentMethodService(IRepository<VATPaymentMethod> vatPaymentMethodRepository, IMapper mapper)
{
    private readonly IRepository<VATPaymentMethod> _vatPaymentMethodRepository = vatPaymentMethodRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLVATPaymentMethod>> GetAllVATPaymentMethodsAsync()
    {
        var vatPaymentMethods = await _vatPaymentMethodRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLVATPaymentMethod>>(vatPaymentMethods);
    }

    public async Task<BLVATPaymentMethod?> GetVATPaymentMethodByIdAsync(int id)
    {
        var vatPaymentMethod = await _vatPaymentMethodRepository.GetByIdAsync(id);
        return _mapper.Map<BLVATPaymentMethod>(vatPaymentMethod);
    }

    public async Task AddVATPaymentMethodAsync(BLVATPaymentMethod blVATPaymentMethod)
    {
        var vatPaymentMethod = _mapper.Map<VATPaymentMethod>(blVATPaymentMethod);
        await _vatPaymentMethodRepository.AddAsync(vatPaymentMethod);
        blVATPaymentMethod.IDVATPaymentMethod = vatPaymentMethod.IDVATPaymentMethod;
    }

    public async Task UpdateVATPaymentMethodAsync(BLVATPaymentMethod blVATPaymentMethod)
    {
        var vatPaymentMethod = _mapper.Map<VATPaymentMethod>(blVATPaymentMethod);
        await _vatPaymentMethodRepository.UpdateAsync(vatPaymentMethod);
    }

    public async Task DeleteVATPaymentMethodAsync(int id)
    {
        await _vatPaymentMethodRepository.DeleteAsync(id);
    }
}
