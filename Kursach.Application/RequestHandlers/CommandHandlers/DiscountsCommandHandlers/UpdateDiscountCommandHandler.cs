using MediatR;
using AutoMapper;
using Kursach.Domain.Abstractions;
using Kursach.Application.Requests.Commands;

namespace Kursach.Application.RequestHandlers.CommandHandlers;

public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, bool>
{
	private readonly IDiscountRepository _repository;
	private readonly IMapper _mapper;

	public UpdateDiscountCommandHandler(IDiscountRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<bool> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
	{
		var entity = await _repository.GetById(request.Discount.Id, trackChanges: true);

        if (entity is null)
        {
            return false;
        }

		_mapper.Map(request.Discount, entity);

		_repository.Update(entity);
		await _repository.SaveChangesAsync();

		return true;
	}
}
