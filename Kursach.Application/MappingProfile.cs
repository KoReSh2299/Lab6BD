using AutoMapper;
using Kursach.Domain.Entities;
using Kursach.Application.Dtos;
using Kursach.Domain.Utilities;

namespace Kursach.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
		CreateMap<Client, ClientDto>();
		CreateMap<ClientForCreationDto, Client>();
		CreateMap<ClientForUpdateDto, Client>();
		CreateMap<Client, ClientForUpdateDto>();
		CreateMap<ClientDto, ClientForUpdateDto>();
        CreateMap<PaginatedList<Client>, PaginatedList<ClientDto>>()
        .ConvertUsing((src, dest, context) =>
        {
            var items = context.Mapper.Map<List<ClientDto>>(src);
            return new PaginatedList<ClientDto>(items, src.PageIndex, src.PageSize, src.TotalPagesCount);
        });

        CreateMap<Employee, EmployeeDto>();
		CreateMap<EmployeeForCreationDto, Employee>();
		CreateMap<EmployeeForUpdateDto, Employee>();
		CreateMap<Employee, EmployeeForUpdateDto>();
		CreateMap<EmployeeDto, EmployeeForUpdateDto>();
        CreateMap<PaginatedList<Employee>, PaginatedList<EmployeeDto>>()
        .ConvertUsing((src, dest, context) =>
        {
            var items = context.Mapper.Map<List<EmployeeDto>>(src);
            return new PaginatedList<EmployeeDto>(items, src.PageIndex, src.PageSize, src.TotalPagesCount);
        });

        CreateMap<Tariff, TariffDto>();
		CreateMap<TariffForCreationDto, Tariff>();
		CreateMap<TariffForUpdateDto, Tariff>();
		CreateMap<Tariff, TariffForUpdateDto>();
		CreateMap<TariffDto, TariffForUpdateDto>();
        CreateMap<PaginatedList<Tariff>, PaginatedList<TariffDto>>()
        .ConvertUsing((src, dest, context) =>
        {
            var items = context.Mapper.Map<List<TariffDto>>(src);
            return new PaginatedList<TariffDto>(items, src.PageIndex, src.PageSize, src.TotalPagesCount);
        });

        CreateMap<Discount, DiscountDto>();
		CreateMap<DiscountForCreationDto, Discount>();
		CreateMap<DiscountForUpdateDto, Discount>();
		CreateMap<Discount, DiscountForUpdateDto>();
		CreateMap<DiscountDto, DiscountForUpdateDto>();
        CreateMap<PaginatedList<Discount>, PaginatedList<DiscountDto>>()
        .ConvertUsing((src, dest, context) =>
        {
            var items = context.Mapper.Map<List<DiscountDto>>(src);
            return new PaginatedList<DiscountDto>(items, src.PageIndex, src.PageSize, src.TotalPagesCount);
        });

        CreateMap<Car, CarDto>();
		CreateMap<CarForCreationDto, Car>();
		CreateMap<CarForUpdateDto, Car>();
		CreateMap<Car, CarForUpdateDto>();
		CreateMap<CarDto, CarForUpdateDto>();
        CreateMap<PaginatedList<Car>, PaginatedList<CarDto>>()
        .ConvertUsing((src, dest, context) =>
        {
            var items = context.Mapper.Map<List<CarDto>>(src);
            return new PaginatedList<CarDto>(items, src.PageIndex, src.PageSize, src.TotalPagesCount);
        });

        CreateMap<ParkingSpace, ParkingSpaceDto>();
		CreateMap<ParkingSpaceForCreationDto, ParkingSpace>();
		CreateMap<ParkingSpaceForUpdateDto, ParkingSpace>();
		CreateMap<ParkingSpace, ParkingSpaceForUpdateDto>(); 
		CreateMap<ParkingSpaceDto, ParkingSpaceForUpdateDto>(); 
		CreateMap<PaginatedList<ParkingSpace>, PaginatedList<ParkingSpaceDto>>()
		.ConvertUsing((src, dest, context) =>
		{
			var items = context.Mapper.Map<List<ParkingSpaceDto>>(src);
			return new PaginatedList<ParkingSpaceDto>(items, src.PageIndex, src.PageSize, src.TotalPagesCount);
		});

        CreateMap<WorkShift, WorkShiftDto>();
		CreateMap<WorkShiftForCreationDto, WorkShift>();
		CreateMap<WorkShiftForUpdateDto, WorkShift>();
		CreateMap<WorkShift, WorkShiftForUpdateDto>();
		CreateMap<WorkShiftDto, WorkShiftForUpdateDto>();
        CreateMap<PaginatedList<WorkShift>, PaginatedList<WorkShiftDto>>()
        .ConvertUsing((src, dest, context) =>
        {
            var items = context.Mapper.Map<List<WorkShiftDto>>(src);
            return new PaginatedList<WorkShiftDto>(items, src.PageIndex, src.PageSize, src.TotalPagesCount);
        });

        CreateMap<Payment, PaymentDto>();
		CreateMap<PaymentForCreationDto, Payment>();
		CreateMap<PaymentForUpdateDto, Payment>();
		CreateMap<Payment, PaymentForUpdateDto>();
		CreateMap<PaymentDto, PaymentForUpdateDto>();
        CreateMap<PaginatedList<Payment>, PaginatedList<PaymentDto>>()
        .ConvertUsing((src, dest, context) =>
        {
            var items = context.Mapper.Map<List<PaymentDto>>(src);
            return new PaginatedList<PaymentDto>(items, src.PageIndex, src.PageSize, src.TotalPagesCount);
        });

        CreateMap<WorkShiftPayment, WorkShiftPaymentDto>();
		CreateMap<WorkShiftPaymentForCreationDto, WorkShiftPayment>();
		CreateMap<WorkShiftPaymentForUpdateDto, WorkShiftPayment>();
		CreateMap<WorkShiftPayment, WorkShiftPaymentForUpdateDto>();
		CreateMap<WorkShiftPaymentDto, WorkShiftPaymentForUpdateDto>();
        CreateMap<PaginatedList<WorkShiftPayment>, PaginatedList<WorkShiftPaymentDto>>()
        .ConvertUsing((src, dest, context) =>
        {
            var items = context.Mapper.Map<List<WorkShiftPaymentDto>>(src);
            return new PaginatedList<WorkShiftPaymentDto>(items, src.PageIndex, src.PageSize, src.TotalPagesCount);
        });

        CreateMap<EmployeeWorkSummary, EmployeeWorkSummaryDto>();
        CreateMap<PaginatedList<EmployeeWorkSummary>, PaginatedList<EmployeeWorkSummaryDto>>()
        .ConvertUsing((src, dest, context) =>
        {
            var items = context.Mapper.Map<List<EmployeeWorkSummaryDto>>(src);
            return new PaginatedList<EmployeeWorkSummaryDto>(items, src.PageIndex, src.PageSize, src.TotalPagesCount);
        });

        CreateMap<User, UserDto>();
        CreateMap<UserForCreationDto, User>()
            .ConstructUsing((src, dst) => {
                var passSalt = PasswordHelper.HashPassword(src.Password);

                var user = new User()
                {
                    Username = src.Username,
                    PasswordHash = passSalt.hash,
                    PasswordSalt = passSalt.salt,
                    Role = src.Role,
                    CreatedAt = DateTime.Now
                };

                return user;
            });
        CreateMap<UserForUpdateDto, User>()
            .ConstructUsing((src, dst) =>
            {
                var passSalt = PasswordHelper.HashPassword(src.Password);

                var user = new User()
                {
                    Username = src.Username,
                    PasswordHash = passSalt.hash,
                    PasswordSalt = passSalt.salt,
                    Role = src.Role,
                    CreatedAt = DateTime.Now
                };

                return user;
            });
        CreateMap<User, UserForUpdateDto>();
        CreateMap<UserDto, UserForUpdateDto>();
        CreateMap<PaginatedList<User>, PaginatedList<UserDto>>()
        .ConvertUsing((src, dest, context) =>
        {
            var items = context.Mapper.Map<List<UserDto>>(src);
            return new PaginatedList<UserDto>(items, src.PageIndex, src.PageSize, src.TotalPagesCount);
        });
    }
}

