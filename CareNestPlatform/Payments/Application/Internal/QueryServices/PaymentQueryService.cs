using CareNestPlatform.Payments.Domain.Model.Aggregates;
using CareNestPlatform.Payments.Domain.Model.Queries;
using CareNestPlatform.Payments.Domain.Repositories;
using CareNestPlatform.Payments.Domain.Services;

namespace CareNestPlatform.Payments.Application.Internal.QueryServices;

public class PaymentQueryService : IPaymentQueryService
{
    private readonly IPaymentRepository _paymentRepository;

    public PaymentQueryService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentQuery query)
    {
        return await _paymentRepository.ListAsync(); // Get all payments
    }

    public async Task<Payment?> Handle(GetPaymentByIdQuery query)
    {
        return await _paymentRepository.FindPaymentByIdAsync(query.Id); // Get payment by ID
    }
}