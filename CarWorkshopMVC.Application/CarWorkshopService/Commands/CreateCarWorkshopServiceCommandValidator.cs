﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandValidator : AbstractValidator<CreateCarWorkshopServiceCommand>
    {
        public CreateCarWorkshopServiceCommandValidator()
        {
            RuleFor(s => s.Cost).NotEmpty();
            RuleFor(s=>s.Description).NotEmpty().NotNull();
            RuleFor(s=>s.CarWorkshopEncodedName).NotEmpty().NotNull();
        }
    }
}
