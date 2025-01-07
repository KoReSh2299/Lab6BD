using MediatR;
using AutoMapper;
using Kursach.Domain.Entities;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class CreatePaymentCommandHandler(IPaymentRepository repository, ITariffRepository tariffRepository, IDiscountRepository discountRepository, IMapper mapper) : IRequestHandler<CreatePaymentCommand>
{
	private readonly IPaymentRepository _repository = repository;
	private readonly ITariffRepository _tariffRepository = tariffRepository;
	private readonly IDiscountRepository _discountRepository = discountRepository;
	private readonly IMapper _mapper = mapper;

    public async Task Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
	{
		if(request.Payment.CalculateAmountAutomatically)
		{
			var countHours = (int)Math.Round((request.Payment.TimeOut - request.Payment.TimeIn).TotalHours);
			var tariff = await _tariffRepository.GetById(request.Payment.TariffId, false) ?? throw new ArgumentNullException(nameof(request));

            if (request.Payment.DiscountId == null)
			{
				request.Payment.Amount = countHours * tariff.Rate;
			}
			else
			{
				var discount = await _discountRepository.GetById((int)request.Payment.DiscountId, false) ?? throw new ArgumentNullException(nameof(request));
				request.Payment.Amount = countHours * tariff.Rate * (decimal)(1 - (discount.Percentage / 100.0));
			}
		}

		await _repository.Create(_mapper.Map<Payment>(request.Payment));
		await _repository.SaveChangesAsync();
	}
}
