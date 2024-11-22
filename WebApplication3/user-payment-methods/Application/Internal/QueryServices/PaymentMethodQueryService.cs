using WebApplication3.user_payment_methods.Domain.Model.Aggregates;
using WebApplication3.user_payment_methods.Domain.Model.Queries;
using WebApplication3.user_payment_methods.Domain.Repositories;
using WebApplication3.user_payment_methods.Domain.Services;

namespace WebApplication3.user_payment_methods.Application.Internal.QueryServices;

public class PaymentMethodQueryService : IPaymentMethodQueryService
{
    private readonly IPaymentMethodRepository _paymentMethodRepository;

    public PaymentMethodQueryService(IPaymentMethodRepository paymentMethodRepository)
    {
        _paymentMethodRepository = paymentMethodRepository;
    }

    public async Task<IEnumerable<UserPaymentMethod>> Handle(GetAllPaymentMethodsQuery query)
    {
        return await _paymentMethodRepository.ListAsync();
    }

    public async Task<UserPaymentMethod?> Handle(GetPaymentMethodByIdQuery query)
    {
        return await _paymentMethodRepository.FindPaymentMethodByIdAsync(query.Id);
    }
}





























