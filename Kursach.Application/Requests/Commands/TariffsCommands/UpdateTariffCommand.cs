﻿using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record UpdateTariffCommand(TariffForUpdateDto Tariff) : IRequest<bool>;