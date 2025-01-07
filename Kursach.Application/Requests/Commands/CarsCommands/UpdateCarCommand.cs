﻿using MediatR;
using Kursach.Application.Dtos;

namespace Kursach.Application.Requests.Commands;

public record UpdateCarCommand(CarForUpdateDto Car) : IRequest<bool>;