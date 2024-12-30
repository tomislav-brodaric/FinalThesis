using AutoMapper;
using FinalThesis.API.BLModels;
using FinalThesis.DAL.DALModels;
using FinalThesis.DAL.Repositories;

namespace FinalThesis.API.Services;

public class AdvanceInvoicePaymentService(IRepository<AdvanceInvoicePayment> paymentRepository, IMapper mapper)
{
    private readonly IRepository<AdvanceInvoicePayment> _paymentRepository = paymentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<BLAdvanceInvoicePayment>> GetAllPaymentsAsync()
    {
        var payments = await _paymentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BLAdvanceInvoicePayment>>(payments);
    }

    public async Task<BLAdvanceInvoicePayment?> GetPaymentByIdAsync(int id)
    {
        var payment = await _paymentRepository.GetByIdAsync(id);
        return _mapper.Map<BLAdvanceInvoicePayment>(payment);
    }

    public async Task AddPaymentAsync(BLAdvanceInvoicePayment blPayment)
    {
        var payment = _mapper.Map<AdvanceInvoicePayment>(blPayment);
        await _paymentRepository.AddAsync(payment);
        blPayment.IDAdvanceInvoicePayment = payment.IDAdvanceInvoicePayment;
    }

    public async Task UpdatePaymentAsync(BLAdvanceInvoicePayment blPayment)
    {
        var payment = _mapper.Map<AdvanceInvoicePayment>(blPayment);
        await _paymentRepository.UpdateAsync(payment);
    }

    public async Task DeletePaymentAsync(int id)
    {
        await _paymentRepository.DeleteAsync(id);
    }
}
