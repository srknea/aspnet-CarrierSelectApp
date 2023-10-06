using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Carrier.CreateCarrier
{
    public class CreateCarrierCommandValidator : AbstractValidator<CreateCarrierCommandRequest>
    {
        public CreateCarrierCommandValidator()
        {
            RuleFor(x => x.CarrierName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required").MaximumLength(75).WithMessage("{PropertyName} can not be longer than 75 characters");
            RuleFor(x => x.CarrierPlusDesiCost).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
