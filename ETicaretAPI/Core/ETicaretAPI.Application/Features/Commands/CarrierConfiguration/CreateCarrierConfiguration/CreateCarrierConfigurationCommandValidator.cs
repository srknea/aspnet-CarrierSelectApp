using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration
{
    public class CreateCarrierConfigurationCommandValidator : AbstractValidator<CreateCarrierConfigurationCommandRequest>
    {
        public CreateCarrierConfigurationCommandValidator()
        {
            RuleFor(x => x.CarrierMaxDesi).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(x => x.CarrierMinDesi).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(x => x.CarrierCost).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
            RuleFor(x => x.CarrierId).NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
