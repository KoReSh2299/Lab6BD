using MediatR;
using AutoMapper;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class UpdatePaymentCommandHandler(IPaymentRepository repository, IDiscountRepository discountRepository, ITariffRepository tariffRepository, IMapper mapper) : IRequestHandler<UpdatePaymentCommand, bool>
{
	private readonly IPaymentRepository _repository = repository;
	private readonly ITariffRepository _tariffRepository = tariffRepository;
	private readonly IDiscountRepository _discountRepository = discountRepository;
	private readonly IMapper _mapper = mapper;

    public async Task<bool> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Payment.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

        if (request.Payment.CalculateAmountAutomatically)
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

        _mapper.Map(request.Payment, entity);

		_repository.Update(entity);
		await _repository.SaveChangesAsync();

		return true;
	}
}
